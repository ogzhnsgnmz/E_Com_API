using ECom.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz")
                .Must(s => s >= 0)
                    .WithMessage("Stock bilgisi 0 veya daha büyük olmalıdır.");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz")
                .Must(s => s >= 0)
                    .WithMessage("Fiyat 0 veya daha büyük olmalıdır.");
        }
    }
}
