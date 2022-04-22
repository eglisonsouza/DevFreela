using Devfreela.Aplication.Commands.CreateComment;
using FluentValidation;

namespace Devfreela.Aplication.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("Tamnho máximo de texto de comentário é de 255 caracteres");
        }
    }
}
