namespace UI_GSH
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabPrincipal = new TabControl();
            tabGestion = new TabPage();
            btnQuitar = new Button();
            btnAsignar = new Button();
            groupBox2 = new GroupBox();
            dgvPrestadores = new DataGridView();
            btnBajaPrestador = new Button();
            btnUpdPrestador = new Button();
            btnAltaPrestador = new Button();
            groupBox1 = new GroupBox();
            dgvSucursales = new DataGridView();
            btnBajaSuc = new Button();
            btnUpdSuc = new Button();
            btnAltaSuc = new Button();
            tabAsociaciones = new TabPage();
            groupBox4 = new GroupBox();
            dgvSucursalesPrestador = new DataGridView();
            label2 = new Label();
            cmbPrestadorAsoc = new ComboBox();
            groupBox3 = new GroupBox();
            dgvPrestadoresSucursal = new DataGridView();
            label1 = new Label();
            cmbSucursalAsoc = new ComboBox();
            tabPagos = new TabPage();
            groupBox6 = new GroupBox();
            btnPagar = new Button();
            dgvPagos = new DataGridView();
            groupBox5 = new GroupBox();
            dgvPagosSucPres = new DataGridView();
            btnGenerarPago = new Button();
            cmbTipoPago = new ComboBox();
            label7 = new Label();
            txtImporte = new TextBox();
            dtpVencimiento = new DateTimePicker();
            cmbPrestPago = new ComboBox();
            cmbSucPago = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            tabPrincipal.SuspendLayout();
            tabGestion.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestadores).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSucursales).BeginInit();
            tabAsociaciones.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSucursalesPrestador).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestadoresSucursal).BeginInit();
            tabPagos.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagosSucPres).BeginInit();
            SuspendLayout();
            // 
            // tabPrincipal
            // 
            tabPrincipal.Controls.Add(tabGestion);
            tabPrincipal.Controls.Add(tabAsociaciones);
            tabPrincipal.Controls.Add(tabPagos);
            tabPrincipal.Dock = DockStyle.Fill;
            tabPrincipal.Location = new Point(0, 0);
            tabPrincipal.Name = "tabPrincipal";
            tabPrincipal.SelectedIndex = 0;
            tabPrincipal.Size = new Size(1893, 856);
            tabPrincipal.TabIndex = 0;
            // 
            // tabGestion
            // 
            tabGestion.Controls.Add(btnQuitar);
            tabGestion.Controls.Add(btnAsignar);
            tabGestion.Controls.Add(groupBox2);
            tabGestion.Controls.Add(groupBox1);
            tabGestion.Location = new Point(4, 29);
            tabGestion.Name = "tabGestion";
            tabGestion.Padding = new Padding(3);
            tabGestion.Size = new Size(1885, 823);
            tabGestion.TabIndex = 0;
            tabGestion.Text = "Gestion";
            tabGestion.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(827, 762);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(211, 37);
            btnQuitar.TabIndex = 3;
            btnQuitar.Text = "Quitar Prestador de Sucursal";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(827, 719);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(211, 37);
            btnAsignar.TabIndex = 2;
            btnAsignar.Text = "Asignar Prestador a Sucursal";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvPrestadores);
            groupBox2.Controls.Add(btnBajaPrestador);
            groupBox2.Controls.Add(btnUpdPrestador);
            groupBox2.Controls.Add(btnAltaPrestador);
            groupBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(943, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(926, 687);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Prestadores";
            // 
            // dgvPrestadores
            // 
            dgvPrestadores.AllowUserToAddRows = false;
            dgvPrestadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPrestadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrestadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPrestadores.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPrestadores.Location = new Point(6, 87);
            dgvPrestadores.Name = "dgvPrestadores";
            dgvPrestadores.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPrestadores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPrestadores.RowHeadersWidth = 51;
            dgvPrestadores.Size = new Size(915, 594);
            dgvPrestadores.TabIndex = 6;
            // 
            // btnBajaPrestador
            // 
            btnBajaPrestador.Location = new Point(530, 37);
            btnBajaPrestador.Name = "btnBajaPrestador";
            btnBajaPrestador.Size = new Size(179, 44);
            btnBajaPrestador.TabIndex = 5;
            btnBajaPrestador.Text = "Baja Prestador";
            btnBajaPrestador.UseVisualStyleBackColor = true;
            btnBajaPrestador.Click += btnBajaPrestador_Click;
            // 
            // btnUpdPrestador
            // 
            btnUpdPrestador.Location = new Point(254, 37);
            btnUpdPrestador.Name = "btnUpdPrestador";
            btnUpdPrestador.Size = new Size(236, 44);
            btnUpdPrestador.TabIndex = 4;
            btnUpdPrestador.Text = "Modificar Prestador";
            btnUpdPrestador.UseVisualStyleBackColor = true;
            btnUpdPrestador.Click += btnUpdPrestador_Click;
            // 
            // btnAltaPrestador
            // 
            btnAltaPrestador.Location = new Point(6, 37);
            btnAltaPrestador.Name = "btnAltaPrestador";
            btnAltaPrestador.Size = new Size(203, 44);
            btnAltaPrestador.TabIndex = 3;
            btnAltaPrestador.Text = "Nuevo Prestador";
            btnAltaPrestador.UseVisualStyleBackColor = true;
            btnAltaPrestador.Click += btnAltaPrestador_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvSucursales);
            groupBox1.Controls.Add(btnBajaSuc);
            groupBox1.Controls.Add(btnUpdSuc);
            groupBox1.Controls.Add(btnAltaSuc);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(8, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(929, 687);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sucursales";
            // 
            // dgvSucursales
            // 
            dgvSucursales.AllowUserToAddRows = false;
            dgvSucursales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvSucursales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvSucursales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvSucursales.DefaultCellStyle = dataGridViewCellStyle5;
            dgvSucursales.Location = new Point(6, 87);
            dgvSucursales.Name = "dgvSucursales";
            dgvSucursales.ReadOnly = true;
            dgvSucursales.RowHeadersWidth = 51;
            dgvSucursales.Size = new Size(914, 594);
            dgvSucursales.TabIndex = 3;
            // 
            // btnBajaSuc
            // 
            btnBajaSuc.Location = new Point(492, 37);
            btnBajaSuc.Name = "btnBajaSuc";
            btnBajaSuc.Size = new Size(217, 44);
            btnBajaSuc.TabIndex = 2;
            btnBajaSuc.Text = "Baja Sucursal";
            btnBajaSuc.UseVisualStyleBackColor = true;
            btnBajaSuc.Click += btnBajaSuc_Click;
            // 
            // btnUpdSuc
            // 
            btnUpdSuc.Location = new Point(252, 37);
            btnUpdSuc.Name = "btnUpdSuc";
            btnUpdSuc.Size = new Size(224, 44);
            btnUpdSuc.TabIndex = 1;
            btnUpdSuc.Text = "Modificar Sucursal";
            btnUpdSuc.UseVisualStyleBackColor = true;
            btnUpdSuc.Click += btnUpdSuc_Click;
            // 
            // btnAltaSuc
            // 
            btnAltaSuc.Location = new Point(14, 37);
            btnAltaSuc.Name = "btnAltaSuc";
            btnAltaSuc.Size = new Size(210, 44);
            btnAltaSuc.TabIndex = 0;
            btnAltaSuc.Text = "Nueva Sucursal";
            btnAltaSuc.UseVisualStyleBackColor = true;
            btnAltaSuc.Click += btnAltaSuc_Click;
            // 
            // tabAsociaciones
            // 
            tabAsociaciones.Controls.Add(groupBox4);
            tabAsociaciones.Controls.Add(groupBox3);
            tabAsociaciones.Location = new Point(4, 29);
            tabAsociaciones.Name = "tabAsociaciones";
            tabAsociaciones.Padding = new Padding(3);
            tabAsociaciones.Size = new Size(1885, 823);
            tabAsociaciones.TabIndex = 1;
            tabAsociaciones.Text = "Asociaciones";
            tabAsociaciones.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvSucursalesPrestador);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(cmbPrestadorAsoc);
            groupBox4.Location = new Point(953, 23);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(924, 662);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Sucursales asociadas al Prestador";
            // 
            // dgvSucursalesPrestador
            // 
            dgvSucursalesPrestador.AllowUserToAddRows = false;
            dgvSucursalesPrestador.AllowUserToDeleteRows = false;
            dgvSucursalesPrestador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSucursalesPrestador.Location = new Point(13, 89);
            dgvSucursalesPrestador.Name = "dgvSucursalesPrestador";
            dgvSucursalesPrestador.ReadOnly = true;
            dgvSucursalesPrestador.RowHeadersWidth = 51;
            dgvSucursalesPrestador.Size = new Size(905, 567);
            dgvSucursalesPrestador.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 2;
            label2.Text = "Seleccione Prestador:";
            // 
            // cmbPrestadorAsoc
            // 
            cmbPrestadorAsoc.FormattingEnabled = true;
            cmbPrestadorAsoc.Location = new Point(162, 48);
            cmbPrestadorAsoc.Name = "cmbPrestadorAsoc";
            cmbPrestadorAsoc.Size = new Size(438, 28);
            cmbPrestadorAsoc.TabIndex = 1;
            cmbPrestadorAsoc.SelectedIndexChanged += cmbPrestadorAsoc_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvPrestadoresSucursal);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(cmbSucursalAsoc);
            groupBox3.Location = new Point(24, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(924, 662);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Prestadores asociados a la Sucursal";
            // 
            // dgvPrestadoresSucursal
            // 
            dgvPrestadoresSucursal.AllowUserToAddRows = false;
            dgvPrestadoresSucursal.AllowUserToDeleteRows = false;
            dgvPrestadoresSucursal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestadoresSucursal.Location = new Point(6, 98);
            dgvPrestadoresSucursal.Name = "dgvPrestadoresSucursal";
            dgvPrestadoresSucursal.ReadOnly = true;
            dgvPrestadoresSucursal.RowHeadersWidth = 51;
            dgvPrestadoresSucursal.Size = new Size(912, 558);
            dgvPrestadoresSucursal.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 55);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 1;
            label1.Text = "Seleccione Sucursal:";
            // 
            // cmbSucursalAsoc
            // 
            cmbSucursalAsoc.FormattingEnabled = true;
            cmbSucursalAsoc.Location = new Point(149, 47);
            cmbSucursalAsoc.Name = "cmbSucursalAsoc";
            cmbSucursalAsoc.Size = new Size(438, 28);
            cmbSucursalAsoc.TabIndex = 0;
            cmbSucursalAsoc.SelectedIndexChanged += cmbSucursalAsoc_SelectedIndexChanged;
            // 
            // tabPagos
            // 
            tabPagos.Controls.Add(groupBox6);
            tabPagos.Controls.Add(groupBox5);
            tabPagos.Location = new Point(4, 29);
            tabPagos.Name = "tabPagos";
            tabPagos.Size = new Size(1885, 823);
            tabPagos.TabIndex = 2;
            tabPagos.Text = "Pagos";
            tabPagos.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnPagar);
            groupBox6.Controls.Add(dgvPagos);
            groupBox6.Location = new Point(945, 36);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(937, 758);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Todos los Pagos";
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(717, 706);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(215, 46);
            btnPagar.TabIndex = 12;
            btnPagar.Text = "Pagar Seleccionado";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(12, 26);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(919, 674);
            dgvPagos.TabIndex = 12;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dgvPagosSucPres);
            groupBox5.Controls.Add(btnGenerarPago);
            groupBox5.Controls.Add(cmbTipoPago);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(txtImporte);
            groupBox5.Controls.Add(dtpVencimiento);
            groupBox5.Controls.Add(cmbPrestPago);
            groupBox5.Controls.Add(cmbSucPago);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(label3);
            groupBox5.Location = new Point(3, 36);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(937, 758);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Pagos por sucursal y prestador";
            // 
            // dgvPagosSucPres
            // 
            dgvPagosSucPres.AllowUserToAddRows = false;
            dgvPagosSucPres.AllowUserToDeleteRows = false;
            dgvPagosSucPres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagosSucPres.Location = new Point(5, 168);
            dgvPagosSucPres.Name = "dgvPagosSucPres";
            dgvPagosSucPres.ReadOnly = true;
            dgvPagosSucPres.RowHeadersWidth = 51;
            dgvPagosSucPres.Size = new Size(926, 532);
            dgvPagosSucPres.TabIndex = 11;
            // 
            // btnGenerarPago
            // 
            btnGenerarPago.Location = new Point(463, 128);
            btnGenerarPago.Name = "btnGenerarPago";
            btnGenerarPago.Size = new Size(205, 29);
            btnGenerarPago.TabIndex = 10;
            btnGenerarPago.Text = "Generar Pago";
            btnGenerarPago.UseVisualStyleBackColor = true;
            btnGenerarPago.Click += btnGenerarPago_Click;
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(123, 134);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(241, 28);
            cmbTipoPago.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 137);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 8;
            label7.Text = "Tipo de Pago:";
            // 
            // txtImporte
            // 
            txtImporte.Location = new Point(463, 83);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(246, 27);
            txtImporte.TabIndex = 7;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.Location = new Point(123, 85);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(241, 27);
            dtpVencimiento.TabIndex = 6;
            // 
            // cmbPrestPago
            // 
            cmbPrestPago.FormattingEnabled = true;
            cmbPrestPago.Location = new Point(463, 42);
            cmbPrestPago.Name = "cmbPrestPago";
            cmbPrestPago.Size = new Size(246, 28);
            cmbPrestPago.TabIndex = 5;
            cmbPrestPago.SelectedIndexChanged += cmbPrestPago_SelectedIndexChanged;
            // 
            // cmbSucPago
            // 
            cmbSucPago.FormattingEnabled = true;
            cmbSucPago.Location = new Point(123, 42);
            cmbSucPago.Name = "cmbSucPago";
            cmbSucPago.Size = new Size(241, 28);
            cmbSucPago.TabIndex = 4;
            cmbSucPago.SelectedIndexChanged += cmbSucPago_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(392, 90);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 3;
            label6.Text = "Importe:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 90);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 2;
            label5.Text = "Vencimiento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 45);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 1;
            label4.Text = "Prestador:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 45);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 0;
            label3.Text = "Sucursal:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1893, 856);
            Controls.Add(tabPrincipal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Gestion de Servicios Hoteleros - GSH";
            WindowState = FormWindowState.Maximized;
            tabPrincipal.ResumeLayout(false);
            tabGestion.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrestadores).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSucursales).EndInit();
            tabAsociaciones.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSucursalesPrestador).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestadoresSucursal).EndInit();
            tabPagos.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagosSucPres).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabPrincipal;
        private TabPage tabGestion;
        private TabPage tabAsociaciones;
        private TabPage tabPagos;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnQuitar;
        private Button btnAsignar;
        private DataGridView dgvPrestadores;
        private Button btnBajaPrestador;
        private Button btnUpdPrestador;
        private Button btnAltaPrestador;
        private DataGridView dgvSucursales;
        private Button btnBajaSuc;
        private Button btnUpdSuc;
        private Button btnAltaSuc;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private DataGridView dgvSucursalesPrestador;
        private Label label2;
        private ComboBox cmbPrestadorAsoc;
        private DataGridView dgvPrestadoresSucursal;
        private Label label1;
        private ComboBox cmbSucursalAsoc;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label label3;
        private TextBox txtImporte;
        private DateTimePicker dtpVencimiento;
        private ComboBox cmbPrestPago;
        private ComboBox cmbSucPago;
        private Label label6;
        private Label label5;
        private Label label4;
        private DataGridView dgvPagos;
        private DataGridView dgvPagosSucPres;
        private Button btnGenerarPago;
        private ComboBox cmbTipoPago;
        private Label label7;
        private Button btnPagar;
    }
}
