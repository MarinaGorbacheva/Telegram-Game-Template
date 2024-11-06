using Agava.SmartLogger;
using System;
using System.Collections;
using UnityEngine.Networking;

namespace Agava.TelegramGameTemplate.Utils
{
    public class HttpRequest : IHttpRequest
    {
        private ICoroutine _coroutine;
        private int? _timeOut;

        public HttpRequest(ICoroutine coroutine, int? timeOut = null)
        {
            _coroutine = coroutine;
            _timeOut = timeOut;
        }

        public void SendRequest(string url, RequestType requestType, Action<Response> onResponse = null)
        {
            _coroutine.StartCoroutine(Processing());

            IEnumerator Processing()
            {
                using UnityWebRequest request = new UnityWebRequest(url, requestType.ToString());
                request.downloadHandler = new DownloadHandlerBuffer();

                if (_timeOut.HasValue)
                {
                    request.timeout = _timeOut.Value;
                }

                yield return request.SendWebRequest();

                LogRequestResult(request);
                onResponse?.Invoke(new Response(request.result, request.downloadHandler.text));
            }
        }

        private void LogRequestResult(UnityWebRequest request)
        {
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    {
                        Log.LogSuccessfulMessage($"Request {request.url} succeed. Status code: {request.responseCode}");
                        break;
                    }
                case UnityWebRequest.Result.InProgress:
                    {
                        Log.LogInfoMessage($"Request {request.url} is in process.");
                        break;
                    }
                default:
                    {
                        Log.LogErrorMessage($"Request {request.url} failed. Status code: {request.responseCode}");
                        break;
                    }
            }
        }
    }
}
