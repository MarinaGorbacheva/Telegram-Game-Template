using Agava.TelegramGameTemplate.Utils;
using System;

namespace Agava.TelegramGameTemplate
{
    public interface ITelegramBotClient
    {
        bool Initialized { get; }
        User User { get; }
        bool BotResponsive { get; }

        void CallApiMethod(string methodName, RequestType requestType, Action<Response> onResponse = null);
    }
}
