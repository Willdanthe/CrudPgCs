using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Crud_com_pagina
{
    public partial class Crud
    {
        string conexaoSQL = "Host=localhost;Database=crud;username=postgres;Password=1234";

        public void InserirUsuario(int id, string nome, string password, int ramal, string especialidade)
        {
            string query = "INSERT INTO USUARIO(ID_USUARIO, PASSWORD, NOME_USUARIO, RAMAL, ESPECIALIDADE) VALUES (@ID, @PASSWORD, @NOME, @RAMAL, @ESPECIALIDADE);";

            using (NpgsqlConnection con = new NpgsqlConnection(conexaoSQL))
            {
                try
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NOME", nome);
                        cmd.Parameters.AddWithValue("@PASSWORD", password);
                        cmd.Parameters.AddWithValue("@RAMAL", ramal);
                        cmd.Parameters.AddWithValue("@ESPECIALIDADE", especialidade);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Erro ao inserir usuário : {ex.Message}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            string query = "UPDATE USUARIO SET NOME_USUARIO = @NOME WHERE ID_USUARIO = @ID;";

            using (NpgsqlConnection con = new NpgsqlConnection(conexaoSQL))
            {
                try
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NOME", novoNome);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM USUARIO WHERE ID_USUARIO = @ID;";

            using (NpgsqlConnection con = new NpgsqlConnection(conexaoSQL))
            {
                try
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
                }
            }
        }

        public List<string> ListarUsuarios()
        {
            string query = "SELECT * FROM USUARIO;";

            List<string> usuarios = new List<string>();
            // List<string> usuarios = []; outra forma de fazer também :]

            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conexaoSQL))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new (query,con))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string linha = $"ID: {dr["id_usuario"]}; Nome: {dr["nome_usuario"]}; Senha: {dr["password"]}; Ramal: {dr["ramal"]}; Especialidade: {dr["especialidade"]}";

                                usuarios.Add(linha);

                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Erro ao Listar Usuários: {ex.Message}");
            }
            return usuarios;
        }
    }
}