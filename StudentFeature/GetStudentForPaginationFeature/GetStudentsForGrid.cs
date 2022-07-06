using AutoMapper;
using DapperORM.StudentRepository.GetStudentsForGridRepository;

namespace StudentFeature.GetStudentForPaginationFeature
{
    public interface IGetStudentsForGrid
    {
        Task<StudentGridModel> GetAsync(int pageIndex, int pageSize, string sortColumn, string orderType);
    }
    public class GetStudentsForGrid : IGetStudentsForGrid
    {
        private readonly IGetStudentsForGridRepository _repository;
        private readonly IMapper _mapper;

        public GetStudentsForGrid(IGetStudentsForGridRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StudentGridModel> GetAsync(int pageIndex, int pageSize, 
            string orderColumn, string sortOrderType)
        {
            var result = await _repository.GetAsync(pageIndex, pageSize, orderColumn, sortOrderType);
            
            var response = _mapper.Map<StudentGridModel>(result);

            return response;
        }
    }
}
