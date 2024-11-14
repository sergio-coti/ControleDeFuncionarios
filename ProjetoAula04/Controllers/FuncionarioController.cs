using ProjetoAula04.Entities;
using ProjetoAula04.Enums;
using ProjetoAula04.Repositories;
using ProjetoAula04.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    /// <summary>
    /// Classe de controle para realizar os fluxos de ações de funcionário.
    /// </summary>
    public class FuncionarioController
    {
        /// <summary>
        /// Método para realizar o cadastro do funcionário
        /// </summary>
        public void CadastrarFuncionario()
        {
            Console.WriteLine("\n*** CADASTRO DE FUNCIONÁRIO: ***\n");

            //criando um objeto da classe Funcionário
            var funcionario = new Funcionario();

            Console.Write("INFORME O NOME DO FUNCIONÁRIO..........: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("INFORME O CPF DO FUNCIONÁRIO...........: ");
            funcionario.Cpf = Console.ReadLine();

            Console.Write("INFORME O SALÁRIO DO FUNCIONÁRIO.......: ");
            funcionario.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\t(1) ESTÁGIO");
            Console.WriteLine("\t(2) CLT");
            Console.WriteLine("\t(3) TERCEIRIZADO");
            Console.Write("INFORME O TIPO (1, 2 ou 3).............: ");
            funcionario.Tipo = (TipoContratacao) int.Parse(Console.ReadLine());

            #region Validação dos dados do funcionário

            //instanciando a classe de validação do funcionário
            var funcionarioValidator = new FuncionarioValidator();

            //aplicando as regras de validação no objeto 'funcionario'
            var result = funcionarioValidator.Validate(funcionario);

            //verificar se o funcionário passou nas validações
            if(result.IsValid)
            {
                //instanciando a classe de repositório JSON
                var funcionarioRepositoryJson = new FuncionarioRepositoryJson();
                funcionarioRepositoryJson.ExportarDados(funcionario);,
                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO EM ARQUIVO JSON!");

                //instanciando a classe de repositório SQL
                var funcionarioRepositorySql = new FuncionarioRepositorySql();
                funcionarioRepositorySql.ExportarDados(funcionario);
                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO EM ARQUIVO SQL!");
            }
            else
            {
                Console.WriteLine("\nOCORRERAM ERROS DE VALIDAÇÃO:");

                //percorrendo todos os erros de validação encontrados
                foreach (var item in result.Errors)
                {
                    //imprimindo cada mensagem de erro de validação obtida
                    Console.WriteLine(item.ErrorMessage);
                }
            }

            #endregion
        }
    }
}
