using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1_.Entity
{
    public class Crud
    {
        public void InserirUsuario(int id, string nome, string email)
        {
            using ( var db = new ContextDb())
            {
                db.Usuarios.Add(new Usuario {Id_usuario = id, Nome = nome, Email = email});
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using(var db = new ContextDb())
            {
                var usuarios = db.Usuarios.ToList();

                foreach (var user in usuarios)
                {
                    System.Console.WriteLine($"Id: {user.Id_usuario}, Nome: {user.Nome}, Email: {user.Email}");
                }
            }
        }
        public void AtualizarUsuario(int id, string novoNome)
        {
            using (var db = new ContextDb())
            {
                var usuario = db.Usuarios.Find(id);

                if (usuario != null)
                {
                    usuario.Nome = novoNome;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário atualizado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = new ContextDb())
            {
                var usuario = db.Usuarios.Find(id);

                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário deletado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado!");
                }
            }
        }

    }
}