using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KomsertaPC_OS_s
{
    public class Cliente
    {
        private int id;
        private string nome;
        private Cpf cpf;
        private string telefone;


        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Cpf Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }

        public Cliente()
        {

        }

        private Cliente(string nome, Cpf cpf, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }
        public static Cliente Create(string nome, string cpf, string telefone)
        {
            Cpf cpf1 = Cpf.Create(cpf);
            return new Cliente(nome, cpf1, telefone);
        }

        public static DataTable PopularCliente()
        {
            string connString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=PIT;Integrated Security=True";
            string query = "select * from Cliente";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            return dataTable;
        }
         
        private static int ComparaCpf(string cpf, DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
                {
                if (row["cpf"].ToString().Equals(cpf)) return Int16.Parse(row["id"].ToString());
            }
            return -1 ;
        }



        public static int CpfExiste(string cpf)
        {
           return ComparaCpf(cpf, PopularCliente());
        }
        
    }
}
