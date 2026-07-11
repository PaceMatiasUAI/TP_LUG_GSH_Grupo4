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
using BE_GSH.DTO;
using BLL_GSH;


namespace UI_GSH
{
    public partial class Form1 : Form
    {
        private BLLSucursal _bllSucursal = new BLLSucursal();
        private BLLPrestador _bllPrestador = new BLLPrestador();
        private BLLContrato _bllContrato = new BLLContrato();
        private BLLPago _bllPago = new BLLPago();
        private BLLTipoPago _bllTipoPago = new BLLTipoPago();
        public Form1()
        {
            InitializeComponent();
            ConfigurarControles();
            CargarDatosIniciales();
        }

        #region Configuracion de controles e inicio
        private void ConfigurarControles()
        {
            ConfigurarGrillas();
            ConfigurarCombos();
            dtpVencimiento.Format = DateTimePickerFormat.Short;
        }
        private void ConfigurarDgv(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
        }

        private void ConfigurarGrillas()
        {
            ConfigurarDgv(dgvSucursales);
            ConfigurarDgv(dgvPrestadores);
            ConfigurarDgv(dgvPrestadoresSucursal);
            ConfigurarDgv(dgvSucursalesPrestador);
            ConfigurarDgv(dgvPagosSucPres);
            ConfigurarDgv(dgvPagos);
        }
        private void ConfigurarCombo(ComboBox cmb)
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigurarCombos()
        {
            ConfigurarCombo(cmbSucursalAsoc);
            ConfigurarCombo(cmbPrestadorAsoc);
            ConfigurarCombo(cmbSucPago);
            ConfigurarCombo(cmbPrestPago);
            ConfigurarCombo(cmbTipoPago);
        }
        private void LimpiarDgv(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Refresh();
        }
        private void CargarDgv<T>(DataGridView dgv, List<T> datos)
        {
            dgv.DataSource = null;
            dgv.DataSource = datos;

            if (dgv.Columns.Contains("Id"))
                dgv.Columns["Id"].Visible = false;

            if (dgv.Columns.Contains("Fecha"))
                dgv.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgv.Columns.Contains("Vencimiento"))
                dgv.Columns["Vencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgv.Columns.Contains("Pagado"))
                dgv.Columns["Pagado"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgv.Columns.Contains("Importe"))
                dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";

            if (dgv.Columns.Contains("Recargo"))
                dgv.Columns["Recargo"].DefaultCellStyle.Format = "C2";

            if (dgv.Columns.Contains("Total"))
                dgv.Columns["Total"].DefaultCellStyle.Format = "C2";

            dgv.ClearSelection();
        }
        private void CargarCombo<T>(ComboBox cmb, List<T> datos, string displayMember, string valueMember)
        {
            cmb.DataSource = null;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = datos;
            cmb.SelectedIndex = -1;
        }
        private void CargarDatosIniciales()
        {
            CargarSucursales();
            CargarPrestadores();
            CargarCombosAsociaciones();

            LimpiarDgv(dgvPrestadoresSucursal);
            LimpiarDgv(dgvSucursalesPrestador);
            CargarCombosPagos();
            CargarPagos();
            CargarPrestadoresPagoPorSucursal();
            CargarPagosSucursalPrestador();
        }

        #endregion


