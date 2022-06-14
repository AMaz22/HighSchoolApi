using FluentValidation;
using StudentFeature.CreateStudent;

namespace StudentFeature.CreateStudent
{
    public class StudentModelValidator: AbstractValidator<StudentModel>
    {
        public StudentModelValidator()
        {
            RuleFor(stud => stud.FullName)
                .NotNull().WithMessage("Student name cannot be null")
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(1, 50).WithMessage("Name cannot exceed 50 characters");
            RuleFor(stud => stud.StudentYear)
                .NotNull().WithMessage("Subject name cannot be null")
                .NotEmpty().WithMessage("Name cannot be empty");
                
        }
    }
}
