using CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests;
using FluentValidation;

namespace CatalogFeatures.CreateClassUseCase
{
    public class ClassCatalogRequestValidator: AbstractValidator<UseCaseMainRequest>
    {
        public ClassCatalogRequestValidator()
        {
            RuleFor(request => request.ClassModel)
                .NotNull().WithMessage("Class model cannot be null.");

            RuleFor(request => request.ClassModel.CurrentYear)
                .InclusiveBetween(9, 12).WithMessage("Year input invalid.");
            
        }
    }
}
