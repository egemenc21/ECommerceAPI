using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Validators.Products;

public class CreateProductValidator : AbstractValidator<VM_Create_Product>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please do not pass product name empty")
            .MaximumLength(150)
            .MinimumLength(5)
            .WithMessage("Please keep the characters length between 5 and 150");

        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please do not pass product name empty")
            .Must(s => s >= 0)
            .WithMessage("Stock can not be negative");
        
        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please do not pass product name empty")
            .Must(s => s >= 0)
            .WithMessage("Price can not be negative");
    }
}