using System;

namespace Agava.TelegramGameTemplate.Utils
{
    public class FakeHttpRequest : IHttpRequest
    {
        public void SendRequest(string url, RequestType requestType, Action<Response> onResponse = null)
        {
            onResponse?.Invoke(new Response(UnityEngine.Networking.UnityWebRequest.Result.ConnectionError, string.Empty));
        }
    }
}
