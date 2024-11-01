using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.SmartLogger;

namespace Agava.TelegramGameTemplate.Utils
{
    public class SceneLoader
    {
        public static AsyncOperation LoadingSceneOperation { get; private set; } = null;

        public static bool IsSceneLoading => LoadingSceneOperation == null ? false : LoadingSceneOperation.isDone == false;

        public static bool TryLoadScene(Scene sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            return TryLoadScene(sceneName.name, loadSceneMode);
        }

        public static bool TryLoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                Log.LogErrorMessage("Scene name could not be empty.");
                return false;
            }

            if (IsSceneLoading)
            {
                Log.LogErrorMessage($"Could not load the scene \"{sceneName}\". Another scene is already loading.");
                return false;
            }

            LoadingSceneOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
            Log.LogSuccessfulMessage($"Loading scene \"{sceneName}\".");
            return true;
        }
    }
}
