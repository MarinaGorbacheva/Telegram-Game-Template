using static UnityEngine.Networking.UnityWebRequest;

namespace Agava.TelegramGameTemplate
{
    public class Response
    {
        public Response(Result statusCode, string body)
        {
            this.statusCode = statusCode;
            this.body = body;
        }

        public Result statusCode { get; private set; }
        public string body { get; private set; }
    }
}
