using EL_BIBLOTECARIO;
using System;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class Sistema_de_gestion_bibliotecaria : Form
    {
        public Sistema_de_gestion_bibliotecaria()
        {
            InitializeComponent();
            AbrirFormHijo(new FormInicio());
        }

        private void AbrirFormHijo(Form formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(formHijo);
            this.panelContenedor.Tag = formHijo;
            formHijo.Show();
        }



        private void btnInicio_Click(object sender, EventArgs e)
        {

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);


            FormInicio fh = new FormInicio();


            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;

            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            FormLibros fl = new FormLibros();

            // Asegúrate de que FormLibros hereda de Form o Control
            fl.TopLevel = false;
            fl.FormBorderStyle = FormBorderStyle.None;
            fl.Dock = DockStyle.Fill;

            this.panelContenedor.Controls.Add(fl);
            this.panelContenedor.Tag = fl;
            fl.Show();
        }
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FormPrestamos());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FormUsuarios());
        }



        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            
            DialogResult confirmacion = MessageBox.Show("¿Seguro que desea salir?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
               
                Application.Exit();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema EL BIBLIOTECARIO\n© 2026 Henry_Chacón\nTodos los derechos reservados");
        }
    }
    }

    public partial class FormLibros : Form
    {
        // ...
    }
