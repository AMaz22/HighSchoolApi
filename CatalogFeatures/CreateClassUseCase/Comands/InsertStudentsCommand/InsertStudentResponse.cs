namespace CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand
{
    public class InsertStudentResponse
    {
        public InsertStudentModel Student {get; set;} 
        public bool Inserted { get; set; }
        public string ErrorMessage { get; set; }
    }
}
