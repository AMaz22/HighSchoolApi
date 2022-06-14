namespace DapperORM.CatalogsRepository.ClassJoinCatalogUseCase
{
    public class ClassJoinCatalogDto
    {
        public int ClassID { get; set; }
        public int CatalogID { get; set; }
        public int CurrentYear { get; set; }
        public string NameOfClass { get; set; } = string.Empty;
        public string ClassCicle { get; set; } = string.Empty;
        public bool ActiveCatalog { get; set; }
    }
}
