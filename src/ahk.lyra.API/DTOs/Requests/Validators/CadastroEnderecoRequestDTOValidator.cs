using FluentValidation;

namespace ahk.lyra.API.DTOs.Requests.Validators
{
    public class CadastroEnderecoRequestDTOValidator : AbstractValidator<EnderecoRequestDTO>
    {
        public CadastroEnderecoRequestDTOValidator()
        {
            RuleFor(u => u.Logradouro)
               .NotEmpty()
                       .WithMessage("Campo não pode ser nulo ou vazio.")
               .Length(3, 200)
                       .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Numero)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .Length(1, 10)
                       .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Complemento)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .Length(3, 100)
                        .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Cidade)
               .NotEmpty()
                       .WithMessage("Campo não pode ser nulo ou vazio.")
               .Length(3, 50)
                       .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Cep)
               .NotEmpty()
                       .WithMessage("Campo não pode ser nulo ou vazio.")
               .Length(1, 8)
                       .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");
        }
    }
}
