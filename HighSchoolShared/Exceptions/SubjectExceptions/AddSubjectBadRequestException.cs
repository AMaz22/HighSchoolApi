using System.Globalization;

namespace HighSchoolShared.Exceptions.SubjectExceptions
{
    public class AddSubjectBadRequestException : Exception
    {
        public AddSubjectBadRequestException() : base() { }

        public AddSubjectBadRequestException(string message) : base(message) { }
        public AddSubjectBadRequestException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
