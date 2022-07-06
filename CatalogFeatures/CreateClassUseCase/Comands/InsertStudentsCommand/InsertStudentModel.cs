namespace CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand
{
    public class InsertStudentModel
    {
        public int StudentId { get; set; }
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public int StudentCurrentYear { get; set; }
    }
}
