using Dapper;
using DapperORM.SubjectsRepository.Dtos;

namespace DapperORM.SubjectsRepository
{
    public interface ISubjectRepository
    {
        AllSubjectsDto GetAllSubjects();
        SubjectByIdDto GetSubjectByID(int id);
    }

    public class GetSubjectRepository : ISubjectRepository
    {
        private readonly IDapperRepository _repository;

        public GetSubjectRepository(IDapperRepository repository)
        {
            _repository = repository;
        }

        public SubjectByIdDto GetSubjectByID(int id)
        {
            var storedProcedureParameters = new DynamicParameters();
            storedProcedureParameters.Add("@ID", id, System.Data.DbType.Int32);

            var response = new SubjectByIdDto();

            _repository.QueryStoredProcedure("dbo.GetSubjectById", (reader) =>
            {
                response = reader.Read<SubjectByIdDto>().FirstOrDefault();
            }, parameters: storedProcedureParameters);
            return response;
        }

        public AllSubjectsDto GetAllSubjects()
        {
            var response = new AllSubjectsDto();
            _repository.QueryStoredProcedure("dbo.GetAllSubjects", (reader) =>
            {
                response.SubjectsDto = reader.Read<SubjectByIdDto>();
            });
            return response;
        }
    }
}
