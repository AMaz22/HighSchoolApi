namespace DapperORM.SubjectsRepository.Dtos
{
    public class AllSubjectsDto
    {
        public IEnumerable<SubjectByIdDto> SubjectsDto { get; set; } = null!;
    }
}
