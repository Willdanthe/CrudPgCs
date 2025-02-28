// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.Diagnostics;

// namespace Aula1_.Entity
// {
//     public class Exec
//     {
//         static void Main(string[] args)
//         {
//             Stopwatch sw = new ();

//             TimeSpan ts = new ();            

//             TimeSpan tempoTotal;

//             Crud crud = new ();

//             // sw.Start();
//             // crud.InserirUsuario(4,"Henrique","holiveira@gmail.com");
//             // sw.Stop();
//             // System.Console.WriteLine($"Tempo de Inserção: {sw.ElapsedMilliseconds}");

//             // crud.InserirUsuario(5,"Teste","dassa@gmail.com");


//             // sw.Restart();
//             // crud.AtualizarUsuario(3, "Gabriel Gravena");
//             // sw.Stop();
//             // System.Console.WriteLine($"Tempo de Atualizar: {sw.ElapsedMilliseconds}");


//             // sw.Restart();
//             // crud.ListarUsuarios();
//             // sw.Stop();
//             // System.Console.WriteLine($"Tempo de Listar: {sw.ElapsedMilliseconds}");

//             sw.Restart();
//             crud.DeletarUsuario(5);
//             sw.Stop();
//             System.Console.WriteLine($"Tempo de Deletar: {sw.ElapsedMilliseconds}");
            
//         }
//     }
// }