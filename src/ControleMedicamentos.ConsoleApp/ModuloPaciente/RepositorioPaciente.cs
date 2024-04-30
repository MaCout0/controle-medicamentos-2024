using ControleMedicamentos.ConsoleApp.utils;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente
    {
        Paciente[] registroPaciente = new Paciente[20];
        Contador contadorPaciente = new Contador();

        public void CadastraPaciente(Paciente novoPaciente)
        {

            novoPaciente.id = contadorPaciente.valorContador;


            registroPaciente[contadorPaciente.valorContador] = novoPaciente;

            contadorPaciente.IncrementaContador();
        }

        public Paciente[] SelecionaRegistroPaciente()
        {
            return registroPaciente;
        }

        public void DeletaPaciente(int id)
        {
            var listaPaciente = registroPaciente.ToList();

            listaPaciente.RemoveAt(id);

            registroPaciente = listaPaciente.ToArray();
        }

        public void EditaPaciente(Paciente pacienteEditado, int id)
        {


            pacienteEditado.id = registroPaciente[id].id;



            registroPaciente.SetValue(pacienteEditado, id);

        }
    }
}
