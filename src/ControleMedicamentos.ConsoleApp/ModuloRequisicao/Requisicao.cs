using ControleMedicamentos.ConsoleApp.Bases;
using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : EntidadeBase
    {
        public string medicamento;
        public string paciente;
        public int quantidade;
        public string dataValidade;

        public Requisicao(string? medicamento, string? paciente, int quantidade, string? dataValidade)
        {
            this.medicamento = medicamento;
            this.paciente = paciente;
            this.quantidade = quantidade;
            this.dataValidade = dataValidade;
        }

        public string[] Validar()
        {
            Contador contadorErros = new();
            string[] erros = new string[3];
            if (string.IsNullOrEmpty(medicamento))
            {
                erros[contadorErros.valorContador] = "Por favor, informe o MEDICAMENTO solicitado";
                contadorErros.IncrementaContador();
            }

            if (string.IsNullOrEmpty(paciente))
            {
                erros[contadorErros.valorContador] = "Por favor, informe o PACIENTE solicitante";
                contadorErros.IncrementaContador();
            }

            if (quantidade == 0)
            {
                erros[contadorErros.valorContador] = "QUANTIDADE invalida";
                contadorErros.IncrementaContador();
            }

            string[] errosFiltrados = new string[contadorErros.valorContador];

            Array.Copy(erros, errosFiltrados, contadorErros.valorContador);

            return errosFiltrados;
        }
    }
}
