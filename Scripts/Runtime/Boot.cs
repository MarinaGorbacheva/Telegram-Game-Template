using Agava.SmartLogger;
using Agava.TelegramGameTemplate.Utils;
using System.Collections;
using UnityEngine;

namespace Agava.TelegramGameTemplate
{
    [DefaultExecutionOrder(-1000)]
    public class Boot : MonoBehaviour, ICoroutine
    {
        private const float InitializationTimeOut = 60;

        [SerializeField] private int _operationsTimeOut = 20;
        [SerializeField] private string _startScene = "Sample";

        private IEnumerator Start()
        {
            DontDestroyOnLoad(this);

            yield return Initialize();
            SceneLoader.TryLoadScene(_startScene);
        }

        private IEnumerator Initialize()
        {
            HttpRequest httpRequest = new HttpRequest(this, _operationsTimeOut);

            string botToken = TelegramUtils.ExtractBotToken();
            ITelegramBotClient botClient = TelegramUtils.CreateBotClient(botToken, httpRequest);

            TelegramBotAPI telegramBotApi = new TelegramBotAPI(botClient);
            TelegramBotAPIProvider.Initialize(telegramBotApi);

            float waitingTime = 0.0f;

            while (true)
            {
                if (botClient.Initialized && botClient.BotResponsive)
                {
                    Log.LogSuccessfulMessage("Boot initialized.");
                    break;
                }

                waitingTime += Time.unscaledDeltaTime;

                if (waitingTime >= InitializationTimeOut)
                {
                    Log.LogErrorMessage("Time expired! Boot not initialized.");
                    break;
                }

                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }
    }
}
