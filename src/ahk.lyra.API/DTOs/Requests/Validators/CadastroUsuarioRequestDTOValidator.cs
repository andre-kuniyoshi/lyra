using FluentValidation;

namespace ahk.lyra.API.DTOs.Requests.Validators
{
    public class CadastroUsuarioRequestDTOValidator : AbstractValidator<CadastroUsuarioRequestDTO>
    {
        public CadastroUsuarioRequestDTOValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .Length(3, 80)
                        .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Idade)
                .NotNull()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .InclusiveBetween(0, 100)
                        .WithMessage("O campo {PropertyName} tem que ter valor entre {From} e {To}");

            RuleFor(u => u.Sexo)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .Length(3, 50)
                        .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty()
                    .WithMessage("Campo não pode ser nulo ou vazio.")
                .Length(3, 120)
                    .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres")
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                    .WithMessage("O Email informado no campo {PropertyName} esta invalido.");

            RuleFor(u => u.Endereco)
                .NotNull()
                    .WithMessage("Campo não pode ser nulo ou vazio.")
                .SetValidator(new CadastroEnderecoRequestDTOValidator());

            RuleFor(u => u.Documentos)
                .NotNull()
                    .WithMessage("Campo não pode ser nulo ou vazio.");
            RuleForEach(u => u.Documentos)
                .SetValidator(new CadastroDocumentosRequestDTOValidator());


            RuleFor(u => u.Telefones)
                .NotNull()
                    .WithMessage("Campo não pode ser nulo ou vazio.");

            RuleForEach(u => u.Telefones)
                .SetValidator(new CadastroTelefoneRequestDTOValidator());
        }
    }
}
