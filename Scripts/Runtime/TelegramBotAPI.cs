using Agava.SmartLogger;
using System;

namespace Agava.TelegramGameTemplate
{
    public class TelegramBotAPI : ITelegramBotAPI
    {
        private ITelegramBotClient _botClient;

        public bool BotAvailable => _botClient == null ? false : _botClient.Initialized && _botClient.BotResponsive;

        public TelegramBotAPI(ITelegramBotClient botClient)
        {
            _botClient = botClient;

            if (_botClient == null)
                throw new ArgumentNullException(nameof(botClient));
        }

        public bool TryGetAppUrl(string appName, out string appUrl, string startParam = null)
        {
            if (_botClient.Initialized && _botClient.BotResponsive)
            {
                appUrl = $"https://t.me/{_botClient.User.username}/{appName}";

                if (string.IsNullOrEmpty(startParam) == false)
                    appUrl += $"?start_param={startParam}";

                Log.LogSuccessfulMessage($"Main app url of the bot constructed: {appUrl}");
                return true;
            }
            else
            {
                appUrl = string.Empty;
                Log.LogErrorMessage($"Couldn't construct main app url.");
                return false;
            }
        }
    }
}
