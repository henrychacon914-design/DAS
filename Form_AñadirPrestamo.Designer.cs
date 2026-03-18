namespace EL_BIBLIOTECARIO
{
    partial class Form_AñadirPrestamo
    {
        private System.ComponentModel.IContainer components = null;




        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFechaPrestamo = new System.Windows.Forms.Label();
            this.lblFechaDevolucion = new System.Windows.Forms.Label();
            this.lblNotas = new System.Windows.Forms.Label();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.dtpPrestamo = new System.Windows.Forms.DateTimePicker();
            this.dtpDevolucion = new System.Windows.Forms.DateTimePicker();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(139, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Préstamo";
            // 
            // lblLibro
            // 
            this.lblLibro.AutoSize = true;
            this.lblLibro.Location = new System.Drawing.Point(28, 70);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(37, 13);
            this.lblLibro.TabIndex = 1;
            this.lblLibro.Text = "Libro *";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(28, 130);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario *";
            // 
            // lblFechaPrestamo
            // 
            this.lblFechaPrestamo.AutoSize = true;
            this.lblFechaPrestamo.Location = new System.Drawing.Point(28, 190);
            this.lblFechaPrestamo.Name = "lblFechaPrestamo";
            this.lblFechaPrestamo.Size = new System.Drawing.Size(105, 13);
            this.lblFechaPrestamo.TabIndex = 5;
            this.lblFechaPrestamo.Text = "Fecha de préstamo *";
            // 
            // lblFechaDevolucion
            // 
            this.lblFechaDevolucion.AutoSize = true;
            this.lblFechaDevolucion.Location = new System.Drawing.Point(240, 190);
            this.lblFechaDevolucion.Name = "lblFechaDevolucion";
            this.lblFechaDevolucion.Size = new System.Drawing.Size(114, 13);
            this.lblFechaDevolucion.TabIndex = 7;
            this.lblFechaDevolucion.Text = "Fecha de devolución *";
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(28, 250);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(35, 13);
            this.lblNotas.TabIndex = 9;
            this.lblNotas.Text = "Notas";
            // 
            // cmbLibro
            // 
            this.cmbLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibro.Location = new System.Drawing.Point(30, 90);
            this.cmbLibro.Name = "cmbLibro";
            this.cmbLibro.Size = new System.Drawing.Size(420, 21);
            this.cmbLibro.TabIndex = 2;
            this.cmbLibro.SelectedIndexChanged += new System.EventHandler(this.cmbLibro_SelectedIndexChanged);
            this.cmbLibro.Click += new System.EventHandler(this.cmbLibro_SelectedIndexChanged);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.Location = new System.Drawing.Point(30, 150);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(420, 21);
            this.cmbUsuario.TabIndex = 4;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // dtpPrestamo
            // 
            this.dtpPrestamo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrestamo.Location = new System.Drawing.Point(30, 210);
            this.dtpPrestamo.Name = "dtpPrestamo";
            this.dtpPrestamo.Size = new System.Drawing.Size(180, 20);
            this.dtpPrestamo.TabIndex = 6;
            // 
            // dtpDevolucion
            // 
            this.dtpDevolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDevolucion.Location = new System.Drawing.Point(242, 210);
            this.dtpDevolucion.Name = "dtpDevolucion";
            this.dtpDevolucion.Size = new System.Drawing.Size(180, 20);
            this.dtpDevolucion.TabIndex = 8;
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(30, 270);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(420, 70);
            this.txtNotas.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(100, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(282, 360);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(140, 35);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar Préstamo";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrarPrestamo_Click);
            // 
            // Form_AñadirPrestamo
            // 
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblLibro);
            this.Controls.Add(this.cmbLibro);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.lblFechaPrestamo);
            this.Controls.Add(this.dtpPrestamo);
            this.Controls.Add(this.lblFechaDevolucion);
            this.Controls.Add(this.dtpDevolucion);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_AñadirPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Préstamo";
            this.Load += new System.EventHandler(this.Form_AñadirPrestamo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFechaPrestamo;
        private System.Windows.Forms.Label lblFechaDevolucion;
        private System.Windows.Forms.Label lblNotas;

        private System.Windows.Forms.ComboBox cmbLibro;
        private System.Windows.Forms.ComboBox cmbUsuario;

        private System.Windows.Forms.DateTimePicker dtpPrestamo;
        private System.Windows.Forms.DateTimePicker dtpDevolucion;

        private System.Windows.Forms.TextBox txtNotas;

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
    }
}