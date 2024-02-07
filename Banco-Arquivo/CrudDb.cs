﻿using System;
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
