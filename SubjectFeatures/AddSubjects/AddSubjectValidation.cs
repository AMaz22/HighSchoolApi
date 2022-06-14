using FluentValidation;

namespace SubjectFeatures.AddSubjects
{
    public class AddSubjectValidation : AbstractValidator<SubjectModel>
    {
        public AddSubjectValidation()
        {
            RuleFor(ad => ad.SubjectName)
                .NotNull().WithMessage("Subject name cannot be null")
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(1, 50).WithMessage("Name cannot exceed 50 characters");
        }
    }
}
