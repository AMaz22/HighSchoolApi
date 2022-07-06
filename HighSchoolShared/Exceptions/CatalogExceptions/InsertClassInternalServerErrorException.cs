using System.Globalization;

namespace HighSchoolShared.Exceptions.CatalogExceptions
{
    public class InsertClassInternalServerErrorException : Exception
    {
        public InsertClassInternalServerErrorException() : base() { }

        public InsertClassInternalServerErrorException(string message) : base(message) { }

        public InsertClassInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
