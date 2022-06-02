using AzureAPI.Domain.Entity;
using FluentValidation;

namespace AzureAPI.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .NotNull()
                .WithMessage("O nome não pode ser nulo")

                .MinimumLength(3)
                .WithMessage("O nome deve ter pelo menos 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio")

                .NotNull()
                .WithMessage("O email não pode ser nulo")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email escrito não é um email válido")

                .MaximumLength(80)
                .WithMessage("O email deve ter no máximo 80 caracteres");

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("O password não pode ser vazio")

               .NotNull()
               .WithMessage("O password não pode ser nulo")

               .MinimumLength(3)
               .WithMessage("O password deve ter pelo menos 3 caracteres")

               .MaximumLength(80)
               .WithMessage("O password deve ter no máximo 80 caracteres");
        }
    }
}
