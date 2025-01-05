using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                     .WithMessage("Lutfen urun adini nos gecmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                     .WithMessage("Lutfen urun adini 5 ile 150 arasinda giriniz");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                     .WithMessage("Lutfen stok bilgisini bos gecmeyiniz")
                .Must(s => s >= 0)
                     .WithMessage("Stok bilgisi negatif olamaz");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                     .WithMessage("Lutfen fiyat bilgisini bos gecmeyiniz")
                .Must(s => s >= 0)
                     .WithMessage("Fiyat bilgisi negatif olamaz");

        }
    }
}
