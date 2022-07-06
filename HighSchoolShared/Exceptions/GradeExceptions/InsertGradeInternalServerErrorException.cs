using System.Globalization;

namespace HighSchoolShared.Exceptions.GradeExceptions
{
    public class InsertGradeInternalServerErrorException : Exception
    {
        public InsertGradeInternalServerErrorException() : base() { }

        public InsertGradeInternalServerErrorException(string message) : base(message) { }

        public InsertGradeInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
