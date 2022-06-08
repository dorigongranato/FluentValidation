namespace FluentValidation.Entity;

public class PessoaValidator : AbstractValidator<Pessoa>
{
    public PessoaValidator()
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().WithMessage("Informa o nome ai meu anjo");
    }
}