using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkınızda Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.WriterMail).NotEmpty() .WithMessage("Mail Adresi Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Kısmı Boş Geçilemez");
        }
    }
}
