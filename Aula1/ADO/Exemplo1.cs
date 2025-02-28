using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Para a gente utilizar a conexão com banco de dados PosGres, precisamos instalar o pacote Npgsql
// dotnet add package Npgsql
using Npgsql;

namespace Aula1_.ADO
{
    public class Exemplo
    {
        static void Main(string[] args)
        {
          
            string conexao = "Host=localhost;Database=Aula1;Port=5432;Username=postgres;Password=1234";

            using (NpgsqlConnection con = new (conexao))
            {
                try
                {
                    con.Open(); // Abre a conexão
                    // System.Console.WriteLine("Conexão feita com sucesso!");

                    // Aqui estamos criando um comando SQL para ser executado no banco de dados, quero imprimir o que está la dentro do banco

                    string sql = "SELECT * FROM PUBLIC.USUARIO;";

                    // Vamos criar o comando que via inserir um novo registro na tabela usuário
                    string insertQuery = "INSERT INTO public.usuario (id_usuario, nome, email) VALUES (7,'Arthur','aio@gmail.com');";
                    string deleteQuery = "DELETE FROM public.usuario WHERE ID_USUARIO = 6";
                    string updateQuery = "UPDATE public.usuario SET ID_USUARIO = 6 WHERE ID_USUARIO = 7";

                     using (NpgsqlCommand cmd = new (updateQuery,con))
                    {
                        int row = cmd.ExecuteNonQuery(); // Executa um comando que não retorna dados, como um insert, update ou delete

                        System.Console.WriteLine("Linhas afetadas: " + row);
                        System.Console.WriteLine("Comando executado com Sucesso!");
                    }


                    // using de insert
                    // using (NpgsqlCommand cmd = new (insertQuery,con))
                    // {
                    //     int row = cmd.ExecuteNonQuery(); // Executa um comando que não retorna dados, como um insert, update ou delete

                    //     System.Console.WriteLine("Linhas afetadas: " + row);
                    //     System.Console.WriteLine("Comando executado com Sucesso!");
                    // }

                    // using de delete
                    // using(NpgsqlCommand cmd = new(deleteQuery,con))
                    // {
                    //     int row = cmd.ExecuteNonQuery();
                    //     System.Console.WriteLine("Linhas afetadas: ", row);
                    //     System.Console.WriteLine("Comando executado com Sucesso!");
                    // }




                    using(NpgsqlCommand cmd = new(sql, con))
                    { // NpgCommand representa um comando SQL que será executado no banco de dados

                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {   // NpgssqlReader ele representa um leitor de dados que irá ler os dados do banco de dados

                            System.Console.WriteLine("Tabelas do banco de dados: ");

                            while (dr.Read())
                            {
                                // System.Console.WriteLine(dr.GetString(0));
                                // System.Console.WriteLine($"Id: {dr["id_usuario"]} + Nome: {dr["nome"]} + Email: {dr["email"]}"); // Aqui pega pelas colunas

                                System.Console.WriteLine($"Id: {dr.GetInt32(0)}  \nNome: {dr.GetString(1)}  \nEmail: {dr.GetString(2)}"); // Aqui pela pelo tipo das linhas
                                System.Console.WriteLine();
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    System.Console.WriteLine("Erro " + ex.Message);                    
                }
            }  
            


        }
    }
}