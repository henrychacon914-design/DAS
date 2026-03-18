using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            AplicarColoresUsuarios();
            usuariosdata.AllowUserToAddRows = false;
        }

        private void CargarUsuarios()
        {
            try
            {
                usuariosdata.Rows.Clear();

                string ruta = Path.Combine(Application.StartupPath, "usuarios.txt");

                if (File.Exists(ruta))
                {
                    string[] lineas = File.ReadAllLines(ruta);

                    for (int i = 1; i < lineas.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lineas[i]))
                        {
                            string[] datos = lineas[i].Split(',');

                            if (datos.Length >= 3)
                            {
                                usuariosdata.Rows.Add(datos[0], datos[1], datos[2]);
                            }
                        }
                    }
                }
                else
                {
                    CargarUsuariosPrueba();
                    GuardarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void CargarUsuariosPrueba()
        {
            usuariosdata.Rows.Clear();

            usuariosdata.Rows.Add("Carlos Rodríguez Pérez", "carlos@email.com", "Activo");
            usuariosdata.Rows.Add("María García López", "maria@email.com", "Activo");
            usuariosdata.Rows.Add("Juan Martínez", "juan@email.com", "Inactivo");
            usuariosdata.Rows.Add("Ana Torres", "ana@email.com", "Activo");
            usuariosdata.Rows.Add("Pedro Fernández", "pedro@email.com", "Suspendido");
        }

        private void GuardarUsuarios()
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "usuarios.txt");

                using (StreamWriter sw = new StreamWriter(ruta, false))
                {
                    sw.WriteLine("Nombre,Correo,Estado");

                    foreach (DataGridViewRow row in usuariosdata.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string nombre = row.Cells[0].Value?.ToString() ?? "";
                            string correo = row.Cells[1].Value?.ToString() ?? "";
                            string estado = row.Cells[2].Value?.ToString() ?? "";

                            sw.WriteLine($"{nombre},{correo},{estado}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuarios: " + ex.Message);
            }
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            FormAñadirUsuario frm = new FormAñadirUsuario();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(frm.NombreUsuario) ||
                    string.IsNullOrWhiteSpace(frm.CorreoUsuario) ||
                    string.IsNullOrWhiteSpace(frm.EstadoUsuario))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                if (CorreoYaExiste(frm.CorreoUsuario))
                {
                    MessageBox.Show("Ese correo ya existe.");
                    return;
                }

                usuariosdata.Rows.Add(
                    frm.NombreUsuario,
                    frm.CorreoUsuario,
                    frm.EstadoUsuario
                );

                AplicarColoresUsuarios();
                GuardarUsuarios();

                MessageBox.Show("Usuario agregado correctamente.");
            }
        }

        private bool CorreoYaExiste(string correo)
        {
            foreach (DataGridViewRow row in usuariosdata.Rows)
            {
                if (row.IsNewRow) continue;

                string correoActual = row.Cells[1].Value?.ToString() ?? "";

                if (correoActual.Trim().ToLower() == correo.Trim().ToLower())
                    return true;
            }

            return false;
        }

        private bool CorreoYaExisteEditando(string correo, int filaActual)
        {
            for (int i = 0; i < usuariosdata.Rows.Count; i++)
            {
                if (usuariosdata.Rows[i].IsNewRow) continue;
                if (i == filaActual) continue;

                string correoActual = usuariosdata.Rows[i].Cells[1].Value?.ToString() ?? "";

                if (correoActual.Trim().ToLower() == correo.Trim().ToLower())
                    return true;
            }

            return false;
        }

        private void AplicarColoresUsuarios()
        {
            foreach (DataGridViewRow row in usuariosdata.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[2].Value != null)
                {
                    string estado = row.Cells[2].Value.ToString();

                    if (estado == "Activo")
                        row.Cells[2].Style.ForeColor = Color.SeaGreen;
                    else if (estado == "Inactivo")
                        row.Cells[2].Style.ForeColor = Color.Orange;
                    else if (estado == "Suspendido")
                        row.Cells[2].Style.ForeColor = Color.Red;

                    row.Cells[2].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in usuariosdata.Rows)
            {
                if (row.IsNewRow) continue;

                string nombre = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string correo = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells[2].Value?.ToString().ToLower() ?? "";

                bool coincide =
                    nombre.Contains(texto) ||
                    correo.Contains(texto) ||
                    estado.Contains(texto);

                row.Visible = coincide || string.IsNullOrEmpty(texto);
            }
        }

        private void usuariosdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && usuariosdata.Columns[e.ColumnIndex].Name == "Acciones2")
            {
                usuariosdata.CurrentCell = usuariosdata.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuariosdata.CurrentRow == null || usuariosdata.CurrentRow.IsNewRow)
                return;

            int fila = usuariosdata.CurrentRow.Index;

            FormAñadirUsuario frm = new FormAñadirUsuario();

            frm.txtNombre.Text = usuariosdata.CurrentRow.Cells[0].Value?.ToString();
            frm.txtEmail.Text = usuariosdata.CurrentRow.Cells[1].Value?.ToString();
            frm.cmbEstado.Text = usuariosdata.CurrentRow.Cells[2].Value?.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(frm.NombreUsuario) ||
                    string.IsNullOrWhiteSpace(frm.CorreoUsuario) ||
                    string.IsNullOrWhiteSpace(frm.EstadoUsuario))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                if (CorreoYaExisteEditando(frm.CorreoUsuario, fila))
                {
                    MessageBox.Show("Ese correo ya existe en otro usuario.");
                    return;
                }

                usuariosdata.CurrentRow.Cells[0].Value = frm.NombreUsuario;
                usuariosdata.CurrentRow.Cells[1].Value = frm.CorreoUsuario;
                usuariosdata.CurrentRow.Cells[2].Value = frm.EstadoUsuario;

                AplicarColoresUsuarios();
                GuardarUsuarios();

                MessageBox.Show("Usuario actualizado correctamente.");
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuariosdata.CurrentRow == null || usuariosdata.CurrentRow.IsNewRow)
                return;

            string nombreUsuario = usuariosdata.CurrentRow.Cells[0].Value?.ToString() ?? "";

            DialogResult respuesta = MessageBox.Show(
                $"¿Deseas eliminar al usuario '{nombreUsuario}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                usuariosdata.Rows.Remove(usuariosdata.CurrentRow);
                GuardarUsuarios();
                MessageBox.Show("Usuario eliminado correctamente.");
            }
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarUsuarios();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower();

            foreach (DataGridViewRow row in usuariosdata.Rows)
            {
                if (row.IsNewRow) continue;

                string nombre = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string correo = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells[2].Value?.ToString().ToLower() ?? "";

                bool coincide =
                    nombre.Contains(texto) ||
                    correo.Contains(texto) ||
                    estado.Contains(texto);

                row.Visible = coincide || string.IsNullOrEmpty(texto);
            }
        }
    }
    }
