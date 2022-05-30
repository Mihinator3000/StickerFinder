using System.Globalization;
using System.Text.RegularExpressions;
using StickerFinder.Domain.Dto;
using StickerFinder.Domain.Exceptions;

namespace StickerFinder.Core.Parsers;

public class RawDataParser
{
    private const int MinWeaponsCount = 1;

    private const decimal MinWeaponPrice = 0;

    private readonly string _rawData;

    public RawDataParser(string rawData)
        => _rawData = rawData;

    public WeaponDto? GetCheapestWeapon()
        => GetWeapons().FirstOrDefault();

    public IEnumerable<WeaponDto> GetCheapestWeapons(int weaponsCount)
    {
        if (weaponsCount < MinWeaponsCount)
            throw new InvalidRequestException(
                $"Item count could not be less than {MinWeaponsCount}");
        
        return GetWeapons().Take(weaponsCount);
    }

    private IEnumerable<WeaponDto> GetWeapons()
        => GetRawItems()
            .Select(u =>
            {
                string stringPrice = new Regex("normal_price.+?>\\$(.+?) USD")
                    .Match(u).Groups[1].Value;

                decimal price = decimal.Parse(stringPrice, CultureInfo.GetCultureInfo("en-US"));

                return new WeaponDto
                {
                    Name = new Regex("data-hash-name=\"(.+?)\">").Match(u).Groups[1].Value,
                    Price = price,
                    Link = new Regex("href=\"(.+?)\"").Match(u).Groups[1].Value
                };
            })
            .Where(u => u.Price > MinWeaponPrice)
            .OrderBy(u => u.Price);

    private IEnumerable<string> GetRawItems()
        => new Regex("<a class=\"market_listing_row_link\"(.+?\n)+?</a>")
            .Matches(_rawData)
            .Select(u => u.Groups[0].Value);
}