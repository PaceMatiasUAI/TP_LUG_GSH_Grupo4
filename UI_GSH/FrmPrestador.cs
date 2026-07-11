using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_GSH;

namespace UI_GSH
{
    public partial class FrmPrestador : Form
    {
        private BEPrestador _prestador;
        private bool _esModificacion;
        public BEPrestador PrestadorRetorno;
        public FrmPrestador()
        {
            InitializeComponent();
            _esModificacion = false;
            Text = "Nuevo Prestador";
            rbSi.Checked = true;
            rbSi.Enabled = false;
            rbNo.Enabled = false;
        }
        public FrmPrestador(BEPrestador prestador)
        {
            InitializeComponent();
            _prestador = prestador;
            _esModificacion = true;
            Text = "Modificar Prestador";
            txtCodigo.Text = prestador.Codigo;
            txtNombre.Text = prestador.Nombre;
            txtTelefono.Text = prestador.Telefono;
            if (prestador.Activo)
            {
                rbSi.Checked = true;
            }
            else
            {
                rbNo.Checked = true;
            }
            txtCodigo.Enabled = false;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                PrestadorRetorno = new BEPrestador
                {
                    Id=_esModificacion ? _prestador.Id : 0,
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Activo = rbSi.Checked
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
