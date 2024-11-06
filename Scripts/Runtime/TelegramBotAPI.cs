using Agava.SmartLogger;
using Agava.TelegramGameTemplate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agava.TelegramGameTemplate
{
    public class TelegramBotAPI : ITelegramBotAPI
    {
        private const string StartParam = "startapp";
        private const string EncodedStartParam = "tgWebAppStartParam";

        private ITelegramBotClient _botClient;

        public bool BotAvailable => _botClient == null ? false : _botClient.Initialized && _botClient.BotResponsive;

        public TelegramBotAPI(ITelegramBotClient botClient)
        {
            _botClient = botClient;

            if (_botClient == null)
            {
                throw new ArgumentNullException(nameof(botClient));
            }
        }

        public bool TryGetAppUri(string appName, out string appUrl, Dictionary<string, object> parametersDictionary = null)
        {
            if (BotAvailable)
            {
                QueryParam[] parameters = parametersDictionary?.Select(pair => new QueryParam(pair.Key, pair.Value.ToString())).ToArray();
                string queryString = WebAppURI.ConstructQueryString(parameters);

                parameters = EncodeStartAppParameters(queryString);

                appUrl = WebAppURI.ConstructWebAppUri(_botClient.User.username, appName, parameters);
                Log.LogSuccessfulMessage($"Main app url of the bot constructed: {appUrl}");
                return true;
            }
            else
            {
                appUrl = string.Empty;
                Log.LogErrorMessage($"Bot is not available. Couldn't construct main app url.");
                return false;
            }
        }

        public bool TryGetStartParameters(string webAppUri, out Dictionary<string, string> parametersDictionary)
        {
            bool success = WebAppURI.TryExtractQueryParams(webAppUri, out QueryParam[] parameters, separator: '#');
            parametersDictionary = null;

            if (success)
            {
                parameters = DecodeStartAppParameters(parameters);

                if (parameters != null)
                {
                    parametersDictionary = parameters.ToDictionary(queryParam => queryParam.Parameter, queryParam => queryParam.Value);
                }
            }

            return parametersDictionary != null;
        }

        private QueryParam[] EncodeStartAppParameters(string queryString)
        {
            QueryParam[] encodedQueryParams = null;

            if (string.IsNullOrEmpty(queryString) == false)
            {
                string encodedString = Cypher.Encode(queryString, _botClient.User.id.ToString());
                encodedQueryParams = new QueryParam[1] { new QueryParam(StartParam, encodedString) };
            }

            return encodedQueryParams;
        }

        private QueryParam[] DecodeStartAppParameters(QueryParam[] parameters)
        {
            QueryParam encodedQueryParams = parameters.Where(queryParam => queryParam.Parameter == EncodedStartParam).FirstOrDefault();

            if (encodedQueryParams.Parameter == EncodedStartParam)
            {
                string encodedParams = encodedQueryParams.Value;
                string decodedQueryString = Cypher.Decode(encodedParams, _botClient.User.id.ToString());

                if (WebAppURI.TryExtractQueryParams(decodedQueryString, out QueryParam[] decodedQueryParams))
                {
                    return decodedQueryParams;
                }
            }

            return null;
        }
    }
}
