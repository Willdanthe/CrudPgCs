using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2.Atividade
{
    public class Exec
    {
        static void Main(string[] args)
        {
            Crud cr = new Crud();

            cr.InserirUsuario(1, "123", "Joao", 123, "TI");
            cr.InserirUsuario(2, "456", "Maria", 456, "RH");
            cr.InserirUsuario(3, "789", "Jose", 789, "Financeiro");

            cr.ListarUsuarios();
        }
    }
}