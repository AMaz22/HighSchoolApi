using System.Globalization;

namespace HighSchoolShared.Exceptions.CatalogExceptions
{
    public class GetCatalogByIdNotFoundException: Exception
    {
        public GetCatalogByIdNotFoundException() : base() { }

        public GetCatalogByIdNotFoundException(string message) : base(message) { }

        public GetCatalogByIdNotFoundException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
