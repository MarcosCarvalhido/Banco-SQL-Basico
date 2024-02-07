using static Banco_Arquivo.Utils;
using static Banco_Arquivo.CrudDb;

namespace Banco_Arquivo {
    public class Crud {

        public static void IncluirConta(List<Conta> contas) {

            int id = LerId();
            Conta conta = PesquisarConta(id, contas);
            if (conta != null) {
                Console.WriteLine("Erro: id já existe");
                return;
            }
            string nome = LerNome();
            double saldo = LerSaldo();
            contas.Add(new Conta(id, nome, saldo));
        }

        public static void ExcluirConta(List<Conta> contas) {

            if (ListaVazia(contas)) {
                Console.WriteLine("Lista de contas vazia");
                return;
            }
            int id = LerId();
            Conta conta = PesquisarConta(id, contas);
            if (conta == null) {
                Console.WriteLine("Erro: conta não existe");
                return;
            }
            if (conta.Saldo > 0) {
                Console.WriteLine("Erro: saldo maior que zero");
                return;
            }
            contas.Remove(conta);
        }


        public static void AlterarConta(List<Conta> contas) {

            if (ListaVazia(contas)) {
                Console.WriteLine("Lista de contas vazia");
                return;
            }
            int id = LerId();
            Conta conta = PesquisarConta(id, contas);
            if (conta == null) {
                Console.WriteLine("Erro: conta não existe");
                return;
            }
            RealizarOperacao(conta);
        }

        public static void RealizarOperacao(Conta conta) {

            int oper = LerOperacao();
            double valor = LerValor();
            if (oper == 1) {
                conta.Creditar(valor);
            }
            else {
                conta.Debitar(valor);
            }
        }

        public static int LerOperacao() {
            int oper;

            do {
                Console.WriteLine("[1]-Creditar ou [2]-Debitar");
                oper = LerInteiro("Entre com a operação: ");
                if ((oper == 1) || (oper == 2)) {
                    break;
                }
                else {
                    Console.WriteLine("Erro: operação inválida");
                }
            } while (true);
            return oper;
        }

        public static void ConsultarContas() {
            if (ContasVazia())
            {
                Console.WriteLine("Lista de contas vazia");
                return;
            }
            List<Conta> contas = ConsultarTodos();
            foreach (Conta conta in contas) {
                Console.WriteLine(conta);
            }
        }

        public static void ConsultarConta(int id, List<Conta> contas) {

            if (ListaVazia(contas)) {
                Console.WriteLine("Lista de contas vazia");
                return;
            }
            Conta conta = PesquisarConta(id, contas);
            if (conta == null) {
                Console.WriteLine("Erro: conta não existe");
                return;
            }
            Console.WriteLine(conta);
        }
    }
}
