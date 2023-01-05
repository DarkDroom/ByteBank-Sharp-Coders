using System;
using System.Security.AccessControl;
using System.Security.Cryptography;

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
                Console.WriteLine("5 - Quantidade armazenada no banco");
                Console.WriteLine("6 - Manipular a conta");
                Console.WriteLine("0 - Para sair do Programa");
                Console.WriteLine("");
                Console.WriteLine("Digite a opção desejada");
            }

            static void ShowMenu1()
            {
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Transferir");
                Console.WriteLine("4 - Retornar");                
            }

            static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
            {
                Console.Write("Digite o cpf: ");
                cpfs.Add(Console.ReadLine());

                Console.Write("Digite o nome: ");
                titulares.Add(Console.ReadLine());

                Console.Write("Digite sua senha: ");
                senhas.Add(Console.ReadLine());

                saldos.Add(0);                
            }

            static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
            {
                Console.Write("Digite o cpf: ");
                string cpfParaDeletar = Console.ReadLine();
                //encontrando o indece a ser deletado
                int indexParaRemover = cpfs.FindIndex(d => d == cpfParaDeletar); //d talque d seja igual ao cpf a ser removido


                //! = senão, interrogação e o se não
                if (indexParaRemover == -1)
                {
                    Console.WriteLine("Não possivel deletar esse cpf.");
                    Console.WriteLine("MOTIVO: Não encontrado");
                }

                cpfs.Remove(cpfParaDeletar);
                titulares.RemoveAt(indexParaRemover);
                senhas.RemoveAt(indexParaRemover);
                saldos.RemoveAt(indexParaRemover);
                

                Console.WriteLine("Usuário deletado com suscesso.");
            }

            static void ListarTodasContas(List<string> cpfs, List<string> titulares, List<double> saldos)
            {
                for (int i = 0; i < cpfs.Count; i++)
                {
                    ApresentaConta(i, cpfs, titulares, saldos);
                }
            }

            static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos) {
                Console.Write("Digite o cpf: ");
                string cpfParaApresentar = Console.ReadLine();
                //encontrando o indece a ser deletado
                int indexParaApresentar = cpfs.FindIndex(d => d == cpfParaApresentar); //d talque d seja igual ao cpf a ser removido


                //! = senão, interrogação e o se não
                if (indexParaApresentar == -1)
                {
                    Console.WriteLine("Não possivel apresentar esta conta.");
                    Console.WriteLine("MOTIVO: Conta não encontrado");
                }

                ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
            }

            static void ManipularDados(List<string> cpfs, List<double> saldos, List<string> senhas)
             {
                    Console.Write("Digite o cpf: ");
                    string cpfParaVerificar = Console.ReadLine();
                    //encontrando o indece a ser deletado
                    int indexParaVerificar = cpfs.FindIndex(d => d == cpfParaVerificar); //d talque d seja igual ao cpf a ser removido
                    Console.WriteLine(indexParaVerificar);

                    //! = senão, interrogação e o se não
                    if (indexParaVerificar == -1)
                    {
                        Console.WriteLine("CPF não encontrado");
                        Console.WriteLine("MOTIVO: Conta não encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Digite a senha:");
                        string senhaVerificar = Console.ReadLine();
                        if (senhaVerificar == senhas[indexParaVerificar])
                        {
                        
                            ShowMenu1();
                            int option1 = int.Parse(Console.ReadLine());
                            switch (option1){

                            case 1:
                                DepositoNoSaldo(indexParaVerificar, saldos);
                                break;

                            case 2:
                                Console.WriteLine("Qual o valor a ser sacado: ");
                                ValorSacado(indexParaVerificar, saldos);
                                break;

                            case 3:
                                Console.WriteLine("Qual o valor a ser transferido: ");
                                ValorSacado(indexParaVerificar, saldos);
                                break;

                             }
                        }
                        else
                        {
                            Console.WriteLine("Retornando ao menu anterior");
                            Console.WriteLine("------------------");
                            ShowMenu();                            
                        }
                        
                     }
             }
    
            static void ApresentarValorAcumulado(List<double> saldos) {
                Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
                //.Sum() ou .Aggregate(0.0, (x, y) => x + y);           
            }

            static void DepositoNoSaldo(int index, List<double> saldos){               
                Console.WriteLine("Qual o valor a ser depositado: ");
                double valorAtual = saldos[index];                
                double depositoRealizado = double.Parse(Console.ReadLine());
                Console.WriteLine($"Depositio realizado: {depositoRealizado:f2}");
                Console.WriteLine("");
                valorAtual = valorAtual + depositoRealizado;               
                saldos.Insert(index, valorAtual);
                valorAtual = 0;
            }

            static void ValorSacado(int index, List<double> saldos)
            {
                
                double valorAtual = saldos[index];
                double depositoRealizado = double.Parse(Console.ReadLine());
                Console.WriteLine($"Depositio realizado: {depositoRealizado:f2}");
                Console.WriteLine("");
                valorAtual = valorAtual - depositoRealizado;
                saldos.Insert(index, valorAtual);
                valorAtual = 0;
            }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos) {
                Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = {saldos[index]:f2}");

            }

            public static void Main(string[] args)
            {
                Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores");
                Console.WriteLine("");


                List<string> cpfs = new List<string>();
                List<string> titulares = new List<string>();
                List<string> senhas = new List<string>();
                List<double> saldos = new List<double>();
                
                //List<double> saldos = new List<double>();
                //List<double> saldos = new List<double>();


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
                            RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                            break;

                        case 2:
                            DeletarUsuario(cpfs, titulares, senhas, saldos);
                            break;

                        case 3:
                            ListarTodasContas(cpfs, titulares, saldos);
                            break;

                        case 4:
                            ApresentarUsuario(cpfs, titulares, saldos);
                            break;
                        
                        case 5:
                            ApresentarValorAcumulado(saldos);
                            break;
                        case 6:
                            ManipularDados(cpfs , saldos, senhas);
                            break;

                    }

                    Console.WriteLine("------------------");

                } while (option != 0);
            }
     }
}