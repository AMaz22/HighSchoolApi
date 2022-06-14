using System;
using System.Collections.Generic;

namespace EntityFrameworkORM.Models
{
    public partial class Class
    {
        public Class()
        {
            Catalogs = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string NameOfClass { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CurrentYear { get; set; }
        public string ClassCicle { get; set; } = null!;

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
