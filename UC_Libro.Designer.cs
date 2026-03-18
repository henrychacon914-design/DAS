using System.Drawing;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace EL_BIBLIOTECARIO  
{
     public partial class UC_Libro
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox picLibro;
        private Label lblTitulo;
        private Label lblAutor;
        private Label lblGenero;
        private Label lblISBN;
        private Label lblDisponibles;
        private Button btnOpciones;

        private ContextMenuStrip menuOpciones;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picLibro = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.menuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picLibro)).BeginInit();
            this.menuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLibro
            // 
            this.picLibro.BackColor = System.Drawing.Color.LightGray;
            this.picLibro.Location = new System.Drawing.Point(10, 15);
            this.picLibro.Name = "picLibro";
            this.picLibro.Size = new System.Drawing.Size(40, 40);
            this.picLibro.TabIndex = 1;
            this.picLibro.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(70, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 19);
            this.lblTitulo.TabIndex = 2;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(300, 25);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(0, 13);
            this.lblAutor.TabIndex = 3;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.BackColor = System.Drawing.Color.LightBlue;
            this.lblGenero.Location = new System.Drawing.Point(500, 25);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblGenero.Size = new System.Drawing.Size(12, 17);
            this.lblGenero.TabIndex = 4;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(650, 25);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(0, 13);
            this.lblISBN.TabIndex = 5;
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.ForeColor = System.Drawing.Color.Green;
            this.lblDisponibles.Location = new System.Drawing.Point(850, 25);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(0, 13);
            this.lblDisponibles.TabIndex = 6;
            // 
            // btnOpciones
            // 
            this.btnOpciones.Location = new System.Drawing.Point(950, 20);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(35, 30);
            this.btnOpciones.TabIndex = 7;
            this.btnOpciones.Text = "...";
            // 
            // menuOpciones
            // 
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(142, 60);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(141, 28);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(141, 28);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // UC_Libro
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picLibro);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.btnOpciones);
            this.Name = "UC_Libro";
            this.Size = new System.Drawing.Size(1155, 70);
            ((System.ComponentModel.ISupportInitialize)(this.picLibro)).EndInit();
            this.menuOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
