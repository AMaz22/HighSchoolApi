namespace CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand
{
    public class InsertClassResponse
    {
        public InsertClassModel ClassModel { get; set; }

        public bool Inserted { get; set; }

        public string ErrorMessage { get; set; }
    }
}
