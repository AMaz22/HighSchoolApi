namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public class ProcessorClassModel
    {
        public string NameOfClass { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentYear { get; set; }
        public string ClassCicle { get; set; } = string.Empty;
    }
}
