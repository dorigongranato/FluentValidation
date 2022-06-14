namespace FluentValidation.Entity;

public class PessoaValidator : AbstractValidator<Pessoa>
{
    public PessoaValidator()
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().WithMessage("Informa o nome ai meu anjo 2 ");

        RuleFor(p => p.Nome).MinimumLength(4).WithMessage("Precisa de 4 bytes ");

        RuleFor(x => x.Nome).NotNull().NotEqual("foo").WithMessage("Escreveu foo.");

        RuleFor(x => x.Idade).GreaterThanOrEqualTo(18).WithMessage("A idade deve ser igual ou maior que 18.");

    }
}