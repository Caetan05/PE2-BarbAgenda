using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2
{
    public partial class Form1 : Form
    {

        private bool menuExpandido = false;
        private int tamanhoOriginalX;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public string condicao = "";

        public Form1()
        {
            InitializeComponent();
            tamanhoOriginalX = panelLateralAberto.Width;

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            panelMenuGoldOption.Visible = false;
            verticalMenuPanel.Visible = true;
            if (condicao != "Home")
            {
                panelProxCliente.Visible = false;
                labelProxCliente.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelLateralAberto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Button buttonMenu = new Button();


            if (menuExpandido)
            {
                FormAnimation.ExpandMenuPanel(panelLateralAberto, tamanhoOriginalX, 50);
                menuExpandido = false;
                // Resto do código
            }
            else
            {
                FormAnimation.ExpandMenuPanel(panelLateralAberto, 50, tamanhoOriginalX);
                menuExpandido = true;
                // Resto do código
            }

        }

        private void homeLabel_Click(object sender, EventArgs e)
        {

        }

        private void labelDashboard_Click(object sender, EventArgs e)
        {
        
        }

        private void labelMenu_Click(object sender, EventArgs e)
        {

        }

        private void labelHorario_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            labelDiaMesAno.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int raioArredondamento = 20; // Ajuste o raio de arredondamento conforme necessário

            // Criar um retângulo que corresponda ao tamanho do painel
            Rectangle painelRetangulo = panelMenuGoldOption.ClientRectangle;

            // Criar um objeto GraphicsPath para definir a região de clipe arredondada
            GraphicsPath path = new GraphicsPath();
            path.AddArc(painelRetangulo.Left, painelRetangulo.Top, raioArredondamento * 2, raioArredondamento * 2, 180, 90);
            path.AddLine(painelRetangulo.Left + raioArredondamento, painelRetangulo.Top, painelRetangulo.Right, painelRetangulo.Top);
            path.AddLine(painelRetangulo.Right, painelRetangulo.Top, painelRetangulo.Right, painelRetangulo.Bottom);
            path.AddLine(painelRetangulo.Right, painelRetangulo.Bottom, painelRetangulo.Left + raioArredondamento, painelRetangulo.Bottom);
            path.AddArc(painelRetangulo.Left, painelRetangulo.Bottom - raioArredondamento * 2, raioArredondamento * 2, raioArredondamento * 2, 90, 90);

            // Definir a região de clipe do painel com o GraphicsPath
            panelMenuGoldOption.Region = new Region(path);

            // Habilitar o antialiasing para tornar as bordas suaves
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Preencher o painel com uma cor de fundo
            using (SolidBrush brush = new SolidBrush(panelMenuGoldOption.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            condicao = "dashboard";

            panelMenuGoldOption.Visible = true;
            panelMenuGoldOption.Location = new Point(0, 153);
            panelProxCliente.Visible = false;
            labelProxCliente.Visible = false;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            condicao = "Home";

            panelMenuGoldOption.Visible = true;
            panelMenuGoldOption.Location = new Point(0, 71);
            panelProxCliente.Visible = true;
            labelProxCliente.Visible = true;

        }


        private void labelHeaderNome_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelMenuGoldOption.Visible = true;
            panelMenuGoldOption.Location = new Point(0, 243);
            panelProxCliente.Visible = false;
            labelProxCliente.Visible = false;
        }

        private void panelSuperiorAmarelo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelProxCliente_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelHorarioProxCliente_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread threadCadastro = new Thread(AbrirFormCadastro);
            threadCadastro.SetApartmentState(ApartmentState.STA);
            threadCadastro.Start();
            this.Close();
        }

        private void AbrirFormCadastro()
        {
            Application.Run(new frmCadastrarCliente());
        }
    }
}
