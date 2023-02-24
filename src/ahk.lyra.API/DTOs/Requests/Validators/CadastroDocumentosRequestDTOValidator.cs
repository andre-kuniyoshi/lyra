using FluentValidation;

namespace ahk.lyra.API.DTOs.Requests.Validators
{
    public class CadastroDocumentosRequestDTOValidator : AbstractValidator<DocumentoRequestDTO>
    {
        public CadastroDocumentosRequestDTOValidator()
        {
            RuleFor(u => u.Numero)
              .NotEmpty()
                      .WithMessage("Campo não pode ser nulo ou vazio.")
              .Length(3, 12)
                      .WithMessage("O tamanho do campo {PropertyName} é de: {MinLength} a {MaxLength} caracteres.");

            RuleFor(u => u.TipoDocumento)
                .NotEmpty()
                        .WithMessage("Campo não pode ser nulo ou vazio.")
                .IsInEnum()
                        .WithMessage("O campo {PropertyName} precisa ser um enum: 1 - Cpf e 2 - Rg.");
        }
    }
}
