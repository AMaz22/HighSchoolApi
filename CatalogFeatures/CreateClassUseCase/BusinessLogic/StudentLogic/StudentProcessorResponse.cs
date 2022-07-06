namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic
{
    public class StudentProcessorResponse
    {
        public int CatalogId { get; set; }

        public string Name { get; set; }

        public int StudentYear { get; set; }

        public bool IsValidData { get; set; }

        public string ErrorMessage { get; set; }

    }
}
