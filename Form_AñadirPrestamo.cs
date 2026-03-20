using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class Form_AñadirPrestamo : Form
    {
        public string Usuario { get; internal set; }
        public string Libro { get; internal set; }
        public string FechaFin { get; internal set; }
        public string FechaPrestamo { get; internal set; }
        public string EstadoPrestamo { get; internal set; }

        public Form_AñadirPrestamo()
        {
            InitializeComponent();
        }

        private void Form_AñadirPrestamo_Load(object sender, EventArgs e)
        {
            if (EsModoDiseno())
                return;

            dtpPrestamo.Value = DateTime.Now;
            dtpDevolucion.Value = DateTime.Now.AddDays(7);

            CargarLibros();
            CargarUsuarios();
        }

        private bool EsModoDiseno()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void CargarLibros()
        {
            try
            {
                cmbLibro.Items.Clear();

                string ruta = Path.Combine(Application.StartupPath, "mis_libros.csv");

                if (File.Exists(ruta))
                {
                    string[] lineas = File.ReadAllLines(ruta);

                    for (int i = 1; i < lineas.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lineas[i]))
                        {
                            string[] datos = lineas[i].Split(',');

                            if (datos.Length >= 5)
                            {
                                string titulo = datos[0].Trim();
                                string autor = datos[1].Trim();
                                string disponiblesTexto = datos[4].Trim();

                                string[] partes = disponiblesTexto.Split('/');

                                if (partes.Length >= 1)
                                {
                                    int disponibles = 0;
                                    int.TryParse(partes[0].Trim(), out disponibles);

                                    if (disponibles > 0)
                                        cmbLibro.Items.Add(titulo + " - " + autor);
                                }
                            }
                        }
                    }

                    if (cmbLibro.Items.Count > 0)
                        cmbLibro.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                cmbUsuario.Items.Clear();

                string ruta = Path.Combine(Application.StartupPath, "usuarios.txt");

                if (File.Exists(ruta))
                {
                    string[] lineas = File.ReadAllLines(ruta);

                    for (int i = 1; i < lineas.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lineas[i]))
                        {
                            string[] datos = lineas[i].Split(',');

                            if (datos.Length >= 2)
                            {
                                string nombre = datos[0].Trim();
                                string correo = datos[1].Trim();

                                cmbUsuario.Items.Add(nombre + " - " + correo);
                            }
                        }
                    }

                    if (cmbUsuario.Items.Count > 0)
                        cmbUsuario.SelectedIndex = 0;
                }
                else
                {
                    cmbUsuario.Items.Add("Carlos Rodríguez - carlos@gmail.com");
                    cmbUsuario.Items.Add("Ana Martínez - ana@gmail.com");
                    cmbUsuario.Items.Add("Pedro Fernández - pedro@gmail.com");

                    if (cmbUsuario.Items.Count > 0)
                        cmbUsuario.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private bool DescontarDisponibilidadLibro(string libroSeleccionado)
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "mis_libros.csv");

                if (!File.Exists(ruta))
                {
                    MessageBox.Show("No se encontró el archivo mis_libros.csv");
                    return false;
                }

                string[] lineas = File.ReadAllLines(ruta);
                bool actualizado = false;

                for (int i = 1; i < lineas.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lineas[i])) continue;

                    string[] datos = lineas[i].Split(',');

                    if (datos.Length >= 5)
                    {
                        string titulo = datos[0].Trim();
                        string autor = datos[1].Trim();
                        string textoCombo = titulo + " - " + autor;

                        if (textoCombo == libroSeleccionado)
                        {
                            string disponibilidad = datos[4].Trim();
                            string[] partes = disponibilidad.Split('/');

                            if (partes.Length >= 2)
                            {
                                int disponibles = 0;
                                int total = 0;

                                int.TryParse(partes[0].Trim(), out disponibles);
                                int.TryParse(partes[1].Trim(), out total);

                                if (disponibles <= 0)
                                {
                                    MessageBox.Show("Este libro ya no tiene unidades disponibles.");
                                    return false;
                                }

                                disponibles--;
                                datos[4] = disponibles + " / " + total;
                                lineas[i] = string.Join(",", datos);
                                actualizado = true;
                                break;
                            }
                        }
                    }
                }

                if (actualizado)
                {
                    File.WriteAllLines(ruta, lineas);
                    return true;
                }

                MessageBox.Show("No se encontró el libro seleccionado en el archivo.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar disponibilidad: " + ex.Message);
                return false;
            }
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            if (cmbLibro.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un libro.");
                return;
            }

            if (cmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            if (dtpDevolucion.Value.Date < dtpPrestamo.Value.Date)
            {
                MessageBox.Show("La fecha de devolución no puede ser menor que la fecha de préstamo.");
                return;
            }

            string libroSeleccionado = cmbLibro.SelectedItem.ToString();
            string usuarioSeleccionado = cmbUsuario.SelectedItem.ToString();

            bool ok = DescontarDisponibilidadLibro(libroSeleccionado);

            if (!ok) return;

            Libro = libroSeleccionado;
            Usuario = usuarioSeleccionado;
            FechaPrestamo = dtpPrestamo.Value.ToString("dd/MM/yyyy");
            FechaFin = dtpDevolucion.Value.ToString("dd/MM/yyyy");
            EstadoPrestamo = "Activo";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbLibro_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}