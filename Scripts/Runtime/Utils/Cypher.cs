namespace Agava.TelegramGameTemplate.Utils
{
    public static class Cypher
    {
        public static string Encode(string plainString, string key)
        {
            return Base64Encode(plainString);
        }

        public static string Decode(string encodedString, string key)
        {
            return Base64Decode(encodedString);
        }

        private static string Base64Encode(string plainString)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainString);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string encodedString)
        {
            byte[] base64EncodedBytes = System.Convert.FromBase64String(encodedString);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
