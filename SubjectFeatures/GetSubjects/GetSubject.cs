using AutoMapper;
using DapperORM.SubjectsRepository;

namespace SubjectFeatures.GetSubjects
{
    public class GetSubject : IGetSubject
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _repository;

        public GetSubject(IMapper mapper, ISubjectRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public GetSubjectDto GetSubjectById(int id = 1)
        {
            var query = _repository.GetSubjectByID(id);
            var result = _mapper.Map<GetSubjectDto>(query);
            if (result != null)
            {
                return result;
            }
            return new GetSubjectDto();
        }
        public GetSubjectDto GetAllTheSubjects()
        {
            var query = _repository.GetAllSubjects();
            var result = _mapper.Map<GetSubjectDto>(query);
            
            return new GetSubjectDto();
        }
    }
}
