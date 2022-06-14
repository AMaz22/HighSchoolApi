using AutoMapper;
using EntityFrameworkORM.Models;
using Microsoft.Extensions.Logging;

namespace SubjectFeatures.SubjectToCatalogFeature
{
    public class AssignSubjectToCatalog : IAssignSubjectToCatalog
    {
        private readonly IMapper _mapper;
        private readonly HighSchoolContext _context;
        private readonly ILogger<AssignSubjectToCatalog> _logger;

        public AssignSubjectToCatalog(HighSchoolContext context, IMapper mapper, ILogger<AssignSubjectToCatalog> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task Assign(SubjectCatalogModel model)
        {
            var entity = _mapper.Map<SubjectsCatalog>(model);
            var query = _context.SubjectsCatalogs
                .Where(r => r.SubjectId == entity.SubjectId && r.CatalogId == entity.CatalogId)
                .FirstOrDefault();
            if (query == null)
            {
                await _context.SubjectsCatalogs.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("The catalog has the subject added.");
            }
        }
    }
}
