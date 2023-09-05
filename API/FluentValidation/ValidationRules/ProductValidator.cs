using EindomsHavnAPI.DTOs.ProductDtos;
using FluentValidation;

namespace Business.ValidationRules;

public class ProductValidator:AbstractValidator<ResultProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Category name cannot be empty");
        RuleFor(x => x.Title).MinimumLength(2).WithMessage("Category name must be at least 2 characters");
        RuleFor(x => x.Title).MaximumLength(25).WithMessage("Category name must be at most 25 characters");
        RuleFor(x=>x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters");
        RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Description must be at most 2000 characters");
     
        
    }
    
}