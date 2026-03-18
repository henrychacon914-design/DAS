using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class FormPrestamos : Form
    {
        public FormPrestamos()
        {
            InitializeComponent();
        }

        public void RefrescarPrestamos()
        {
            txtBuscar.Clear();
            RecargarDGVDesdeArchivo();
        }

        private bool AumentarDisponibilidadLibro(string libroSeleccionado)
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

                        string tituloPrestamo = libroSeleccionado;
                        if (libroSeleccionado.Contains(" - "))
                        {
                            tituloPrestamo = libroSeleccionado.Split('-')[0].Trim();
                        }

                        if (titulo == tituloPrestamo)
                        {
                            string disponibilidad = datos[4].Trim();
                            string[] partes = disponibilidad.Split('/');

                            if (partes.Length >= 2)
                            {
                                int disponibles = 0;
                                int total = 0;

                                int.TryParse(partes[0].Trim(), out disponibles);
                                int.TryParse(partes[1].Trim(), out total);

                                if (disponibles < total)
                                {
                                    disponibles++;
                                    datos[4] = disponibles + " / " + total;
                                    lineas[i] = string.Join(",", datos);
                                    actualizado = true;
                                }

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

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al devolver libro: " + ex.Message);
                return false;
            }
        }

        private void GuardarTodosLosPrestamos()
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "prestamos.csv");

                using (StreamWriter sw = new StreamWriter(ruta, false))
                {
                    sw.WriteLine("Libro,Usuario,FechaPrestamo,FechaDevolucion,Estado");

                    foreach (DataGridViewRow row in prestam.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string libro = row.Cells[0].Value?.ToString() ?? "";
                            string usuario = row.Cells[1].Value?.ToString() ?? "";
                            string fechaPrestamo = row.Cells[2].Value?.ToString() ?? "";
                            string fechaDevolucion = row.Cells[3].Value?.ToString() ?? "";
                            string estado = row.Cells[4].Value?.ToString() ?? "";

                            sw.WriteLine($"{libro},{usuario},{fechaPrestamo},{fechaDevolucion},{estado}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar préstamos: " + ex.Message);
            }
        }

        private void GuardarPrestamoEnArchivo(string libro, string usuario, string fechaPrestamo, string fechaDevolucion, string estado)
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "prestamos.csv");

                if (!File.Exists(ruta))
                {
                    using (StreamWriter sw = new StreamWriter(ruta))
                    {
                        sw.WriteLine("Libro,Usuario,FechaPrestamo,FechaDevolucion,Estado");
                    }
                }

                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine($"{libro},{usuario},{fechaPrestamo},{fechaDevolucion},{estado}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar préstamo: " + ex.Message);
            }
        }

        private void RecargarDGVDesdeArchivo()
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "prestamos.csv");

                prestam.Rows.Clear();

                if (!File.Exists(ruta))
                {
                    AplicarColoresPrestamos();
                    return;
                }

                string[] lineas = File.ReadAllLines(ruta);

                for (int i = 1; i < lineas.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lineas[i]))
                    {
                        string[] datos = lineas[i].Split(',');

                        if (datos.Length >= 5)
                        {
                            int fila = prestam.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4]);
                            prestam.Rows[fila].Visible = true;
                        }
                    }
                }

                AplicarColoresPrestamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar préstamos: " + ex.Message);
            }
        }

        private void DevolverPrestamoSeleccionado(int rowIndex)
        {
            if (rowIndex < 0 || prestam.Rows[rowIndex].IsNewRow)
                return;

            string estado = prestam.Rows[rowIndex].Cells[4].Value?.ToString();

            if (estado == "Devuelto")
            {
                MessageBox.Show("Este préstamo ya fue devuelto.");
                return;
            }

            string libro = prestam.Rows[rowIndex].Cells[0].Value?.ToString();

            DialogResult r = MessageBox.Show(
                "¿Deseas marcar este préstamo como devuelto?",
                "Confirmar devolución",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                bool ok = AumentarDisponibilidadLibro(libro);

                if (!ok)
                {
                    MessageBox.Show("No se pudo actualizar la disponibilidad del libro.");
                    return;
                }

                prestam.Rows[rowIndex].Cells[4].Value = "Devuelto";
                GuardarTodosLosPrestamos();
                RecargarDGVDesdeArchivo();

                MessageBox.Show("Libro devuelto correctamente.");
            }
        }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            prestam.AllowUserToAddRows = false;
            RecargarDGVDesdeArchivo();
        }

        private void FormPrestamos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefrescarPrestamos();
            }
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            Form_AñadirPrestamo frm = new Form_AñadirPrestamo();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                GuardarPrestamoEnArchivo(
                    frm.Libro,
                    frm.Usuario,
                    frm.FechaPrestamo,
                    frm.FechaFin,
                    frm.EstadoPrestamo
                );

                RecargarDGVDesdeArchivo();

                MessageBox.Show("Préstamo registrado exitosamente.");
            }
        }

        private void AplicarColoresPrestamos()
        {
            foreach (DataGridViewRow row in prestam.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[4].Value != null)
                {
                    string estado = row.Cells[4].Value.ToString();

                    if (estado == "Activo")
                    {
                        row.Cells[4].Style.ForeColor = Color.FromArgb(16, 185, 129);
                        row.Cells[4].Style.BackColor = Color.FromArgb(236, 253, 245);
                    }
                    else if (estado == "Vencido")
                    {
                        row.Cells[4].Style.ForeColor = Color.FromArgb(239, 68, 68);
                        row.Cells[4].Style.BackColor = Color.FromArgb(254, 242, 242);
                    }
                    else if (estado == "Devuelto")
                    {
                        row.Cells[4].Style.ForeColor = Color.FromArgb(99, 102, 241);
                        row.Cells[4].Style.BackColor = Color.FromArgb(238, 242, 255);
                    }

                    row.Cells[4].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarPrestamos();
        }

        private void BuscarPrestamos()
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in prestam.Rows)
            {
                if (row.IsNewRow) continue;

                string libro = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string usuario = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string fechaPrestamo = row.Cells[2].Value?.ToString().ToLower() ?? "";
                string fechaDevolucion = row.Cells[3].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells[4].Value?.ToString().ToLower() ?? "";

                bool coincide =
                    libro.Contains(textoBusqueda) ||
                    usuario.Contains(textoBusqueda) ||
                    fechaPrestamo.Contains(textoBusqueda) ||
                    fechaDevolucion.Contains(textoBusqueda) ||
                    estado.Contains(textoBusqueda);

                row.Visible = coincide || string.IsNullOrEmpty(textoBusqueda);
            }
        }

        private void prestam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && prestam.Columns[e.ColumnIndex].Name == "devolver")
            {
                DevolverPrestamoSeleccionado(e.RowIndex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}