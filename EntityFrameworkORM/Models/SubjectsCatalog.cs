using System;
using System.Collections.Generic;

namespace EntityFrameworkORM.Models
{
    public partial class SubjectsCatalog
    {
        public SubjectsCatalog()
        {
            AveragesGrades = new HashSet<AveragesGrade>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public int? CatalogId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Catalog? Catalog { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<AveragesGrade> AveragesGrades { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
