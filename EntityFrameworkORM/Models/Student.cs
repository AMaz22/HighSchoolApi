namespace EntityFrameworkORM.Models
{
    public partial class Student
    {
        public Student()
        {
            AveragesGrades = new HashSet<AveragesGrade>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int StudentYear { get; set; }
        public int? CatalogId { get; set; }

        public virtual Catalog? Catalog { get; set; }
        public virtual ICollection<AveragesGrade> AveragesGrades { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
