using ControleMedicamentos.ConsoleApp.Bases;
using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        public string nome;
        public string CPF;
        public string endereco;
        public string cartaoSUS;

        public Paciente(string? nome, string? CPF, string? endereco, string? cartaoSUS)
        {
            this.nome = nome;
            this.CPF = CPF;
            this.endereco = endereco;
            this.cartaoSUS = cartaoSUS;
        }

        public string[] Validar()
        {
            Contador contadorErros = new();
            string[] erros = new string[3];

            if (string.IsNullOrEmpty(nome))
            {
                erros[contadorErros.valorContador] = "Por favor, insira um nome";
                contadorErros.IncrementaContador();
            }
            if (!(CPF.Length == 11))
            {
                erros[contadorErros.valorContador] = "Por favor, insira um CPF valido";
                contadorErros.IncrementaContador();
            }
            if (!(cartaoSUS.Length == 15))
            {
                erros[contadorErros.valorContador] = "Por favor, insira um NUMERO de cartao SUS valido";
                contadorErros.IncrementaContador();
            }

            string[] errosFiltrados = new string[contadorErros.valorContador];

            Array.Copy(erros, errosFiltrados, contadorErros.valorContador);


            return errosFiltrados;
        }
    }
}
