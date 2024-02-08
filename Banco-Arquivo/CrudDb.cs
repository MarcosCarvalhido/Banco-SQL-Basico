using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Banco_Arquivo
{
    public class CrudDb
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Banco; Integrated Security = True; Connect Timeout = 30;";
       
        public static Conta ConsultarConta(int id)
        {
            string sql = "SELECT * FROM contas WHERE id = @id";
            Conta conta = null;

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));     
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int idConta = int.Parse(reader["id"].ToString());
                        string nomeConta = reader["nome"].ToString();
                        double saldoConta = double.Parse(reader["saldo"].ToString());
                        conta = new Conta(idConta, nomeConta, saldoConta);
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return conta;
        }
        public static void Incluir(string nome,double saldo)
        {
            string sql = "INSERT INTO contas (nome,saldo) VALUES (@nome,@saldo)";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.Parameters.Add(new SqlParameter("@nome", nome));
                    cmd.Parameters.Add(new SqlParameter("@saldo", saldo));
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("conta Criada");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void Excluir(int id)
        {
            string sql = "DELETE FROM contas WHERE id = @id";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("conta Excluida");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void Alterar(Conta conta)
        {
            string sql = "UPDATE contas SET saldo = @saldo WHERE id = @id";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.Parameters.Add(new SqlParameter("@id", conta.Id));
                    cmd.Parameters.Add(new SqlParameter("@saldo", conta.Saldo));
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("conta Modificada");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static bool ContasVazia()
        {
            int cont = 0;
            string sql = "SELECT COUNT(*) FROM contas";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cont = (int) cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return (cont ==0);
        }
    
        public static List<Conta> ConsultarTodos()
        {
            string sql = "SELECT * FROM contas";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    List<Conta> contas = new List<Conta>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString());
                        string nome = reader["Nome"].ToString();
                        double saldo = double.Parse(reader["Saldo"].ToString());
                        contas.Add(new Conta(id, nome, saldo));
                    }
                    sqlConn.Close();
                    return contas;
                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
    }
}
