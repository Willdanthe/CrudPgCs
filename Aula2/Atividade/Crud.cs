using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2.Atividade
{
    public class Crud
    {
        public void InserirUsuario(int id, string nome, string password, int ramal,string especialidade)
        {
            try
            {
                using (var db = new Context())
                {
                    db.Usuarios.Add(new Usuarios
                    {
                        Id_usuario = id,
                        Nome_Usuario = nome,
                        Password = password,
                        Especialidade = especialidade,
                        Ramal = ramal
                    });
                    db.SaveChanges();
                        System.Console.WriteLine("Usuário Cadastrado com Sucesso!");

                }
            } catch (SystemException e)
            {
                System.Console.WriteLine($"Erro: {e}");
            }
        }

        public void AtualizarUsuario(int id,string novoNome)
        {
            try
            {
                using (var db = new Context())
                {
                    var usuario = db.Usuarios.Find(id);

                    if (usuario != null)
                    {
                        usuario.Nome_Usuario = novoNome;
                        db.SaveChanges();
                        System.Console.WriteLine("Usuário atualizado com Sucesso!");
                    } else
                    {
                        System.Console.WriteLine($"Usuário do id {id} não encontrado");
                    }
                }
            }
            catch (SystemException e)
            {
                System.Console.WriteLine($"Erro: {e}");
            }
        }

        public void DeletarUsuario(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    var usuario = db.Usuarios.Find(id);

                    if (usuario != null)
                    {
                        db.Usuarios.Remove(usuario);
                        db.SaveChanges();
                        System.Console.WriteLine("Usuário Deletado com Sucesso");
                    }
                    else
                    {
                        System.Console.WriteLine($"Usuário do id {id} não encontrado");
                    }
                }
            }
            catch (SystemException e)
            {
                System.Console.WriteLine($"Erro: {e}");

            }
        }

        public void ListarUsuarios()
        {
            try
            {
                using (var db = new Context())
                {
                    var usuarios = db.Usuarios.ToList();

                    foreach (var usuario in usuarios)
                    {
                        System.Console.WriteLine($"Id = {usuario.Id_usuario}, Nome = {usuario.Nome_Usuario},Password = {usuario.Password},Especialidade = {usuario.Especialidade},Ramal = {usuario.Ramal}");
                    }
                }
            }
            catch (SystemException e)
            {
                System.Console.WriteLine($"Erro: {e}");
            }
        }
    }
}