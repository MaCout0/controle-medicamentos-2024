using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento
    {
        Medicamento[] estoque = new Medicamento[20];
        Contador contadorMedicamento = new();


        public void CadastraMedicamento(Medicamento novoMedicamento)
        {
            novoMedicamento.id = contadorMedicamento.valorContador;

            estoque[contadorMedicamento.valorContador] = novoMedicamento;
            contadorMedicamento.IncrementaContador();
        }

        public Medicamento[] SelecionaEstoque()
        {
            return estoque;
        }

        public void DeletaMedicamento(int id)
        {
            var ListaEstoque = estoque.ToList();

            ListaEstoque.RemoveAt(id);

            estoque = ListaEstoque.ToArray();
        }

        public void EditarMedicamento(Medicamento medicamentoEditado, int id)
        {
            medicamentoEditado.id = estoque[id].id;

            estoque.SetValue(medicamentoEditado, id);
        }
    }
}
