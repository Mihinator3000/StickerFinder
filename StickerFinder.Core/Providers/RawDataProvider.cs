using StickerFinder.Domain.Exceptions;

namespace StickerFinder.Core.Providers;

public class RawDataProvider
{
    public string? RequestLink { get; set; }

    public async Task<string> GetRawDataAsync()
    {
        if (RequestLink is null)
            throw new InvalidLinkException();

        using var client = new HttpClient();
        return await client.GetStringAsync(RequestLink);
    }
}

