using System;
using System.Drawing;
using System.Windows.Forms;

namespace EL_BIBLIOTECARIO
{
    public partial class FormEditarLibro : Form
    {
        // Definición de controles (puedes ajustarlos desde el diseñador después si prefieres)
        public TextBox txtTitulo, txtAutor, txtISBN, txtEditorial, txtAnio, txtCopias, txtURL;
        public ComboBox cbGenero;
        Button btnGuardar, btnCancelar;

        public FormEditarLibro()
        {
            InitializeComponent();
            ConfigurarDiseno();
        }

        private void ConfigurarDiseno()
        {
            // Propiedades de la Ventana
            this.Text = "Editar Libro";
            this.Size = new Size(500, 650);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 10F);

            // Título Principal
            Label lblHeader = new Label { Text = "Editar Libro", Font = new Font("Segoe UI", 16F, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };

            // --- CAMPOS ---
            // Título (Largo total)
            CrearEtiqueta("Título *", 20, 70);
            txtTitulo = CrearTextBox(20, 95, 440);

            // Autor e ISBN (Dos columnas)
            CrearEtiqueta("Autor *", 20, 150);
            txtAutor = CrearTextBox(20, 175, 210);

            CrearEtiqueta("ISBN *", 250, 150);
            txtISBN = CrearTextBox(250, 175, 210);

            // Género y Editorial
            CrearEtiqueta("Género *", 20, 230);
            cbGenero = new ComboBox { Location = new Point(20, 255), Width = 210, DropDownStyle = ComboBoxStyle.DropDownList };
            cbGenero.Items.AddRange(new string[] { "Ficción", "Ciencia", "Filosofía", "Historia" });

            CrearEtiqueta("Editorial", 250, 230);
            txtEditorial = CrearTextBox(250, 255, 210);

            // Año y Copias
            CrearEtiqueta("Año de publicación", 20, 310);
            txtAnio = CrearTextBox(20, 335, 210);

            CrearEtiqueta("Copias totales *", 250, 310);
            txtCopias = CrearTextBox(250, 335, 210);

            // URL Portada
            CrearEtiqueta("URL de portada", 20, 390);
            txtURL = CrearTextBox(20, 415, 440);

            // --- BOTONES ---
            btnGuardar = new Button
            {
                Text = "Guardar Cambios",
                Location = new Point(20, 500),
                Size = new Size(440, 45),
                BackColor = Color.FromArgb(0, 123, 255), // Azul moderno
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(20, 550),
                Size = new Size(440, 30),
                FlatStyle = FlatStyle.Flat
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => { this.Close(); };

            // Agregar al formulario
            this.Controls.Add(lblHeader);
            this.Controls.Add(cbGenero);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }

        // Métodos de ayuda para crear diseño rápido
        private void CrearEtiqueta(string texto, int x, int y)
        {
            Label lbl = new Label { Text = texto, Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            this.Controls.Add(lbl);
        }

        private TextBox CrearTextBox(int x, int y, int ancho)
        {
            TextBox txt = new TextBox { Location = new Point(x, y), Width = ancho, BorderStyle = BorderStyle.FixedSingle };
            this.Controls.Add(txt);
            return txt;
        }
    }
}