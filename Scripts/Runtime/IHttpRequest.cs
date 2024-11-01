using System;

namespace Agava.TelegramGameTemplate.Utils
{
    public enum RequestType { POST, GET, PUT }

    public interface IHttpRequest
    {
        void SendRequest(string url, RequestType requestType, Action<Response> onResponse = null);
    }
}
