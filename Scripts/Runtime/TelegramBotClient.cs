using Agava.SmartLogger;
using Agava.TelegramGameTemplate.Utils;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace Agava.TelegramGameTemplate
{
    public class TelegramBotClient : ITelegramBotClient
    {
        private readonly string _apiURL;
        private readonly IHttpRequest _httpRequest;

        public bool Initialized { get; private set; }
        public User User { get; private set; } = null;
        public bool BotResponsive => User != null;

        public TelegramBotClient(string botToken, IHttpRequest httpRequest)
        {
            _apiURL = $"https://api.telegram.org/bot{botToken}";
            _httpRequest = httpRequest;

            GetMe();
        }

        public void CallApiMethod(string methodName, RequestType requestType, Action<Response> onResponse = null)
        {
            string requestUrl = $"{_apiURL}/{methodName}";
            _httpRequest.SendRequest(requestUrl, requestType, onResponse: onResponse);
        }

        private void GetMe()
        {
            if (Initialized)
            {
                Log.LogInfoMessage("Bot already initialized!");
                return;
            }

            Initialized = false;

            CallApiMethod("getMe", RequestType.GET, onResponse: (response) =>
            {
                if (response.statusCode == UnityWebRequest.Result.Success)
                {
                    try
                    {
                        GetMeResponse getMeResponse = JsonConvert.DeserializeObject<GetMeResponse>(response.body);
                        User = getMeResponse.result;
                        Log.LogSuccessfulMessage($"Successfully converted json string to User.");
                    }
                    catch (Exception ex)
                    {
                        Log.LogErrorMessage($"Couldn't convert json string to User. [{ex.Source}]: {ex.Message})");
                    }
                }
                else
                {
                    Log.LogErrorMessage("Request failed.");
                }

                Initialized = true;
            });
        }

        [Serializable, Preserve]
        internal class GetMeResponse
        {
            public bool ok;
            public User result;
        }
    }
}
