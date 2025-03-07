using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Crud_com_pagina
{
    public partial class Crud
    {
        public void InserirMaquina(int id, string tipo, int velocidade, int hardDisk, int placa_rede, int memoriaRam, int fk_usuario )
        {
            string query = @"INSERT INTO MAQUINA
            (ID_MAQUINA, TIPO, VELOCIDADE, HARDDISK, PLACA_REDE, MEMORIARAM, FK_USUARIO) VALUES 
            (@ID, @TIPO, @VELOCIDADE, @HARDDISK, @PLACA_REDE, @MEMORIARAM, @FK_USUARIO);";

            using (NpgsqlConnection con = new NpgsqlConnection(conexaoSQL))
            {
                try
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NOME", tipo);
                        cmd.Parameters.AddWithValue("@VELOCIDADE", velocidade);
                        cmd.Parameters.AddWithValue("@HARDDISK", hardDisk);
                        cmd.Parameters.AddWithValue("@MEMORIARAM", placa_rede);
                        cmd.Parameters.AddWithValue("@FK_USUARIO", fk_usuario);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Erro ao inserir máquina: {ex.Message}");
                }
            }
        }

        public void AtualizarMaquina(int id, string hardDisk)
        {
            string query = "UPDATE MAQUINA SET HARDDISK = @HD WHERE ID_MAQUINA = @ID;";

            using (NpgsqlConnection con = new NpgsqlConnection(conexaoSQL))
            {
                try
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@HD", hardDisk);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Erro ao atualizar máquina: {ex.Message}");
                }
            }
        }

        public void DeletarMaquina(int id)
        {
            string query = "DELETE MAQUINA WHERE ID_MAQUINA = @ID;";

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
                    System.Console.WriteLine($"Erro ao deletar máquina: {ex.Message}");
                }
            }
        }

        public List<string> ListarMaquina()
        {
            string query = "SELECT * FROM MAQUINA;";

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
                System.Console.WriteLine($"Erro ao Listar máquinas: {ex.Message}");
            }
            return usuarios;
        }
    }
}