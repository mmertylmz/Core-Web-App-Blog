using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını boş geçemezsiniz.")
                .MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın.")
                .MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriğini boş geçemezsiniz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görselini boş geçemezsiniz.");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog küçük resmi boş olamaz.");
            RuleFor(x => x.CategoryID).NotEqual(0).WithMessage("Kategori Seçiniz");
           
        }
    }
}
