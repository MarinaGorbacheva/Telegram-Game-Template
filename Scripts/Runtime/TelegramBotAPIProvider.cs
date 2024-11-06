namespace Agava.TelegramGameTemplate
{
    public static class TelegramBotAPIProvider
    {
        private static ITelegramBotAPI _telegramBotAPI;

        public static ITelegramBotAPI TelegramBotAPI
        {
            get
            {
                if (_telegramBotAPI == null)
                {
                    _telegramBotAPI = new MockTelegramBotAPI();
                }

                return _telegramBotAPI;
            }

            set
            {
                if (_telegramBotAPI == null)
                {
                    _telegramBotAPI = value;
                }
            }
        }

        public static void Initialize(ITelegramBotAPI telegramBotAPI)
        {
            TelegramBotAPI = telegramBotAPI;
        }
    }
}
