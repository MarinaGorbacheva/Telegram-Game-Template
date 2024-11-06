using System.Collections;
using UnityEngine;

namespace Agava.TelegramGameTemplate.Utils
{
    public interface ICoroutine
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}
