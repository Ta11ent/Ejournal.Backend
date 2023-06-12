namespace Enews.WebApi.Validations
{
    public class UpdateNewsFileValidation : AbstractValidator<UpdateNewsFileDto>
    {
        public UpdateNewsFileValidation() {
            RuleFor(x => x.File.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                   .WithMessage("the downloaded file must have the format jpeg/jpg/png");
        }
    }
}
