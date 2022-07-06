using System.Globalization;

namespace HighSchoolShared.Exceptions.GradeExceptions
{
    public class InvalidSubjectCatalogIdBadRequestException : Exception
    {
        public InvalidSubjectCatalogIdBadRequestException() : base() { }

        public InvalidSubjectCatalogIdBadRequestException(string message) : base(message) { }

        public InvalidSubjectCatalogIdBadRequestException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
