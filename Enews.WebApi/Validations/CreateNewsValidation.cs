namespace Enews.WebApi.Validations
{
    public class CreateNewsValidation : AbstractValidator<CreateNewsDto>
    {
        public CreateNewsValidation() {
            RuleFor(x => x.HeadLine).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.File.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("the downloaded file must have the format jpeg/jpg/png");
        }
    }
}
