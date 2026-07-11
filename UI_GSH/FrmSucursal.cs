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
    public partial class FrmSucursal : Form
    {
        private BESucursal _sucursal;
        private bool _esModificacion;
        public BESucursal SucursalRetorno;
        public FrmSucursal()
        {
            InitializeComponent();
            _esModificacion = false;
            Text = "Nueva Sucursal";
            rbSi.Checked = true;
            rbSi.Enabled = false;
            rbNo.Enabled = false;
        }
        public FrmSucursal(BESucursal sucursal)
        {
            InitializeComponent();

            _sucursal = sucursal;
            _esModificacion = true;
            Text = "Modificar Sucursal";

            txtCodigo.Text = sucursal.Codigo;
            txtNombre.Text = sucursal.Nombre;
            txtTelefono.Text = sucursal.Telefono;
            txtDireccion.Text = sucursal.Direccion;
            if (sucursal.Activo)
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
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SucursalRetorno = new BESucursal
                {
                    Id= _esModificacion ? _sucursal.Id : 0,
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
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
