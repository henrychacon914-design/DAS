using System;
using System.Drawing;
using System.Windows.Forms;

    namespace EL_BIBLIOTECARIO
    {
    public partial class UC_Libro : UserControl
    {
        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }

        public string Autor
        {
            get { return lblAutor.Text; }
            set { lblAutor.Text = value; }
        }

        public string Genero
        {
            get { return lblGenero.Text; }
            set { lblGenero.Text = value; }
        }

        public string ISBN
        {
            get { return lblISBN.Text; }
            set { lblISBN.Text = value; }
        }

        public string Disponibles
        {
            get { return lblDisponibles.Text; }
            set { lblDisponibles.Text = value; }
        }

        public UC_Libro()
        {
            InitializeComponent();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            menuOpciones.Show(btnOpciones, 0, btnOpciones.Height);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editar libro: " + Titulo);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar libro?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
