namespace GradeFeatures.CreateGrade.Comands
{
    public class InsertedGradeModel
    {
        public int Id { get; set; }
        public DateTime GradeDate { get; set; }
        public decimal GradeScore { get; set; }
        public int? SubjectCatalogId { get; set; }
        public int? StudentId { get; set; }
    }
}
