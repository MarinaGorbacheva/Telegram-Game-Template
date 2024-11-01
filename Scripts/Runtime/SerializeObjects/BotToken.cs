using UnityEngine;

namespace Agava.TelegramGameTemplate
{
    [CreateAssetMenu(fileName = "BotToken", menuName = "Create BotToken.asset file", order = 51)]
    internal class BotToken : ScriptableObject
    {
        [field: SerializeField] public string Value { get; private set; }
    }
}
