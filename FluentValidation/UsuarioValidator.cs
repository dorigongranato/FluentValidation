using FluentValidation.APi;

namespace FluentValidation.API;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        //RuleFor(p => p.Nome).NotNull().NotEmpty().WithMessage("Informa o nome ai meu anjo");

        RuleFor(x => x.Nome).Cascade(CascadeMode.Stop).NotNull().NotEqual("foo")
            .WithMessage("Precisa ter o foo escrito.");

    }
}

