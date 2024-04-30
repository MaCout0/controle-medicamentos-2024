using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Bem-vindo {Environment.MachineName}");

            TelaMedicameto novaTelaMedicamento = new();
            TelaPaciente novaTelaPaciente = new();
            TelaRequisicao novaTelaRequisicao = new(novaTelaMedicamento, novaTelaPaciente);


            while (true)
            {
                Console.WriteLine("Por favor escolha a opcao desejada \n" +
                     "1- Gerenciar Medicamentos \n" +
                     "2- Gerenciar Pacientes \n" +
                     "3- Gerenciar Requisicoes \n" +
                     "4- Sair");
                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        novaTelaMedicamento.ExibeMenuMedicamento();

                        break;

                    case 2:
                        Console.Clear();
                        novaTelaPaciente.ExibeMenuPaciente();
                        break;

                    case 3:
                        Console.Clear();
                        novaTelaRequisicao.ExibeMenuRequisicao();
                        break;

                    case 4:
                        Console.WriteLine("Pressione qualquer tecla para sair");
                        Console.ReadLine();

                        return;
                }
            }
        }
    }
}
