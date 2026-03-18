using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EL_BIBLIOTECARIO
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarTotales();
            ActualizarDashboard();
        }

        private void CargarTotales()
        {
            lblTotalLibros.Text = ContarRegistros("mis_libros.csv").ToString();
            lblTotalPrestamos.Text = ContarRegistros("prestamos.csv").ToString();
            lblTotalUsuarios.Text = ContarRegistros("usuarios.txt").ToString();
        }

        private int ContarRegistros(string archivo)
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, archivo);

                if (!File.Exists(ruta))
                    return 0;

                string[] lineas = File.ReadAllLines(ruta);

                if (lineas.Length <= 1)
                    return 0;

                return lineas.Length - 1;
            }
            catch
            {
                return 0;
            }
        }

        public void ActualizarDashboard()
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "prestamos.csv");

                if (!File.Exists(ruta))
                    return;

                string[] lineas = File.ReadAllLines(ruta);

                Dictionary<string, int> contadorLibros = new Dictionary<string, int>();
                Dictionary<string, int> contadorUsuarios = new Dictionary<string, int>();

                for (int i = 1; i < lineas.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lineas[i]))
                    {
                        string[] datos = lineas[i].Split(',');

                        if (datos.Length >= 2)
                        {
                            string libro = datos[0].Trim();
                            string usuario = datos[1].Trim();

                            if (contadorLibros.ContainsKey(libro))
                                contadorLibros[libro]++;
                            else
                                contadorLibros[libro] = 1;

                            if (contadorUsuarios.ContainsKey(usuario))
                                contadorUsuarios[usuario]++;
                            else
                                contadorUsuarios[usuario] = 1;
                        }
                    }
                }

                var topLibros = contadorLibros
                    .OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToList();

                var topUsuarios = contadorUsuarios
                    .OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToList();

                int maxLibros = topLibros.Count > 0 ? topLibros[0].Value : 1;
                int maxUsuarios = topUsuarios.Count > 0 ? topUsuarios[0].Value : 1;

                if (topLibros.Count >= 1)
                {
                    libro1.Text = topLibros[0].Key;
                    guna2ProgressBar1.Maximum = maxLibros;
                    guna2ProgressBar1.Value = topLibros[0].Value;
                }

                if (topLibros.Count >= 2)
                {
                    libro2.Text = topLibros[1].Key;
                    guna2ProgressBar2.Maximum = maxLibros;
                    guna2ProgressBar2.Value = topLibros[1].Value;
                }

                if (topLibros.Count >= 3)
                {
                    libro3.Text = topLibros[2].Key;
                    guna2ProgressBar3.Maximum = maxLibros;
                    guna2ProgressBar3.Value = topLibros[2].Value;
                }

               
                if (topUsuarios.Count >= 1)
                {
                    usu1.Text = topUsuarios[0].Key;
                    guna2ProgressBar4.Maximum = maxUsuarios;
                    guna2ProgressBar4.Value = topUsuarios[0].Value;
                }

                if (topUsuarios.Count >= 2)
                {
                    usu2.Text = topUsuarios[1].Key;
                    guna2ProgressBar5.Maximum = maxUsuarios;
                    guna2ProgressBar5.Value = topUsuarios[1].Value;
                }

                if (topUsuarios.Count >= 3)
                {
                    usu3.Text = topUsuarios[2].Key;
                    guna2ProgressBar6.Maximum = maxUsuarios;
                    guna2ProgressBar6.Value = topUsuarios[2].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dashboard: " + ex.Message);
            }
        }

        private void FormInicio_Load_1(object sender, EventArgs e) { }
        private void label32_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label27_Click(object sender, EventArgs e) { }
        private void guna2PictureBox4_Click(object sender, EventArgs e) { }
    }
}