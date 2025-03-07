using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Exemplo2
{
    public class MeuFormulario : Form
    {
        public MeuFormulario()
        {




            this.Text = "Inicio";
            this.Size = new Size(800,600);

            Label lb1 = new();
            lb1.Text = "Nome comdasdasdsadasdsadsadasdasdasdasdasdaspleto:";
            lb1.Location = new Point(100,100);
            this.AutoSize = true;

            TextBox tb1 = new();
            tb1.Name = "tb1";
            tb1.Size = new Size(100,30);
            tb1.Location = new Point(100,130);
            // tb1.PlaceholderText = Teste;

            Button btn1 = new();
            btn1.Name = "btn1";
            btn1.Text = "Mostrar";
            // b
        
            this.Controls.Add(lb1);
            this.Controls.Add(tb1);
        }
    }

    public class Calculadora: Form
    {
        private IContainer Components = null;
        private Label lb1;
        private TextBox tb1;
        private TextBox tb2;
        private Button btn1;

        public Calculadora()
        {
            this.BackColor = Color.FromArgb(160 , 32 , 240 );;
            this.Components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800,450);
            this.Text = "Calculadora";



            this.lb1 = new Label();
            this.tb1 = new TextBox();
            this.tb2 = new TextBox();
            this.btn1 = new Button();


            // Configurando o Label1
            this.lb1.AutoSize = true;
            this.lb1.Location = new Point(30,30);
            this.lb1.Name = "lb1";
            this.lb1.Size = new Size(90,20);
            this.lb1.Text = "Digite os números: ";

            // Configurando o TextBox1
            this.tb1.Location = new Point(30,60);
            this.tb1.Name = "Texto1";
            this.tb1.Size = new Size(200,27);

            // Configurando o TextBox2
            this.tb2.Location = new Point(30,90);
            this.tb2.Name = "Texto2";
            this.tb2.Size = new Size(200,27);

            // Configura o Button1
             // Configurando o TextBox1
            this.btn1.Location = new Point(30,120);
            this.btn1.Name = "Texto1";
            this.btn1.Size = new Size(100,30);
            this.btn1.Text = "Calcular";
            this.btn1.Click += new EventHandler(this.Button1_Click);

            // Adicionando os componentes ao formulário

            this.Controls.Add(lb1);
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
            this.Controls.Add(btn1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            int num2 = 0;

            try
            {
                num1 = Convert.ToInt32(tb1.Text);
                num2 = Convert.ToInt32(tb2.Text);

                MessageBox.Show($"A soma do numero {num1} com {num2} é igual a {num1+num2}");
            }
            catch (System.Exception ex)
            {
                 MessageBox.Show("Erro: "+ ex);
            }
        }
    }
}