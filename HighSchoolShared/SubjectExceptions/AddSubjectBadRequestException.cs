namespace HighSchoolShared.SubjectExceptions
{
    public class AddSubjectBadRequestException : Exception
    {
        public AddSubjectBadRequestException() : base() { }

        public AddSubjectBadRequestException(string message) : base(message) { }
    }
}
