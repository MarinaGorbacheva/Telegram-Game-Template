using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Agava.SmartLogger
{
    public static class Log
    {
        private static readonly Color InfoMessageColor = Color.grey;
        private static readonly Color ErrorMessageColor = Color.red;
        private static readonly Color SuccessfulMessageColor = Color.green;
        private static readonly Color WarningMessageColor = Color.yellow;

        public static void LogInfoMessage(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string callerName = "")
        {
            LogMessage(message, filePath, callerName, InfoMessageColor);
        }

        public static void LogSuccessfulMessage(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string callerName = "")
        {
            LogMessage(message, filePath, callerName, SuccessfulMessageColor);
        }

        public static void LogWarningMessage(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string callerName = "")
        {
            LogMessage(message, filePath, callerName, WarningMessageColor);
        }

        public static void LogErrorMessage(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string callerName = "")
        {
            LogMessage(message, filePath, callerName, ErrorMessageColor);
        }

        private static void LogMessage(string message, string filePath, string callerName, Color color)
        {
#if UNITY_EDITOR || ENABLE_LOGGER
            string fileName = Path.GetFileName(filePath);

#if UNITY_EDITOR
            message = LoggerUtils.ApplyColor(message, color);
#endif

            Debug.Log($"[{fileName}: {callerName}] {message}");
#endif
        }
    }
}
