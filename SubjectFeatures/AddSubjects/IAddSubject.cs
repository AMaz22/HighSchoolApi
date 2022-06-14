namespace SubjectFeatures.AddSubjects
{
    public interface IAddSubject
    {
        Task<bool> AddAsync(SubjectModel model);
    }
}