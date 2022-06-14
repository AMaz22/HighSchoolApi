namespace SubjectFeatures.GetSubjects
{
    public interface IGetSubject
    {
        GetSubjectDto GetSubjectById(int id = 1);
    }
}