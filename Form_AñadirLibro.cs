using System;
using System.Drawing;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class Form_AñadirLibro : Form
    {
        
        public string TituloLibro => txtTituloLibro.Text;
        public string AutorLibro => txtAutor.Text;
        public string GeneroLibro => txtGenero.Text;
        public string CodigoLibro => txtCodigo.Text;
        public string CantidadLibro => txtCantidad.Text;
       
        public string rutaImagenSeleccionada = "";

        public Form_AñadirLibro()
        {
            InitializeComponent();
        }

        
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivos de Imagen (*.jpg;*.png)|*.jpg;*.png";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                picPortada.Image = Image.FromFile(abrir.FileName);
                rutaImagenSeleccionada = abrir.FileName;
            }
        }

       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtTituloLibro.Text))
            {
                MessageBox.Show("Por favor, ingresa al menos el título del libro.", "Campo requerido");
                return;
            }

            
            this.DialogResult = DialogResult.OK;
            this.Hide();

        }

       
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEditorial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTituloLibro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}