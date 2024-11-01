using UnityEngine;
using System.Collections;

namespace Agava.TelegramGameTemplate.Utils
{
    public interface ICoroutine
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}
