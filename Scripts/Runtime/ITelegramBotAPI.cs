using System.Collections.Generic;

namespace Agava.TelegramGameTemplate
{
    public interface ITelegramBotAPI
    {
        bool BotAvailable { get; }
        bool TryGetAppUri(string appName, out string appUrl, Dictionary<string, object> parametersDictionary = null);
        bool TryGetStartParameters(string webAppUri, out Dictionary<string, string> parametersDictionary);
    }
}
