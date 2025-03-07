using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo2
{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainform());
        }
    }

    public class Mainform : Form
    {
        private TabControl tabControl;
        private TabPage tabpage1;
        private TabPage tabpage2;

        public Mainform()
        {
            this.Text = "Sistema Multi-Tela";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen; // Centraliza o formulário na tela

            // Criando o controle de abas
            tabControl = new TabControl { Dock = DockStyle.Fill };

            // Criando as Páginas
            tabpage1 = new TabPage { Text = "Tela 1" };
            tabpage2 = new TabPage { Text = "Tela 2" };

            // Adicionando UserControls nas páginas
            tabpage1.Controls.Add(new Tela1 { Dock = DockStyle.Fill });
            tabpage2.Controls.Add(new Tela2 { Dock = DockStyle.Fill });

            // Adicionando as abas ao TabControl
            tabControl.TabPages.Add(tabpage1);
            tabControl.TabPages.Add(tabpage2);

            // Adicionando TabControl ao Form
            this.Controls.Add(tabControl);
        }
    }


    public class Tela1 : Form
    {
        public Tela1()
        {
            this.Text= "Tela 1";
            this.Size = new Size(300,300);
            this.StartPosition = FormStartPosition.CenterScreen; // Centraliza o formulário na tela
            this.BackColor = Color.LightSalmon;

            Label lb = new Label {Text = "Tela 1"};
            lb.Location = new Point(100,100);
            this.Controls.Add(lb);
        }
    }

    public class Tela2 : Form
    {
        public Tela2()
        {
            this.Text= "Tela 2";
            this.Size = new Size(300,300);
            this.StartPosition = FormStartPosition.CenterScreen; // Centraliza o formulário na tela
            this.BackColor = Color.Orange;

            Label lb = new Label {Text = "Tela 2"};
            lb.Location = new Point(100,100);
            this.Controls.Add(lb);
        }
    }
}