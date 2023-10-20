using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PE2
{
    public partial class frmCadastrarCliente : Form
    {
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        string connectionString = "server=localhost;User Id=root;password='joao5227';database=barbagenda";

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager(connectionString);

            try
            {
                dbManager.OpenConnection();

                string nome = txtNome.Text;
                string cpf = txtCPF.Text;
                string telefone = txtTelefone.Text;
                string email = txtEmail.Text;

                if (!int.TryParse(txtIdade.Text, out int idade))
                {
                    MessageBox.Show("Idade inválida. Por favor, insira um valor numérico.");
                    return;
                }

                // Crie uma instrução SQL para inserir o cliente no banco de dados
                string sql = "INSERT INTO clientes (nome, cpf, telefone, email, idade) VALUES (@nome, @cpf, @telefone, @email, @idade)";

                using (MySqlCommand cmd = new MySqlCommand(sql, dbManager.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@idade", idade);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente cadastrado com sucesso!");

                // Limpe os campos após o cadastro
                txtNome.Clear();
                txtCPF.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtIdade.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }
    }
}
