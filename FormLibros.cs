using EL_BIBLIOTECARIO;
using System;
using System.Windows.Forms;
using System.IO;

namespace EL_BIBLIOTECARIO  
{
    public partial class FormLibros : Form
    {
        public object txtTituloLibro { get; private set; }

        public FormLibros()
        {
            InitializeComponent();
        }

        private void FormLibros_Load(object sender, EventArgs e)
        { 
           CargarDatosAlIniciar(); 
        
        Librosdata.Columns["Acciones"].Width = 40;
             Librosdata.Columns["Acciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
             Librosdata.Columns["Acciones"].DefaultCellStyle.NullValue = "...";

            Librosdata.Rows.Add("Cien años de soledad",
                "Gabriel García Márquez",
                "Ficción",
                "978-0-06",
                "3 / 5");

            Librosdata.Rows.Add("Don Quijote de la Mancha",
                "Miguel de Cervantes",
                "Ficción",
                "978-84-376",
                "2 / 3");

            Librosdata.Rows.Add("Breve historia del tiempo",
                "Stephen Hawking",
                "Ciencia",
                "978-0-553",
                "4 / 4");

            Librosdata.Rows.Add("El arte de la guerra",
                "Sun Tzu",
                "Filosofía",
                "978-84-9",
                "1 / 2");

            Librosdata.AllowUserToAddRows = false;
        }

        private void CargarDatosAlIniciar()
        {
          

            string ruta = Path.Combine(Application.StartupPath, "mis_libros.csv");

            if (File.Exists(ruta))
            {
                try
                {
                    string[] lineas = File.ReadAllLines(ruta);
                    Librosdata.Rows.Clear();

                  
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lineas[i]))
                        {
                            string[] datos = lineas[i].Split(',');
                            if (datos.Length >= 5)
                            {
                                Librosdata.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos guardados: " + ex.Message);
                }
            }
        }
        

        private void Librosdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == Librosdata.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
               
                contextMenuStrip1.Show(Cursor.Position);

                
                Librosdata.CurrentCell = Librosdata.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditarLibro ventana = new FormEditarLibro();

            ventana.txtTitulo.Text = Librosdata.CurrentRow.Cells["Libro"].Value.ToString();
            ventana.txtAutor.Text = Librosdata.CurrentRow.Cells["Autor"].Value.ToString();
            ventana.txtISBN.Text = Librosdata.CurrentRow.Cells["Codigo"].Value.ToString();
            ventana.cbGenero.Text = Librosdata.CurrentRow.Cells["Genero"].Value.ToString();
            ventana.txtCopias.Text = Librosdata.CurrentRow.Cells["Disponibles"].Value.ToString();

            if (ventana.ShowDialog() == DialogResult.OK)
            {
              
                Librosdata.CurrentRow.Cells["Libro"].Value = ventana.txtTitulo.Text;
                Librosdata.CurrentRow.Cells["Autor"].Value = ventana.txtAutor.Text;
                Librosdata.CurrentRow.Cells["Genero"].Value = ventana.cbGenero.Text;
                Librosdata.CurrentRow.Cells["Codigo"].Value = ventana.txtISBN.Text;
                Librosdata.CurrentRow.Cells["Disponibles"].Value = ventana.txtCopias.Text;

                MessageBox.Show("¡Libro actualizado correctamente!");
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        {
                
            if (Librosdata.CurrentRow != null)
            {
                
                string tituloLibro = Librosdata.CurrentRow.Cells["Libro"].Value.ToString();

                
                DialogResult respuesta = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar el libro '{tituloLibro}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

               
                if (respuesta == DialogResult.Yes)
                {
                   
                    Librosdata.Rows.Remove(Librosdata.CurrentRow);

                   
                    MessageBox.Show("Libro eliminado correctamente.");

                    
                }
            }
        }
    }
            
        
        private void libroagre_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }
            private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            
                Form_AñadirLibro frm = new Form_AñadirLibro();

            if (frm.ShowDialog() == DialogResult.OK)
            {
  
                Librosdata.Rows.Add(new object[] 
                
                                     {  frm.TituloLibro,
                                        frm.AutorLibro,
                                        frm.GeneroLibro,
                                        frm.CodigoLibro,
                                        frm.CantidadLibro + " / " + frm.CantidadLibro});

                MessageBox.Show("Libro agregado exitosamente");
            }
        }

        private void importarlibro_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos CSV (*.csv)|*.csv";
            ofd.Title = "Seleccionar Lista de Libros";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lineas = File.ReadAllLines(ofd.FileName);
                    Librosdata.Rows.Clear();

                  
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lineas[i]))
                        {
                            
                            char separador = lineas[i].Contains(";") ? ';' : ',';
                            string[] celdas = lineas[i].Split(separador);

                            if (celdas.Length >= 5)
                            {
                                Librosdata.Rows.Add(celdas[0], celdas[1], celdas[2], celdas[3], celdas[4]);
                            }
                        }
                    }
                    MessageBox.Show("¡Se han cargado 50 libros correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar el archivo: " + ex.Message);
                }
            }
        }
        private void GuardarDatosLocalmente()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("mis_libros.csv"))
                {
                    
                    sw.WriteLine("Título,Autor,Genero,Codigo,Disponibilidad");

                    foreach (DataGridViewRow row in Librosdata.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            
                            string linea = $"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value},{row.Cells[4].Value}";
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al auto-guardar: " + ex.Message);
            }
        }

        private void FormLibros_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarDatosLocalmente(); 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower();

            foreach (DataGridViewRow row in Librosdata.Rows)
            {
                if (row.IsNewRow) continue;

                string titulo = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string autor = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string genero = row.Cells[2].Value?.ToString().ToLower() ?? "";
                string codigo = row.Cells[3].Value?.ToString().ToLower() ?? "";

                bool coincide =
                    titulo.Contains(texto) ||
                    autor.Contains(texto) ||
                    genero.Contains(texto) ||
                    codigo.Contains(texto);

                row.Visible = coincide || string.IsNullOrEmpty(texto);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
  
 

 
    
    
