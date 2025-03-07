// using System;
// namespace Exemplo2
// {
//     class Program
//     {
    
//     [STAThread]  // É um atributo que indica que o método Main é um método de thread de nível de aplicativo que é executado em um único thread de aplicativo
//     static void Main(string[] args)
//     {
//         // Aplication é a classe que gerencia a execução de um aplicativo Windows Forms
//         Application.EnableVisualStyles(); // Habilita o estilo visual do Windows Forms

//         Application.SetCompatibleTextRenderingDefault(false); // Define o valor padrão para a propriedade TextRenderingDefault de todos os controles do aplicativo, ele faz com que o texto seja renderizado de forma mais nítida.

//         Application.Run(new Calculadora());
//     }
//     }
    
// }