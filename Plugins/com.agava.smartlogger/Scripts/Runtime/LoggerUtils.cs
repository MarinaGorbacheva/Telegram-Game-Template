using System.Text;
using UnityEngine;

namespace Agava.SmartLogger
{
    public static class LoggerUtils
    {
        public static string ApplyColor(string targetString, Color color)
        {
            string firstPart = $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>";
            string secondPart = "</color>";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendJoin("", firstPart, targetString, secondPart);

            return stringBuilder.ToString();
        }
    }
}
