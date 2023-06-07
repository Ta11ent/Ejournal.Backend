namespace Enews.WebApi.Validations
{
    public class UpdateNewsValidation : AbstractValidator<UpdateNewsDto>
    {
        public UpdateNewsValidation() {
            RuleFor(x => x.HeadLine).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        }
    }
}
