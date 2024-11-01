using Agava.TelegramGameTemplate.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Networking;

namespace Agava.TelegramGameTemplate.Tests
{
    internal class EmptyComponent : MonoBehaviour, ICoroutine { }

    public class HttpRequestTests
    {
        [Test]
        public void SendRequest_URLExists_ReturnsTrue()
        {
            ICoroutine monoBehaviour = new GameObject().AddComponent<EmptyComponent>();

            HttpRequest httpRequest = new HttpRequest(monoBehaviour);

            httpRequest.SendRequest("https://www.google.com/", RequestType.GET, onResponse: (response) =>
            {
                Assert.Equals(response.statusCode, UnityWebRequest.Result.Success);
            });
        }
    }
}
