using Agava.SmartLogger;
using Agava.TelegramGameTemplate.Utils;
using UnityEngine;

namespace Agava.TelegramGameTemplate
{
    public static class TelegramUtils
    {
        private const string BotTokenAssetName = "BotToken";
        private const string AppNameAssetName = "AppName";

        public static ITelegramBotClient CreateBotClient(string botToken, IHttpRequest httpRequest)
        {
            if (string.IsNullOrEmpty(botToken))
            {
                Log.LogErrorMessage("Bot token shouldn't be empty.");
                return null;
            }

            if (httpRequest == null)
            {
                Log.LogErrorMessage("HttpRequest shouldn't be empty.");
                return null;
            }

            return new TelegramBotClient(botToken, httpRequest);
        }

        public static string ExtractBotToken()
        {
            BotToken botToken = Resources.Load<BotToken>(BotTokenAssetName);

            if (botToken == null)
            {
                Log.LogErrorMessage($"Couldn't find {BotTokenAssetName}.asset file in Resources.");
                return string.Empty;
            }

            return botToken.Value;
        }

        public static string ExtractAppName()
        {
            AppName appName = Resources.Load<AppName>(AppNameAssetName);

            if (appName == null)
            {
                Log.LogErrorMessage($"Couldn't find {AppNameAssetName}.asset file in Resources.");
                return string.Empty;
            }

            return appName.Value;
        }

        public static string ConstructShareLinkURL(string shareUrl, string shareMessage)
        {
            return $"https://t.me/share/url?url={shareUrl}&text={shareMessage}";
        }
    }
}
