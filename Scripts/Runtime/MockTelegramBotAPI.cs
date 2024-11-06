using System.Collections.Generic;

namespace Agava.TelegramGameTemplate
{
    public class MockTelegramBotAPI : ITelegramBotAPI
    {
        public bool BotAvailable => false;

        public bool TryGetAppUri(string appName, out string appUrl, Dictionary<string, object> parametersDictionary = null)
        {
            appUrl = string.Empty;
            return false;
        }

        public bool TryGetStartParameters(string webAppUri, out Dictionary<string, string> parametersDictionary)
        {
            parametersDictionary = null;
            return false;
        }
    }
}
