namespace exemploForm;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Text = "Meu Primeiro Windows Forms";
        this.Width = 400; 
        this.Height = 200;

        Label lb = new();
        lb.Text = "Olá, Mundo!";
        lb.AutoSize = true; // Define o tamanho do Label
        lb.Location = new Point(10,10); // Define a posição do label. Point é uma classe que define um ponto no plano cartesiano

        // Adiciona o label ao formulário
        this.Controls.Add(lb); // Controls é uma propriedade que contem os controles do formulário, e estou adicionando para mostrar a informação na tela pelo label

    }
}
