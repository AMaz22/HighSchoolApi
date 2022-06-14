using System;
using System.Collections.Generic;

namespace EntityFrameworkORM.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public DateTime GradeDate { get; set; }
        public decimal GradeScore { get; set; }
        public int? SubjectCatalogId { get; set; }
        public int? StudentId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual SubjectsCatalog? SubjectCatalog { get; set; }
    }
}
