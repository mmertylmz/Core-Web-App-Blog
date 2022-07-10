using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.")
                .MaximumLength(50).WithMessage("Kategori Adı 50 karakterden fazla olamaz.")
                .MinimumLength(2).WithMessage("Kategori adı en az 2 Karakter olmalıdır.");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Geçemezsiniz.");
        }
    }
}
