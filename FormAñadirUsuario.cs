using System;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class FormAñadirUsuario : Form
    {
        public string NombreUsuario { get; private set; }
        public string CorreoUsuario { get; private set; }
        public string EstadoUsuario { get; private set; }

        public FormAñadirUsuario()
        {
            InitializeComponent();

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.Items.Add("Suspendido");

            cmbMembresia.Items.Clear();
            cmbMembresia.Items.Add("Estudiante");
            cmbMembresia.Items.Add("Docente");
            cmbMembresia.Items.Add("General");

            cmbEstado.SelectedIndex = 0;
            cmbMembresia.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el correo.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Seleccione el estado del usuario.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbMembresia.Text))
            {
                MessageBox.Show("Seleccione el tipo de membresía.");
                return;
            }

            NombreUsuario = txtNombre.Text.Trim();
            CorreoUsuario = txtEmail.Text.Trim();
            EstadoUsuario = cmbEstado.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormAñadirUsuario_Load(object sender, EventArgs e)
        {
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}