using System;
using System.Collections.Generic;

namespace EntityFrameworkORM.Models
{
    public partial class AveragesGrade
    {
        public int Id { get; set; }
        public decimal AverageGradeScore { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectCatalogId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual SubjectsCatalog? SubjectCatalog { get; set; }
    }
}
