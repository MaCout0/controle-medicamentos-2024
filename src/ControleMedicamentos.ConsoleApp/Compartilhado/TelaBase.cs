namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public abstract class TelaBase
    {
        protected string modulo = "";
        protected ConsoleColor cor;

        protected static int MenuSelecao(string modulo, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine($"Gestão de {modulo}");
            Console.ResetColor();

            Console.WriteLine("Por favor escolha a opcao desejada \n" +
             $"1- Cadastrar {modulo} \n" +
             $"2- Listagem de {modulo} \n" +
             $"3- Edicao de {modulo} \n" +
             $"4- Remocao de {modulo} \n" +
             "5- Sair para o Menu Principal");
            int escolha = Convert.ToInt32(Console.ReadLine());
            return escolha;
        }


        protected void ApresentaErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
            {
                Console.WriteLine(erros[i]);
            }

            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
