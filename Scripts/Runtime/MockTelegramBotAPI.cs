namespace Agava.TelegramGameTemplate
{
    public class MockTelegramBotAPI : ITelegramBotAPI
    {
        public bool BotAvailable => false;

        public bool TryGetAppUrl(string appName, out string appUrl, string startParam = null)
        {
            appUrl = string.Empty;
            return false;
        }
    }
}
