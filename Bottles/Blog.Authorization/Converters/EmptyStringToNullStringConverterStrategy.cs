using FubuCore.Conversion;

namespace ExtendHealth.AdminSuite.Core.Converters
{
    public class EmptyStringToNullStringConverterStrategy : StatelessConverter<string>
    {
        public const string EMPTY = "EMPTY";
        public const string BLANK = "BLANK";

        protected override string convert(string text)
        {
            var stringValue = text;
            if (stringValue == BLANK || stringValue == EMPTY)
            {
                return string.Empty;
            }

            if (stringValue == ObjectConverter.NULL || stringValue == string.Empty)
            {
                return null;
            }

            return stringValue;
        }
    }
}