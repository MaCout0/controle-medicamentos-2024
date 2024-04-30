using ControleMedicamentos.ConsoleApp.Bases;
using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string nome;
        public string descricao;
        public int quantidade;

        public Medicamento(string? nome, string? descricao, int quantidade)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
        }

        public Medicamento()
        {

        }

        public string[] Validar()
        {
            Contador contadorErros = new();
            string[] erros = new string[1];

            if (quantidade == 0)
            {
                erros[contadorErros.valorContador] = "Quantidade invalida, por favor, edite esta informação";
                contadorErros.IncrementaContador();
            }

            string[] errosFiltrados = new string[contadorErros.valorContador];

            Array.Copy(erros, errosFiltrados, contadorErros.valorContador);

            return errosFiltrados;
        }
    }
}
