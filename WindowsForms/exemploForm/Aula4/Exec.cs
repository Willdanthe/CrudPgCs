using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using WindowsForms.Aula4;

namespace exemploForm.Aula4
{
    public class Exec
    {
        [STAThread] // Atrivuto para indicar que o método é de entrada de thread de aplicativo
        static void Main(string[] args)
        {
            Application.EnableVisualStyles(); // Habilitar Estilos Visuais
            Application.SetCompatibleTextRenderingDefault(false); // Definir o texto de renderização compatível como falso
            Application.Run(new Cadastro());
        }
    }

    public class Cadastro : Form
    {
        private Label label1, label2, label3;
        private TextBox txtId, txtNome, txtEmail;
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
        private ListBox lstUsuarios; // Para eu colocar os valores do resultados do TextBox em uma lista
        private Crud crud;

        public Cadastro()
        {
            // Inicializar o objeto CRUD
            crud = new Crud();

            this.Size = new Size(500,500);
            this.Text = "Cadastro de Usuários";
            this.BackColor = Color.Orange;

            // Fonte padrão para os textos
            Font fontePadrao = new ("Arial", 12, FontStyle.Bold);
            Font fonteAlternativa = new ("Arial", 12, FontStyle.Bold);

            // Criando os Labels
            label1 = new Label { Text = "ID:", Location = new Point(20,10), Font = fontePadrao, ForeColor = Color.DarkBlue };

            label2 = new Label { Text = "Nome:", Location = new Point(20,60), Font = fontePadrao, ForeColor = Color.DarkBlue };
            
            label3 = new Label { Text = "Email:", Location = new Point(20,110), Font = fontePadrao, ForeColor = Color.DarkBlue };
 
            // Criando os TextBox
            txtId = new TextBox { Location = new Point(20,30), Width = 220, Font = fonteAlternativa};

            txtNome = new TextBox { Location = new Point(20,80), Width = 220, Font = fonteAlternativa};

            txtEmail = new TextBox { Location = new Point(20,130), Width = 220, Font = fonteAlternativa};

            // Criando os botões
            btnInserir = CriarBotao("Inserir", new Point(500,30), Color.White);
            btnListar = CriarBotao("Listar", new Point(500,80), Color.White);
            btnAtualizar = CriarBotao("Atualizar", new Point(500,130), Color.White);
            btnDeletar = CriarBotao("Deletar", new Point(500,180), Color.White);

            // Criando Evento dos Botões
            btnInserir.Click += new EventHandler(BotaoInserir_click);
            btnListar.Click += new EventHandler(BotaoListar_click);
            btnAtualizar.Click += new EventHandler(BotaoAtualizar_click);
            btnDeletar.Click += new EventHandler(BotaoDeletar_click);
        
            // Criando a ListBox
            lstUsuarios = new ListBox
            {
                Location = new Point(20,180),
                Width = 500,
                Height = 150,
                BackColor = Color.DarkBlue,
                ForeColor = Color.White,
            };

            // Adicionando os controles na Janela
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnListar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnDeletar);
            this.Controls.Add(lstUsuarios);

            BotaoListar_click(this, EventArgs.Empty); // Já incia lsitando
        }

        private Button CriarBotao(string texto, Point localizacao, Color color)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = Color.DarkBlue,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
            };
        }

        private void BotaoInserir_click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id,nome,email);

                MessageBox.Show("Usuario inserido com sucesso!","Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                BotaoListar_click(sender, e);
                LimparCampos();
            }
            catch (System.Exception ex)
            {
                
                MessageBox.Show($"Erro ao inserir usuário: {ex.Message}", "Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoAtualizar_click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;

                crud.AtualizarUsuario(id,nome);

                MessageBox.Show($"Usuário atualizado com sucesso!","Suceso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                BotaoListar_click(sender, e);
                LimparCampos();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}","Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BotaoDeletar_click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                crud.DeletarUsuario(id);    

                MessageBox.Show($"Usuário Deletado com sucesso!","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LimparCampos();
                BotaoListar_click(sender, e);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao deletar usuário: {ex.Message}","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void BotaoListar_click(object sender, EventArgs e)
        {
            try
            {
                lstUsuarios.Items.Clear();

                List<string> usuarios = crud.ListarUsuarios();

                if (usuarios.Count > 0)
                {
                    foreach (var usuario in usuarios)
                    {
                        lstUsuarios.Items.Add(usuario);
                    }
                } else
                {
                    MessageBox.Show("Nenhum usuário encontrado!","Erro");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao listar usuários: {ex.Message}","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            // Limpa os campos TextBox
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
        }
    }
}