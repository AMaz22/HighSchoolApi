using System.Globalization;

namespace HighSchoolShared.Exceptions.GradeExceptions
{
    public class AddGradeInvalidDataBadRequestException : Exception
    {
        public AddGradeInvalidDataBadRequestException() : base() { }

        public AddGradeInvalidDataBadRequestException(string message) : base(message) { }

        public AddGradeInvalidDataBadRequestException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
