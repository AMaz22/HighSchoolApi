namespace CatalogFeatures.DataRelatedToCatalogUseCase
{
    public class CatalogRelatedDataModel
    {
        public List<DataRelatedToCatalogDetails> Details { get; set; }
    }

    public class DataRelatedToCatalogDetails
    {
        public string StudentName { get; set; }

        public int StudentID { get; set; }

        public decimal GradeScore { get; set; }

        public string SubjectName { get; set; }

        public string NameOfClass { get; set; }

        public string ClassCicle { get; set; }
    }
}
