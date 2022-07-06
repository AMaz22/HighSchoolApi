using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentForPaginationFeature
{
    public class StudentGridModel
    {
        public List<StudentUIDetails> StudentUIDetails { get; set; }
    }
    public class StudentUIDetails
    {
        public int ID { get; set; }

        public string StudentName { get; set; }

        public int CatalogID { get; set; }

        public int StudentYear { get; set; }
    }
}
