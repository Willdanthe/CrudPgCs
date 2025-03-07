using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

// Instalar o pacote do NPGSQL
// dotnet add package Npgsql

namespace WindowsForms.Aula4
{
    public class Crud
    {
        string conexaoSQL = "Host=localhost;Database=Aula1;Username=postgres;Password=1234";

        // A gente vai usar a tabela Usuário que tem as colunas id, nome e email

        public void InserirUsuario(int id, string nome, string email)
        {
            string query = "INSERT INTO usuario(id_usuario, nome, email) VALUES (@id, @nome, @email);";
            try
            {
                using (NpgsqlConnection conexao = new(conexaoSQL))
                {
                    conexao.Open();
                    using (NpgsqlCommand cmd = new (query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id",id);
                        cmd.Parameters.AddWithValue("@nome",nome);
                        cmd.Parameters.AddWithValue("@email",email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Erro: {ex}");
            }
        }
        
        public List<string> ListarUsuarios()
        {
            List<string> usuario = new List<string>();
            // List<string> usuario = [];
            string query = "SELECT * FROM USUARIO;";

            using ( NpgsqlConnection con = new(conexaoSQL))
            {
                con.Open();
                using(NpgsqlCommand cmd = new (query,con))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string linha = $"ID: {dr["id_usuario"]}; Nome: {dr["nome"]}; Email: {dr["email"]}";
                            usuario.Add(linha);
                        }
                    }
                }
            }
            return usuario;
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            string query = "UPDATE usuario SET NOME = @NOME WHERE id_usuario = @ID";

            using (NpgsqlConnection con = new (conexaoSQL))
            {
                con.Open();
                using (NpgsqlCommand cmd = new (query,con))
                {
                    cmd.Parameters.AddWithValue("@NOME",novoNome);
                    cmd.Parameters.AddWithValue("@ID",id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM USUARIO WHERE id_usuario = @ID";
            
            using (NpgsqlConnection con = new (conexaoSQL))
            {
                con.Open();
                using (NpgsqlCommand cmd = new (query,con))
                {
                    cmd.Parameters.AddWithValue("@ID",id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}    