        #region tabGestion Sucursales
        private void CargarSucursales()
        {
            try
            {
                CargarDgv(dgvSucursales, _bllSucursal.GetSucursales());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar sucursales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ObtenerCodigoSucursalSeleccionada()
        {
            if (dgvSucursales.CurrentRow == null)
                throw new Exception("Debe seleccionar una sucursal.");

            string codigo = Convert.ToString(dgvSucursales.CurrentRow.Cells["Codigo"].Value);

            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("No se pudo obtener la sucursal seleccionada.");

            return codigo;
        }
        private void btnAltaSuc_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSucursal frm = new FrmSucursal();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _bllSucursal.AltaSucursal(frm.SucursalRetorno);
                    CargarDatosIniciales();
                    MessageBox.Show("Sucursal dada de alta correctamente.", "Alta de sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdSuc_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ObtenerCodigoSucursalSeleccionada();
                BESucursal sucursal = _bllSucursal.ObtenerSucursalPorCodigo(codigo);
                FrmSucursal frm = new FrmSucursal(sucursal);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _bllSucursal.ModificarSucursal(frm.SucursalRetorno, sucursal);
                    CargarDatosIniciales();

                    MessageBox.Show("Sucursal modificada correctamente.", "Modificar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBajaSuc_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ObtenerCodigoSucursalSeleccionada();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Desea eliminar la sucursal {codigo}?\n\nSolo se permitirá si no tiene asociaciones ni historial.",
                    "Confirmar baja de sucursal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                _bllSucursal.BajaSucursal(codigo);

                MessageBox.Show(
                    "Sucursal eliminada correctamente.",
                    "Baja de sucursal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region tabGestion Prestadores
        private string ObtenerCodigoPrestadorSeleccionado()
        {
            if (dgvPrestadores.CurrentRow == null)
                throw new Exception("Debe seleccionar un prestador.");

            string codigo = Convert.ToString(dgvPrestadores.CurrentRow.Cells["Codigo"].Value);

            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("No se pudo obtener el prestador seleccionado.");

            return codigo;
        }
        private void CargarPrestadores()
        {
            try
            {
                CargarDgv(dgvPrestadores, _bllPrestador.GetPrestadores());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar prestadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAltaPrestador_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPrestador frm = new FrmPrestador();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _bllPrestador.AltaPrestador(frm.PrestadorRetorno);
                    CargarDatosIniciales();

                    MessageBox.Show("Prestador dado de alta correctamente.", "Alta de prestador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdPrestador_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ObtenerCodigoPrestadorSeleccionado();
                BEPrestador prestador = _bllPrestador.ObtenerPrestadorPorCodigo(codigo);

                FrmPrestador frm = new FrmPrestador(prestador);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _bllPrestador.ModificarPrestador(frm.PrestadorRetorno, prestador);
                    CargarDatosIniciales();

                    MessageBox.Show("Prestador modificado correctamente.", "Modificar prestador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBajaPrestador_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ObtenerCodigoPrestadorSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Desea eliminar el prestador {codigo}?\n\nSolo se permitirá si no tiene asociaciones ni historial.",
                    "Confirmar baja de prestador",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                _bllPrestador.BajaPrestador(codigo);

                MessageBox.Show(
                    "Prestador eliminado correctamente.",
                    "Baja de prestador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region tbGestion Asociaciones
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoSucursal = ObtenerCodigoSucursalSeleccionada();
                string codigoPrestador = ObtenerCodigoPrestadorSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Desea asociar el prestador seleccionado a la sucursal seleccionada?\n"+
                    $"\nSucursal: {codigoSucursal} - Prestador: {codigoPrestador}",
                    "Confirmar asociación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                _bllContrato.AsignarPrestadorASucursal(codigoSucursal, codigoPrestador);

                MessageBox.Show(
                    "Prestador asociado correctamente a la sucursal.",
                    "Asociación realizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoSucursal = ObtenerCodigoSucursalSeleccionada();
                string codigoPrestador = ObtenerCodigoPrestadorSeleccionado();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Desea quitar la asociación entre la sucursal y el prestador seleccionados?\n"+
                    $"\nSucursal: {codigoSucursal} - Prestador: {codigoPrestador}",
                    "Confirmar desasociación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                _bllContrato.DesasociarPrestadorDeSucursal(codigoSucursal, codigoPrestador);

                MessageBox.Show(
                    "Asociación quitada correctamente.",
                    "Desasociación realizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region tbAsociaciones
        private void CargarCombosAsociaciones()
        {
            try
            {
                CargarCombo(cmbSucursalAsoc, _bllSucursal.GetSucursales(), "Nombre", "Id");
                CargarCombo(cmbPrestadorAsoc, _bllPrestador.GetPrestadores(), "Nombre", "Id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar combos de asociaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPrestadoresPorSucursal()
        {
            try
            {
                if (cmbSucursalAsoc.SelectedIndex == -1)
                {
                    LimpiarDgv(dgvPrestadoresSucursal);
                    return;
                }

                int id = Convert.ToInt32(cmbSucursalAsoc.SelectedValue);

                List<DTOContrato> contratos = _bllContrato.ObtenerContratosPorSucursal(id);

                CargarDgv(dgvPrestadoresSucursal, contratos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar prestadores por sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarSucursalesPorPrestador()
        {
            try
            {
                if (cmbPrestadorAsoc.SelectedIndex == -1)
                {
                    LimpiarDgv(dgvSucursalesPrestador);
                    return;
                }

                int id = Convert.ToInt32(cmbPrestadorAsoc.SelectedValue);

                List<DTOContrato> contratos = _bllContrato.ObtenerContratosPorPrestador(id);

                CargarDgv(dgvSucursalesPrestador, contratos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar sucursales por prestador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbSucursalAsoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPrestadoresPorSucursal();
        }
        private void cmbPrestadorAsoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSucursalesPorPrestador();
        }

        #endregion

        #region tbPagos
        private string ObtenerCodigoPagoSeleccionado()
        {
            if (dgvPagos.CurrentRow == null)
                throw new Exception("Debe seleccionar un pago.");

            string codigo = Convert.ToString(dgvPagos.CurrentRow.Cells["Codigo"].Value);

            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("No se pudo obtener el pago seleccionado.");

            return codigo;
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoPago = ObtenerCodigoPagoSeleccionado();
                BEPago pago = _bllPago.PagarPago(codigoPago);
                string mensaje ="¿Desea confirmar el pago seleccionado?\n\n" +
                                $"Código: {pago.Codigo}\n" +
                                $"Importe: {pago.Importe:C2}\n" +
                                $"Recargo: {pago.Recargo:C2}\n" +
                                $"Total a abonar: {pago.TotalAbonado:C2}";

                DialogResult respuesta = MessageBox.Show(mensaje,"Confirmar pago",MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.No)
                    return;

                _bllPago.ConfirmarPago(pago);

                MessageBox.Show("Pago registrado correctamente.","Pago confirmado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCombosPagos()
        {
            try
            {
                CargarCombo(cmbSucPago, _bllSucursal.GetSucursales(), "Nombre", "Id");

                cmbPrestPago.DataSource = null;
                cmbPrestPago.SelectedIndex = -1;

                CargarCombo(cmbTipoPago, _bllTipoPago.GetTiposPago(), "Descripcion", "Id");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar combos de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPagos()
        {
            try
            {
                CargarDgv(dgvPagos, _bllPago.ObtenerPagos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargarPrestadoresPagoPorSucursal()
        {
            try
            {
                LimpiarDgv(dgvPagosSucPres);
                cmbPrestPago.DataSource = null;
                cmbPrestPago.SelectedIndex = -1;
                // Verificar si se ha seleccionado una sucursal
                if (cmbSucPago.SelectedIndex == -1)
                    return;

                int idSucursal = Convert.ToInt32(cmbSucPago.SelectedValue);

                List<BEPrestador> prestadores = _bllContrato.ObtenerPrestadoresPorSucursal(idSucursal);
                if (prestadores.Count <= 0)
                {
                    MessageBox.Show("La sucursal no tiene prestadores asociados.");
                    return;
                }
                CargarCombo(cmbPrestPago, prestadores, "Nombre", "Id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar prestadores de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPagosSucursalPrestador()
        {
            try
            {
                if (cmbSucPago.SelectedIndex == -1 || cmbPrestPago.SelectedIndex == -1)
                {
                    LimpiarDgv(dgvPagosSucPres);
                    return;
                }
                int idSucursal = Convert.ToInt32(cmbSucPago.SelectedValue);
                int idPrestador = Convert.ToInt32(cmbPrestPago.SelectedValue);
                CargarDgv(dgvPagosSucPres, _bllPago.ObtenerPagosPorSucursalPrestador(idSucursal, idPrestador));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar pagos por sucursal y prestador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbSucPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPrestadoresPagoPorSucursal();
        }
        private void cmbPrestPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPagosSucursalPrestador();
        }
        private void btnGenerarPago_Click(object sender, EventArgs e)
        {
            try
            {
                //validaciones de campos
                if (cmbSucPago.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar una sucursal.");

                if (cmbPrestPago.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar un prestador.");

                if (cmbTipoPago.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar un tipo de pago.");

                if (string.IsNullOrWhiteSpace(txtImporte.Text))
                    throw new Exception("Debe ingresar un importe.");

                if (!decimal.TryParse(txtImporte.Text, out decimal importe))
                    throw new Exception("El importe ingresado no es válido.");

                int idSucursal = Convert.ToInt32(cmbSucPago.SelectedValue);
                int idPrestador = Convert.ToInt32(cmbPrestPago.SelectedValue);
                int idTipoPago = Convert.ToInt32(cmbTipoPago.SelectedValue);
                //no genero el objeto pago porque el metodo AltaPago lo hace internamente,
                //solo le paso los datos necesarios y dejo que obtenga el codigo
                _bllPago.AltaPago(
                    idSucursal,
                    idPrestador,
                    idTipoPago,
                    dtpVencimiento.Value,
                    importe);

                MessageBox.Show(
                    "Pago generado correctamente.",
                    "Alta de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtImporte.Clear();
                dtpVencimiento.Value = DateTime.Now;

                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

    }
}
