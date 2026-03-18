using System;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lógica de acceso
            if (txtUser.Text == "admin" && txtPass.Text == "123")
            {
                this.Hide();
                Sistema_de_gestion_bibliotecaria dash = new Sistema_de_gestion_bibliotecaria();
                dash.Show();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}