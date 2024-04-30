using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaBase
    {
        RepositorioPaciente novoRepositorio = new RepositorioPaciente();

        public void ExibeMenuPaciente()
        {
            modulo = "Paciente";
            cor = ConsoleColor.Blue;

            switch (MenuSelecao(modulo, cor))
            {
                case 1:
                    Console.Clear();
                    Paciente NovoPaciente = ObterPaciente();
                    string[] erros = NovoPaciente.Validar();

                    novoRepositorio.CadastraPaciente(NovoPaciente);

                    if (erros.Length > 0)
                    {
                        ApresentaErros(erros);
                        return;
                    }
                    Mensagem.ConteudoMensagem("Paciente cadastrado com sucesso", ConsoleColor.Green);

                    ExibeMenuPaciente();
                    break;

                case 2:
                    Console.Clear();
                    ExibePaciente();

                    ExibeMenuPaciente();
                    break;

                case 3:
                    Console.Clear();

                    ExibePaciente();
                    Console.WriteLine("Por favor, informe o ID do paciente para EDITAR");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Paciente pacienteEditado = ObterPaciente();
                    novoRepositorio.EditaPaciente(pacienteEditado, id);

                    Console.Clear();
                    Mensagem.ConteudoMensagem("Informações alteradas com sucesso!", ConsoleColor.Yellow);
                    ExibeMenuPaciente();
                    break;

                case 4:
                    Console.Clear();

                    ExibePaciente();
                    Console.WriteLine("Por favor, informe o ID do paciente para Remover");
                    id = Convert.ToInt32(Console.ReadLine());
                    novoRepositorio.DeletaPaciente(id);

                    Console.Clear();
                    Mensagem.ConteudoMensagem("Paciente removido com sucesso!", ConsoleColor.Red);
                    ExibeMenuPaciente();
                    break;
            }
        }

        public Paciente ObterPaciente()
        {
            Console.WriteLine("Informe o NOME do paciente");
            string nome = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Informe o CPF do paciente (Apenas numeros)");
            string CPF = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Informe o ENDERECO do paciente");
            string endereco = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Informe o Cartao SUS do paciente (Apenas numeros)");
            string cartaoSUS = Convert.ToString(Console.ReadLine());

            return new Paciente(nome, CPF, endereco, cartaoSUS);
        }

        public void ExibePaciente()
        {
            Paciente[] registroPaciente = novoRepositorio.SelecionaRegistroPaciente();

            Console.WriteLine(
             "{0, -10} | {1,-15} | {2,-15} | {3, -10} | {4, -15}",
             "ID", "Nome", "CPF", "Endereco", "Cartao SUS"
             );

            for (int i = 0; i < registroPaciente.Length; i++)
            {
                if (registroPaciente[i] != null)
                    Console.WriteLine(
                        "{0, -10} | {1,-15} | {2,-15} | {3, -10} | {4, -15}",
                        registroPaciente[i].id, registroPaciente[i].nome, registroPaciente[i].CPF, registroPaciente[i].endereco, registroPaciente[i].cartaoSUS
                        );
            }
        }

    }
}
