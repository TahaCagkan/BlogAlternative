using BlogAlternative.EntityLayer.Concrete;
using FluentValidation;

namespace BlogAlternative.BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez!");
			RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Ad ve Soyad alanı 3 karakterden küçük olamaz!");
            RuleFor(x => x.WriterName).MaximumLength(100).WithMessage("Ad ve Soyad alanı 100 karakterden büyük olamaz!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez!");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
        }
	}
}
