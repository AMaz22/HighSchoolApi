namespace DapperORM.CatalogsRepository.CatalogRelatedDataUseCase
{
    public class CatalogRelatedDataDto
    {
        public List<CatalogDetails> Details { get; set; }

        public CatalogRelatedDataDto()
        {
            Details = new List<CatalogDetails>();
        }
    }

    public class CatalogDetails
    {
        public string StudentName { get; set; }

        public int StudentID { get; set; }

        public decimal GradeScore { get; set; }

        public string SubjectName { get; set; }

        public string NameOfClass { get; set; }

        public string ClassCicle { get; set; }
    }
}
