using System.Collections.Generic;
using System;

namespace API.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcao();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUser = ObterOpcao();
            }

            Console.WriteLine("Obrigado Por utilizar Nossos Serviços");
            Console.ReadLine();
            
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Número da Conta: ");
            int indiceConta =  int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a ser Sacado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}
        

        private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
		}
        private static void InserirConta()
        {
            Console.WriteLine("Inserir Uma Nova Conta");

            Console.Write("Digite 1 para conta fisica ou 2 Para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite O Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo da Conta:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito =  double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo:entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }
        private static void ListarContas()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada No Momento");
                return;
            }

            for (var i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("#{0}  -", i);
                Console.WriteLine(conta);

            }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Bank Star Corporation");
            Console.WriteLine("Informe Opção Desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Uma Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Realizar Saque");
            Console.WriteLine("5 - Realizar Deposito");
            Console.WriteLine("C - Limpar a Tela");
            Console.WriteLine("X - Para Sair");

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.ReadLine();
            return  opcaoUser;
        }
    }
}
