using FluentValidation;
using ProjetoAula04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Validations
{
    /// <summary>
    /// Classe para validação dos dados do funcionário.
    /// </summary>
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        /// <summary>
        /// Método construtor para implementar as
        /// validações do funcionário
        /// </summary>
        public FuncionarioValidator()
        {
            //validações do campo 'Id'
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Por favor, informe o ID do funcionário.");

            //validações do campo 'Nome'
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Por favor, informe o nome do funcionário.")
                .Length(8, 150).WithMessage("Por favor, informe o nome do funcionário de 8 a 150 caracteres.");

            //validações do campo 'Cpf'
            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage("Por favor, informe o cpf do funcionário.")
                .Matches(@"^\d{11}$").WithMessage("Por favor, informe o cpf com exatamente 11 números.");

            //validações do campo 'Salario'
            RuleFor(f => f.Salario)
                .GreaterThan(0).WithMessage("Por favor, informe o salário com valor maior do que zero.");

            //validações do campo 'Tipo' (enum)
            RuleFor(f => f.Tipo)
                .IsInEnum().WithMessage("Por favor, informe um tipo de contratação válido (1, 2 ou 3).");
        }
    }
}
