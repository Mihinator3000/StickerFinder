using StickerFinder.Core.Generators;
using StickerFinder.Core.Parsers;
using StickerFinder.Core.Providers;
using StickerFinder.Domain.Dto;

var sticker = new StickerDto
{
    Name = "Sticker | Titan | Katowice 2014",
    Price = 200000
};

string requestLink = new LinkGenerator(sticker).GetRequestLink();

Console.WriteLine(requestLink);

string rawData = await new RawDataProvider{RequestLink = requestLink}.GetRawDataAsync();
/*Console.WriteLine(dataString);*/

/*WeaponDto weapon = new RawDataParser(rawData).GetCheapestWeapon();
Console.WriteLine(weapon);*/

new RawDataParser(rawData).GetCheapestWeapons(100).ToList().ForEach(u => 
    Console.WriteLine(u.Name + " " + u.Price));