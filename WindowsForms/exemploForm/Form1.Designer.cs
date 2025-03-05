namespace exemploForm;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label label1; // Criação de um atributo com tipo de uma classe específica para texto

    private System.Windows.Forms.TextBox textBox1; // Caixa para entrada de texto
    private System.Windows.Forms.Button button1; // botão

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Iniciar";
    
        // Inicializando as variáveis criadas
        this.label1 = new();
        this.textBox1 = new();
        this.button1 = new();

        // Configuração do Label1;
        this.label1.AutoSize = true; // Ajusta o tamanho do laber de acordo com o Texto;
        this.label1.Location = new System.Drawing.Point(30,9); // Fefine a posição do Label
        this.label1.Name = "label1";
        this.label1.Size = new Size(90,20); // Define o tamanho do label
        this.label1.Text = "Digite um Número: "; //  Define o Texto do laber

        // Configuração do TextBox1
        this.textBox1.Location = new Point(30,30);
        this.textBox1.Name = "TextBox1";
        this.textBox1.Size = new Size(200,25); // Largura X Altura

        // Configuração do botao
        this.button1.Location = new Point(30,40);
        this.button1.Name = "button1";
        this.button1.Size = new Size(100,20);
        this.button1.Click += new EventHandler(this.button1_Click); // Define o evento de clique do button, esse button1_CLick é um método que será criado para tratar o evento de clique do botão


        this.Controls.Add(label1);
        this.Controls.Add(textBox1);
        this.Controls.Add(button1);
    
    }

    #endregion
}
