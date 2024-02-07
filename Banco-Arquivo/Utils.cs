using System.Runtime.CompilerServices;

namespace Banco_Arquivo {
    public class Utils {

        public static int LerId() {
            int id;

            do {
                try {
                    Console.Write("Entre com o id: ");
                    id = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Erro: valor inválido");
                }
            } while (true);
            return id;
        }

        public static string LerNome() {
            string nome;

            do {
                Console.Write("Entre com o nome: ");
                nome = Console.ReadLine();
                string[] nomes = nome.Split(' ');
                if (nomes.Length >= 2) {
                    break;
                }
                else {
                    Console.WriteLine("Erro: nome inválido");
                }
            } while (true);
            return nome;
        }

        public static int LerInteiro(string msg) {
            int inteiro;

            do {
                try {
                    Console.Write(msg);
                    inteiro = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Erro: valor inválido");
                }
            } while (true);
            return inteiro;
        }

        public static double LerReal(string msg) {
            double real;

            do {
                try {
                    Console.Write(msg);
                    real = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Erro: valor inválido");
                }
            } while (true);
            return real;
        }

        public static double LerSaldo() {
            double saldo;

            do {
                saldo = LerReal("Entre com o saldo: ");
                if (saldo > 0) {
                    break;
                }
                else {
                    Console.WriteLine("Erro: saldo tem que ser maior que zero");
                }
            } while (true);
            return saldo;
        }

        public static double LerValor() {
            double valor;

            do {
                valor = LerReal("Entre com o valor: ");
                if (valor > 0) {
                    break;
                }
                else {
                    Console.WriteLine("Erro: valor tem que ser maior que zero");
                }
            } while (true);
            return valor;
        }

        public static Conta PesquisarConta(int id, List<Conta> contas) {
            Conta contaPesquisa = null;

            foreach (Conta conta in contas) {
                if (conta.Id == id) {
                    contaPesquisa = conta;
                    break;
                }
            }
            return contaPesquisa;
        }

        public static bool ListaVazia(List<Conta> contas) {

            return (contas.Count == 0);
        }
    }
}
