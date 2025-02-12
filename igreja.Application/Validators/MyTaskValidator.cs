using FluentValidation;
using igreja.Domain.Models;

namespace igreja.Application.Validations
{
    public class MyTaskValidator : AbstractValidator<MyTask>
    {
        public MyTaskValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
                .MaximumLength(100).WithMessage("O título não pode ter mais de 100 caracteres.");

            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("A descrição da tarefa é obrigatória.")
                .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");

            RuleFor(t => t.CompletionDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A data de vencimento não pode ser no passado.");

            RuleFor(t => t.UserId)
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.");
        }
    }
}
