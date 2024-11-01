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
                return null;

            if (httpRequest == null)
                return null;

            return new TelegramBotClient(botToken, httpRequest);
        }

        public static string ExtractBotToken()
        {
            BotToken botToken = Resources.Load<BotToken>(BotTokenAssetName);

            return botToken == null ? string.Empty : botToken.Value;
        }

        public static string ExtractAppName()
        {
            AppName appName = Resources.Load<AppName>(AppNameAssetName);

            return appName == null ? string.Empty : appName.Value;
        }

        public static string ConstructShareLinkURL(string shareUrl, string shareMessage)
        {
            return $"https://t.me/share/url?url={shareUrl}&text={shareMessage}";
        }
    }
}
