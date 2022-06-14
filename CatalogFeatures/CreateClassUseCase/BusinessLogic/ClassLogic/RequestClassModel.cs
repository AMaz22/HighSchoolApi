namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public class RequestClassModel
    {
        public int CurrentYear { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
    }
}
