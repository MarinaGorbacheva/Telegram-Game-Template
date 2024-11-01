using UnityEngine;

namespace Agava.TelegramGameTemplate
{
    [CreateAssetMenu(fileName = "AppName", menuName = "Create AppName.asset file", order = 52)]
    internal class AppName : ScriptableObject
    {
        [field: SerializeField] public string Value { get; private set; }
    }
}
