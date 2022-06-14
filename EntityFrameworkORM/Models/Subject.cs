using System;
using System.Collections.Generic;

namespace EntityFrameworkORM.Models
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectsCatalogs = new HashSet<SubjectsCatalog>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<SubjectsCatalog> SubjectsCatalogs { get; set; }
    }
}
