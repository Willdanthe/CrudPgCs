// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.Diagnostics;

// namespace Aula2
// {
//     public class exec
//     {
        
//         static void Main(string[] args)
//         {
//             Crud cr = new ();
//             Stopwatch sw = new();
//             TimeSpan tempoTotal;

//             // sw.Start();
//             // cr.ListarUsuario();
//             // sw.Stop();
//             // System.Console.WriteLine($"Tempo de Inserção: {sw.ElapsedMilliseconds}ms");


//             sw.Start();
//             cr.InserirUsuario(6,"Felipe Pedroso", "felipe@gmail.com");
//             sw.Stop();
//             System.Console.WriteLine($"Tempo de Inserção: {sw.ElapsedMilliseconds}ms");
        
//             // sw.Start();
//             // cr.AtualizarUsuario(5,"Thiago Olszewski");
//             // sw.Stop();
//             // System.Console.WriteLine($"Tempo de update: {sw.ElapsedMilliseconds}ms");

//             // cr.InserirUsuario(8,"Thiago owxvddsaczxdadvisk", "thiago@gmail.com");



//             // sw.Start();
//             // // cr.DeletarUsuario(6);
//             // sw.Stop();
//             // System.Console.WriteLine($"Tempo de Inserção: {sw.ElapsedMilliseconds}ms");
//             cr.ListarUsuario();

            
            
//         }
//     }
// }