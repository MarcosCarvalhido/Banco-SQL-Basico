using static Banco.Arquivo;
namespace Banco
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();

            contas = LerContas(contas);
            GravarContas(contas);
        }

    }
}