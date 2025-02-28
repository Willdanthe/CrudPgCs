using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Diagnostics;

namespace Aula1_.ADO
{
    public class Crud
    {
         public string conexao = "Host=localhost;Database=Aula1;Username=postgres;Password=1234";

        void InserirUsuario(int id, string nome, string email)
        {
            string query = $"INSERT INTO PUBLIC.USUARIO (ID_USUARIO, NOME, EMAIL) VALUES ({id},'{nome}','{email}');";

            using (NpgsqlConnection con = new (conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new (query, con))
                {
                    // Parâmetros para a query, que são os valore serão inseridos
                    cmd.Parameters.AddWithValue("ID_USUARIO", id); 
                    cmd.Parameters.AddWithValue("NOME",nome);
                    cmd.Parameters.AddWithValue("EMAIL",email);
                    // cmd.ExecuteNonQuery();
                    int row = cmd.ExecuteNonQuery();
                    System.Console.WriteLine("Linhas afetadas: ", row);
                    System.Console.WriteLine("Comando executado com Sucesso!");
                }
            }
        }

        void LerUsuarios()
        {
            string query = $"SELECT * FROM PUBLIC.USUARIO";

            using (NpgsqlConnection con = new (conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new (query, con))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        System.Console.WriteLine("=-=-=-=-Usuarios-=-=-=-=");

                        while (dr.Read())
                        {
                            System.Console.WriteLine($"Id: {dr.GetInt32(0)}, Nome: {dr.GetString(1)}, Email: {dr.GetString(2)}");
                        }
                    }
                }
            }
        }

        void AtualizarUsuario(int id, string nome)
        {
            string query = $"UPDATE public.USUARIO SET NOME = @NOME WHERE @ID_USUARIO = @ID_USUARIO;";

            using (NpgsqlConnection con = new (conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new (query, con))
                {
                    cmd.Parameters.AddWithValue("@NOME" , nome);
                    cmd.Parameters.AddWithValue("@ID_USUARIO" , id);
                    cmd.ExecuteNonQuery();
                    // int row = cmd.ExecuteNonQuery();
                    // System.Console.WriteLine("Linhas afetadas: ", row);
                    // System.Console.WriteLine("Comando executado com Sucesso!");
                }
            }
        }

        void DeletarUsuario(int id)
        {
            string query = $"DELETE FROM PUBLIC.USUARIO WHERE ID_USUARIO = {id}";
            using (NpgsqlConnection con = new (conexao))
            {
                con.Open();
                using ( NpgsqlCommand cmd = new (query, con))
                {
                    cmd.Parameters.AddWithValue("ID_USUARIO", id);
                    cmd.ExecuteNonQuery();
                    // int row = cmd.ExecuteNonQuery();
                    // System.Console.WriteLine("Linhas afetadas: ", row);
                    // System.Console.WriteLine("Comando executado com Sucesso!");
                }
            }
        }
        static void Main(string[] args)
        {
            Crud crud = new Crud();

            Stopwatch sw = new (); // Classe que representa o crnômetro para medir o tempo de execução durante a execução do código

            TimeSpan tempoTotal; // Variável que vai armazenar o tempo total de execução

            // 1. Medindo o tempo de inserção de um registro
            sw.Start(); // Iniciando o cronômetro
            crud.InserirUsuario(5,"willdanthe","will@gmail.com");
            sw.Stop();
            System.Console.WriteLine($"Tempo de inserção: {sw.ElapsedMilliseconds}"); // Tempo total em milisegundos que foi decorrido durante a execução do código
            // TimeSpan tempoInsercao = sw.Elapsed;

            // // 2. Medindo o tempo de leitura de um registro
            // sw.Restart();
            // // crud.LerUsuarios();
            // sw.Stop();
            // System.Console.WriteLine($"Tempo de Leitura: {sw.ElapsedMilliseconds}");
            // TimeSpan tempoLeitura = sw.Elapsed;


            // System.Console.WriteLine("--------------------");


            // Console.ReadLine();
            
            // sw.Restart();
            // crud.AtualizarUsuario(7,"GGravena");
            // sw.Stop();
            // System.Console.WriteLine("Tempo de Atualização: " + sw.ElapsedMilliseconds);
            // TimeSpan tempoAtualizacao = sw.Elapsed;

            // crud.LerUsuarios();
            // System.Console.WriteLine("--------------------");

            sw.Restart();
            crud.DeletarUsuario(5);
            sw.Stop();
            Console.WriteLine($"Tempo de Deletar: {sw.ElapsedMilliseconds}");
            TimeSpan tempoDeletar = sw.Elapsed;

            // crud.DeletarUsuario(10);
            crud.LerUsuarios();

            // tempoTotal = tempoAtualizacao + tempoDeletar + tempoInsercao + tempoLeitura;
            // System.Console.WriteLine($"Tempo total de execução: {tempoTotal}");

        }
    }
}