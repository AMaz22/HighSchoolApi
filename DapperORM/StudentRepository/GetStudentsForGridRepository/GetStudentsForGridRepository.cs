using Dapper;

namespace DapperORM.StudentRepository.GetStudentsForGridRepository
{
    public interface IGetStudentsForGridRepository
    {
        Task<StudentsDto> GetAsync(int pageIndex, int pageSize, string orderColumn, string orderType);
    }

    public class GetStudentsForGridRepository : IGetStudentsForGridRepository
    {
        private readonly IDapperRepository _repository;

        public GetStudentsForGridRepository(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentsDto> GetAsync(int pageIndex, int pageSize,
            string orderColumn, string sortOrderType)
        {
            var storedProcedureParameters = new DynamicParameters();
            storedProcedureParameters.Add("@PageIndex", pageIndex);
            storedProcedureParameters.Add("@PageSize", pageSize);
            storedProcedureParameters.Add("@SortedOrder", orderColumn);
            storedProcedureParameters.Add("@SortedColumn", sortOrderType);
            

            var response = new StudentsDto();
            await _repository.QueryStoredProcedureAsync("dbo.SelectStudentsForGrid", (reader) =>
            {
                response.StudentDetails = reader.Read<StudentDetails>().ToList();

            }, parameters: storedProcedureParameters);
            return response;
        }
    }
}
