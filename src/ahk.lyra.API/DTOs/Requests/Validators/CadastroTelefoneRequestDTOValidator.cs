using FluentValidation;

namespace ahk.lyra.API.DTOs.Requests.Validators
{
    public class CadastroTelefoneRequestDTOValidator : AbstractValidator<TelefoneRequestDTO>
    {
        public CadastroTelefoneRequestDTOValidator()
        {
            RuleFor(u => u.DDD)
               .NotEmpty()
                       .WithMessage("Campo não pode ser nulo ou vazio.")
               .Length(1, 3)
                       .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Numero)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .Length(1, 10)
                       .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.TipoTelefone)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .IsInEnum()
                        .WithMessage("O campo {PropertyName} precisa ser um enum: 1 - telefone e 2 - Celular.");
        }
    }
}
