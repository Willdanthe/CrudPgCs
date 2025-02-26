using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1_.Entity
{
    public class Exec
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("oi");
            Crud crud = new ();

            crud.InserirUsuario(1,"Willdanthe","Will@gmail.com");
            crud.ListarUsuarios();

            // crud.AtualizarUsuario();
        }
    }
}