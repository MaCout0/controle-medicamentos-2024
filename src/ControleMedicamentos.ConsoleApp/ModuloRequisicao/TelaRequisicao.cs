using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao : TelaBase
    {
        RepositorioRequisicao novoRepositorio = new RepositorioRequisicao();
        private TelaMedicameto novaTelaMedicamento;
        private TelaPaciente novaTelaPaciente;

        public TelaRequisicao(TelaMedicameto novaTelaMedicamento, TelaPaciente novaTelaPaciente)
        {
            this.novaTelaMedicamento = novaTelaMedicamento;
            this.novaTelaPaciente = novaTelaPaciente;
        }

        public void ExibeMenuRequisicao()
        {
            modulo = "Requisicao";
            cor = ConsoleColor.DarkYellow;

            switch (MenuSelecao(modulo, cor))
            {
                case 1:
                    Console.Clear();
                    Requisicao novaRequisicao = ObterRequisicao();
                    string[] erros = novaRequisicao.Validar();

                    novoRepositorio.CadastraRequisicao(novaRequisicao);

                    if (erros.Length > 0)
                    {
                        ApresentaErros(erros);
                        return;
                    }

                    Mensagem.ConteudoMensagem("Requisição efetuada com sucesso!", ConsoleColor.Green);

                    ExibeMenuRequisicao();
                    break;

                case 2:
                    Console.Clear();
                    ExibeRequisicao();

                    ExibeMenuRequisicao();
                    break;

                case 3:
                    Console.Clear();

                    ExibeRequisicao();
                    Console.WriteLine("Informe o ID da REQUISICAO a ser EDITADA");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Requisicao editaRequisicao = ObterRequisicao();
                    novoRepositorio.EditaRequisicao(editaRequisicao, id);

                    Console.Clear();
                    Mensagem.ConteudoMensagem("Informações alteradas com sucesso", ConsoleColor.Yellow);
                    ExibeMenuRequisicao();
                    break;

                case 4:
                    Console.Clear();

                    ExibeRequisicao();
                    Console.WriteLine("Informe o ID da REQUISICAO a ser REMOVIDA");
                    id = Convert.ToInt32(Console.ReadLine());
                    novoRepositorio.DeletaRequisicao(id);

                    Console.Clear();
                    Mensagem.ConteudoMensagem("Requisição removida com sucesso!", ConsoleColor.Green);
                    ExibeMenuRequisicao();
                    break;
            }
        }
        public Requisicao ObterRequisicao()
        {

            novaTelaMedicamento.ExibeMedicamento();
            Console.WriteLine("Informe o MEDICAMENTO a ser levado");
            string medicamento = Convert.ToString(Console.ReadLine());

            novaTelaPaciente.ExibePaciente();
            Console.WriteLine("Informe o PACIENTE que vai levar o medicamento");
            string paciente = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Informe a QUANTIDADE de MEDICAMENTO a ser levada");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a DATA DE VALIDADE da REQUISICAO |00/00/0000|");
            string dataValidade = Convert.ToString(Console.ReadLine());

            return new Requisicao(medicamento, paciente, quantidade, dataValidade);
        }

        public void ExibeRequisicao()
        {
            Requisicao[] registroRequisicao = novoRepositorio.SelecionaRequisicao();

            Console.WriteLine(
            "{0, -10} | {1,-15} | {2,-15} | {3, -10} | {4, -15}",
            "ID", "Medicamento", "Paciente", "Quantidade", "Data de Validade"
            );

            for (int i = 0; i < registroRequisicao.Length; i++)
            {
                if (registroRequisicao[i] != null)
                    Console.WriteLine(
                       "{0, -10} | {1,-15} | {2,-15} | {3, -10} | {4, -15}",
                       registroRequisicao[i].id, registroRequisicao[i].medicamento, registroRequisicao[i].paciente,
                       registroRequisicao[i].quantidade, registroRequisicao[i].dataValidade
                    );
            }
        }
    }
}
