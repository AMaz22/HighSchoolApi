using FluentValidation;

namespace GradeFeatures.CreateGrade
{
    public class AddGradeRequestDataValidator: AbstractValidator<AddGradeModel>
    {
        public AddGradeRequestDataValidator()
        {
            RuleFor(model => model.GradeScore)
                .InclusiveBetween(1.00m, 10.00m).WithMessage("Invalid grade score.");
        }
    }
}
