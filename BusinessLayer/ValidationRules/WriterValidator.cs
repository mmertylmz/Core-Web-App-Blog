using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Kısmı Boş Geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden küçük olamaz.")
                .MaximumLength(16).WithMessage("Şifre 16 karakterden büyük olamaz.")
                .Matches(@"[A-Z]+").WithMessage("Şifrede en az bir büyük harf olmalıdır.")
                .Matches(@"[a-z]+").WithMessage("Şifrede en az bir küçük harf olmalıdır.")
                .Matches(@"[0-9]+").WithMessage("Şifrede en az bir rakam olmalıdır")
                .Matches(@"[\!\?\*\.]+").WithMessage("Şifrede en az bir sembol olmalıdır. '?','*','.','!')");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Dosya Yolu Boş olamaz");

        }
    }
}
