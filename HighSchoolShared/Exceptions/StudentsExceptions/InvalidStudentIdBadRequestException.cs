using System.Globalization;

namespace HighSchoolShared.Exceptions.StudentsExceptions
{
    public class InvalidStudentIdBadRequestException : Exception
    {
        public InvalidStudentIdBadRequestException() : base() { }

        public InvalidStudentIdBadRequestException(string message) : base(message) { }

        public InvalidStudentIdBadRequestException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
