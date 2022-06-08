using FluentValidation.APi;

namespace FluentValidation.API;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().WithMessage("Informa o nome ai meu anjo");
    }
}

