using Agava.TelegramGameTemplate.Utils;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Agava.TelegramGameTemplate.Tests
{
    public class SceneLoaderTests
    {
        [UnitySetUp]
        public IEnumerator Setup_WaitLoadingEnd()
        {
            yield return new WaitWhile(() => SceneLoader.IsSceneLoading);
        }

        [UnityTest]
        public IEnumerator TryLoadScene_SceneNameIsEmpty_ReturnsFalse()
        {
            bool result = SceneLoader.TryLoadScene(string.Empty);
            Assert.IsFalse(result);

            yield return new WaitWhile(() => SceneLoader.IsSceneLoading);
        }

        [UnityTest]
        public IEnumerator TryLoadScene_WhileLoadingScene_ReturnsFalse()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneLoader.TryLoadScene(scene);

            bool result = SceneLoader.TryLoadScene(scene);
            Assert.IsFalse(result);

            yield return new WaitWhile(() => SceneLoader.IsSceneLoading);
        }

        [UnityTest]
        public IEnumerator TryLoadScene_SceneIsValid_ReturnsTrue()
        {
            Scene scene = SceneManager.GetActiveScene();

            bool result = SceneLoader.TryLoadScene(scene);
            Assert.IsTrue(result);

            yield return new WaitWhile(() => SceneLoader.IsSceneLoading);
        }
    }
}
