namespace Agava.TelegramGameTemplate
{
    public struct QueryParam
    {
        public QueryParam(string parameter, string value)
        {
            Parameter = parameter;
            Value = value;
        }

        public string Parameter { get; private set; }
        public string Value { get; private set; }
    }
}
