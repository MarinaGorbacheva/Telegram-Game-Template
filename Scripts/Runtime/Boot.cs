using Agava.SmartLogger;
using Agava.TelegramGameTemplate.Utils;
using System.Collections;
using UnityEngine;

namespace Agava.TelegramGameTemplate
{
    public class Boot : MonoBehaviour, ICoroutine
    {
        [SerializeField] private int _operationsTimeOut = 20;
        [SerializeField] private string _startScene = "Sample";

        private const float InitializationTimeOut = 60;

        private bool _initialized = true;

        private IEnumerator Start()
        {
            DontDestroyOnLoad(this);

            yield return Initialize();

            if (_initialized)
            {
                SceneLoader.TryLoadScene(_startScene);
            }
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
                _initialized = botClient.Initialized && botClient.BotResponsive;

                if (_initialized)
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
