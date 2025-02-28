using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Aula2
{
    public class Crud
    {
        public void InserirUsuario(int id, string nome, string email)
        {
            using (IDbConnection db = ContextDb.GetConexao())
            {
                string sql = $"INSERT INTO public.usuario(ID_USUARIO, NOME, EMAIL) VALUES ( {id} , '{nome}', '{email}');";
                db.Execute(sql);
                // using (IDbCommand cmd = )
            }
        }

        public void ListarUsuario()
        {
            using (IDbConnection db = ContextDb.GetConexao())
            {
                string sql = "SELECT * FROM PUBLIC.USUARIO;";
                
                var usuarios = db.Query<Usuario>(sql).ToList();

                System.Console.WriteLine("-=-=-=-=-=-= Lista de Usuários =-=-=-=-=-=-");

                foreach (var usuaio in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuaio.Id_usuario} ; Nome: {usuaio.Nome} ; Email: {usuaio.Email}");
                }
            }
        }

        public void AtualizarUsuario(int id,string novoNome)
        {
            using (IDbConnection db = ContextDb.GetConexao())
            {
                string sql = $"UPDATE PUBLIC.USUARIO SET NOME = '{novoNome}' WHERE ID_USUARIO = {id}";
                db.Execute(sql);
                System.Console.WriteLine($"Usuario com o id '{id}' foi atualizado com sucesso!");
            }
        }
        
        public void DeletarUsuario(int id)
        {
            using (IDbConnection db = ContextDb.GetConexao())
            {
                string sql = $"DELETE FROM USUARIO WHERE ID_USUARIO = {id}";
                db.Execute(sql);
                System.Console.WriteLine($"Usuario com o id '{id}' foi Deletado com sucesso!");

            }
        }
    }
}