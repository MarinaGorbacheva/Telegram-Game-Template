using Agava.SmartLogger;
using System;
using System.Linq;
using System.Text;

namespace Agava.TelegramGameTemplate
{
    public static class WebAppURI
    {
        public static string ConstructQueryString(QueryParam[] parameters = null)
        {
            string result = string.Empty;

            if (parameters != null)
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < parameters.Length; i++)
                {
                    string firstChar = i == 0 ? "?" : "&";

                    stringBuilder.Append($"{firstChar}{parameters[i].Parameter}={parameters[i].Value}");
                }

                result = stringBuilder.ToString();
            }

            return result;
        }

        public static string ConstructWebAppUri(string botName, string appName, QueryParam[] parameters = null)
        {
            string queryString = ConstructQueryString(parameters);

            return $"https://t.me/{botName}/{appName}" + queryString;
        }

        public static bool TryExtractQueryParams(string webAppUri, out QueryParam[] parameters, char separator = '&')
        {
            if (string.IsNullOrEmpty(webAppUri))
            {
                Log.LogErrorMessage("Web app uri cannot be empty!");
            }
            else
            {
                if (webAppUri.IndexOf('?') == -1)
                {
                    Log.LogInfoMessage("URI has no query string.");
                }
                else
                {
                    string queryString = webAppUri.Split('?')[1];
                    Log.LogInfoMessage($"Query string: {queryString}");

                    try
                    {
                        parameters = queryString
                            .Split(separator)
                            .Select(queryParameter => queryParameter.Split('='))
                            .Select(pair => new QueryParam(pair[0], pair[1]))
                            .ToArray();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogErrorMessage($"Couldn't parse the query string. {ex.Source}: {ex.Message}");
                    }
                }
            }

            parameters = null;
            return false;
        }
    }
}
