using Agava.TelegramGameTemplate.Utils;
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Agava.TelegramGameTemplate.Tests
{
    public class TelegramBotAPITests
    {
        [Test]
        public void Constructor_ClientIsNotNull_DoesNotThrowException()
        {
            IHttpRequest httpRequest = new FakeHttpRequest();

            string botToken = TelegramUtils.ExtractBotToken();
            ITelegramBotClient botClient = TelegramUtils.CreateBotClient(botToken, httpRequest);

            Assert.DoesNotThrow(() => new TelegramBotAPI(botClient));
        }

        [Test]
        public void Constructor_ClientIsNull_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new TelegramBotAPI(null));
        }

        [UnityTest]
        public IEnumerator BotAvailable_BotDoesNotExist_ReturnsFalse()
        {
            IHttpRequest httpRequest = new HttpRequest(new GameObject().AddComponent<EmptyComponent>());

            ITelegramBotClient botClient = TelegramUtils.CreateBotClient("not a token", httpRequest);
            ITelegramBotAPI telegramBotAPI = new TelegramBotAPI(botClient);

            yield return new WaitUntil(() => botClient.Initialized);

            bool botAvailable = telegramBotAPI.BotAvailable;
            Assert.IsFalse(botAvailable);
        }
    }
}
