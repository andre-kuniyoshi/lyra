using FluentValidation;

namespace ahk.lyra.API.DTOs.Requests.Validators
{
    public class AtualizaUsuarioRequestDTOValidator : AbstractValidator<AtualizaUsuarioRequestDTO>
    {
        public AtualizaUsuarioRequestDTOValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo.")
                .Length(3, 80)
                        .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Idade)
                .NotNull()
                        .WithMessage("Campo não pode ser nulo.")
                .InclusiveBetween(0, 100)
                        .WithMessage("O campo {PropertyName} tem que ter valor entre {From} e {To}");

            RuleFor(u => u.Sexo)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo.")
                .Length(2, 50)
                        .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");
        }
    }
}
