namespace DapperORM.StudentRepository.GetStudentsForGridRepository
{
    public class StudentsDto
    {
        public List<StudentDetails> StudentDetails { get; set; }
        
        public StudentsDto()
        {
            StudentDetails = new List<StudentDetails>();
        }
    }
    public class StudentDetails
    {
        public int ID { get; set; }

        public string StudentName { get; set; }

        public int StudentYear { get; set; }

        public int CatalogID { get; set; }
    }
}
