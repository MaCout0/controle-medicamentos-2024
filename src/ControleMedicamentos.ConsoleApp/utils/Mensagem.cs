namespace ControleMedicamentos.ConsoleApp.utils
{
    public static class Mensagem
    {
        public static void ConteudoMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
