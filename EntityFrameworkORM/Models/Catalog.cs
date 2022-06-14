namespace EntityFrameworkORM.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            Students = new HashSet<Student>();
            SubjectsCatalogs = new HashSet<SubjectsCatalog>();
        }

        public int Id { get; set; }
        public int CurrentYear { get; set; }
        public bool? ActiveCatalog { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SubjectsCatalog> SubjectsCatalogs { get; set; }
    }
}
