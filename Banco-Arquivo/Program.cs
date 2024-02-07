
using static Banco_Arquivo.Crud;
using static Banco_Arquivo.Menus;
using static Banco_Arquivo.CrudDb;

namespace Banco_Arquivo {
    internal class Program {
        static void Main(string[] args) {
            const int FIM = 0;

            int opcao = EntrarOpcao();
            while (opcao != FIM) {
                switch (opcao) {
                    //case 1: IncluirConta(contas); break;
                    //case 2: AlterarConta(contas); break;
                    //case 3: ExcluirConta(contas); break;
                    case 4: ConsultarContas(); break;
                }
                opcao = EntrarOpcao();
            }
        }
    }
}