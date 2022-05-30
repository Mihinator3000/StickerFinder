// Sevar botClient = new TelegramBotClient("{YOUR_ACCESS_TOKEN_HERE}");

using StickerFinder.Core.Generators;
using StickerFinder.Core.Parsers;
using StickerFinder.Core.Providers;
using StickerFinder.Domain.Dto;
using Telegram.Bot;

var stickers = new List<StickerDto>()
{
    new()
    {
        Name = "Sticker | Titan | Katowice 2014",
        Price = 200000
    }
};

new []
{
    "Sticker | Team LDLC.com (Holo) | Katowice 2014",
    "Sticker | Reason Gaming (Holo) | Katowice 2014",
    "Sticker | Titan (Holo) | Katowice 2014",
    "Sticker | HellRaisers (Holo) | Katowice 2014",
    "Sticker | LGB eSports (Holo) | Katowice 2014",
    "Sticker | iBUYPOWER | Katowice 2014",
    "Sticker | iBUYPOWER (Holo) | Katowice 2014",
    "Sticker | mousesports (Holo) | Katowice 2014",
    "Sticker | Clan-Mystik (Holo) | Katowice 2014",
    "Sticker | Virtus.Pro (Holo) | Katowice 2014",
    "Sticker | Natus Vincere (Holo) | Katowice 2014",
    "Sticker | Team Dignitas (Holo) | Katowice 2014",
    "Sticker | Vox Eminor (Holo) | Katowice 2014",
    "Sticker | compLexity Gaming (Holo) | Katowice 2014",
    "Sticker | 3DMAX (Holo) | Katowice 2014",
    "Sticker | Reason Gaming | Katowice 2014"

}.ToList().ForEach(u => stickers.Add(new StickerDto {Name = u}));



var botClient = new TelegramBotClient("");

using var cts = new CancellationTokenSource();

int count = 0;
while (true)
{
    foreach (var sticker in stickers)
    {
        string requestLink = new LinkGenerator(sticker).GetRequestLink();

        string rawData;

        try
        { 
            rawData = await new RawDataProvider { RequestLink = requestLink }.GetRawDataAsync();
            count++;
        }
        catch (Exception)
        {
            Console.WriteLine(count);
            return;
        }

        WeaponDto? weapon = new RawDataParser(rawData).GetCheapestWeapon();

        if (weapon is null)
        {
            Console.WriteLine("No items?");
            continue;
        }

        if (weapon.Price * (decimal)67.27 < 3000)
            await botClient.SendTextMessageAsync("", $"{weapon.Name} {weapon.Price} {weapon.Link}", disableWebPagePreview: true);

        Console.WriteLine($"{sticker.Name}  ->  {weapon.Name} {weapon.Price} \n{weapon.Link}\n");

        Thread.Sleep(1000);
    }

    Thread.Sleep(300000);
}


/*
// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

new TelegramBotClient()

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();
*/
