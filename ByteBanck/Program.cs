namespace ByteBanck01
{

    public class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("1 - Inseir novo usuário");
            Console.WriteLine("2 - Deletar usuário");
            Console.WriteLine("3 - Listar todas as contas listadas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("0 - Para sair do Programa");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            saldos.Add(0);
        }

        private static void ListarTodasContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = {saldos[i]:f2}");
            }

        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores");
           

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("------------------");
                switch (option)
                {

                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, saldos);
                        break;
                    case 3:
                        ListarTodasContas(cpfs, titulares, saldos);
                        break;
                }

                Console.WriteLine("------------------");

            } while (option != 0);
        }

    }
}