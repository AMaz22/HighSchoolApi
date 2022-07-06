namespace CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand
{
    public class InsertCatalogResponse
    {
        public InsertCatalogModel CatalogModel { get; set; }

        public bool Inseted { get; set; }

        public string ErrorMessage { get; set; }
    }
}
