using static Banco_Arquivo.Utils;

namespace Banco_Arquivo {
    public class Menus {

        public static void ExibirMenu() {

            Console.WriteLine("[1] - Incluir");
            Console.WriteLine("[2] - Alterar");
            Console.WriteLine("[3] - Excluir");
            Console.WriteLine("[4] - Consultar");
            Console.WriteLine("[0] - Sair");
        }

        public static int EntrarOpcao() {
            int opcao;

            do {
                ExibirMenu();
                opcao = LerInteiro("Entrar opção: ");
                if ((opcao >= 0) && (opcao <= 4)) {
                    break;
                }
                else {
                    Console.WriteLine("Erro: opção inválida");
                }
            } while (true);
            return opcao;
        }
    }
}
