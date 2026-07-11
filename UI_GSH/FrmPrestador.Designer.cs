namespace UI_GSH
{
    partial class FrmPrestador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            rbSi = new RadioButton();
            rbNo = new RadioButton();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 78);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Codigo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 131);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 187);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Telefono:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 255);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 3;
            label4.Text = "Activo:";
            // 
            // rbSi
            // 
            rbSi.AutoSize = true;
            rbSi.Location = new Point(128, 253);
            rbSi.Name = "rbSi";
            rbSi.Size = new Size(42, 24);
            rbSi.TabIndex = 4;
            rbSi.TabStop = true;
            rbSi.Text = "Si";
            rbSi.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Location = new Point(183, 253);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(50, 24);
            rbNo.TabIndex = 5;
            rbNo.TabStop = true;
            rbNo.Text = "No";
            rbNo.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(36, 321);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 35);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(174, 321);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 35);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(101, 71);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(152, 27);
            txtCodigo.TabIndex = 8;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(101, 124);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(152, 27);
            txtNombre.TabIndex = 9;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(101, 180);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(152, 27);
            txtTelefono.TabIndex = 10;
            // 
            // FrmPrestador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 407);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(rbNo);
            Controls.Add(rbSi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmPrestador";
            Text = "Prestador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton rbSi;
        private RadioButton rbNo;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtTelefono;
    }
}