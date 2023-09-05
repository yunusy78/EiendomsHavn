using EindomsHavnAPI.DTOs.CategoryDtos;
using FluentValidation;

namespace Business.ValidationRules;

public class CategoryValidator : AbstractValidator<CreateCategoryDto>

{
    
public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Category name cannot be empty");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Category name must be at least 2 characters");
        RuleFor(x => x.Name).MaximumLength(25).WithMessage("Category name must be at most 25 characters");
        RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("Description must be at least 3 characters");
        RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Description must be at most 200 characters");

    }
    
    
}