//using FluentValidation;
//using igreja.Application.DTOs.MyTask;

//namespace igreja.Application.Validators
//{
//    public class MyTaskDtoValidator : AbstractValidator<MyTaskDto>
//    {
//        public MyTaskDtoValidator()
//        {
//            RuleFor(t => t.Title)
//                .NotEmpty().WithMessage("O título é obrigatório.")
//                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

//            RuleFor(t => t.Description)
//                .NotEmpty().WithMessage("A descrição é obrigatória.")
//                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");

//            RuleFor(t => t.DueDate)
//                .GreaterThan(DateTime.Now).WithMessage("A data de vencimento deve ser no futuro.");
//        }
//    }
//}
