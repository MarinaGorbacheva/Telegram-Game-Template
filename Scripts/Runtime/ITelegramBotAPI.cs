using Agava.TelegramGameTemplate.Utils;
using System;
using System.Collections.Generic;

namespace Agava.TelegramGameTemplate
{
    public interface ITelegramBotAPI
    {
        bool BotAvailable { get; }
        void CallApiMethod(string methodName, RequestType requestType, Action<Response> onResponse = null);
        bool TryGetAppUri(string appName, out string appUrl, Dictionary<string, object> parametersDictionary = null);
        bool TryGetStartParameters(string webAppUri, out Dictionary<string, string> parametersDictionary);
    }
}
