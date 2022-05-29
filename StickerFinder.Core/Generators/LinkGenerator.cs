using System.Collections.Specialized;
using System.Web;
using StickerFinder.Domain.Dto;
using StickerFinder.Domain.Exceptions;

namespace StickerFinder.Core.Generators;

public class LinkGenerator
{
    private const string SteamMarketSearchLink = "https://steamcommunity.com/market/search";

    private const string SearchQueryKey = "q";

    private static readonly IReadOnlyCollection<(string, string)> QueryDefaultParams
        = new List<(string, string)> 
        {
            ("appid", "730"),
            ("category_730_Weapon[]", "any"),
            ("descriptions", "1"),
            ("sort_column", "price"),
            ("sort_dir", "asc")
        };

    private readonly StickerDto _sticker;

    public LinkGenerator(StickerDto sticker)
        => _sticker = sticker;
    
    public string GetRequestLink()
    {
        var builder = new UriBuilder(SteamMarketSearchLink)
        {
            Query = GetQuery()
        };

        return builder.ToString();
    }

    private string GetQuery()
    {
        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

        foreach ((string key, string value) in QueryDefaultParams)
            query[key] = value;

        query[SearchQueryKey] = GetQuotedName();

        return query.ToString() ?? throw new InvalidLinkException();
    }

    private string GetQuotedName()
        => $"\"{_sticker.Name}\"";
}