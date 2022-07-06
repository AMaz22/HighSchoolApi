using System.Globalization;

namespace HighSchoolShared.Exceptions.CatalogExceptions
{
    public class CreateClassBadRequestException : Exception
    {
        public CreateClassBadRequestException() : base() { }

        public CreateClassBadRequestException(string message) : base(message) { }

        public CreateClassBadRequestException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
