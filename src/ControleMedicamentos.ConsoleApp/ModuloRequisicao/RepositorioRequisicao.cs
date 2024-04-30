using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicao
    {
        Requisicao[] registroRequisicao = new Requisicao[20];
        Contador contadorRequisicao = new Contador();

        public void CadastraRequisicao(Requisicao novaRequisicao)
        {
            novaRequisicao.id = contadorRequisicao.valorContador;

            registroRequisicao[contadorRequisicao.valorContador] = novaRequisicao;
            contadorRequisicao.IncrementaContador();
        }

        public Requisicao[] SelecionaRequisicao()
        {
            return registroRequisicao;
        }

        public void DeletaRequisicao(int id)
        {
            var listaRequisicao = registroRequisicao.ToList();

            listaRequisicao.RemoveAt(id);

            registroRequisicao = listaRequisicao.ToArray();
        }

        public void EditaRequisicao(Requisicao editaRequisicao, int id)
        {
            editaRequisicao.id = registroRequisicao[id].id;

            registroRequisicao.SetValue(editaRequisicao, id);
        }
    }
}
