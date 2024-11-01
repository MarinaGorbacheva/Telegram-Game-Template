namespace Agava.TelegramGameTemplate
{
    public interface ITelegramBotAPI
    {
        bool BotAvailable { get; }
        bool TryGetAppUrl(string appName, out string appUrl, string startParam = null);
    }
}
