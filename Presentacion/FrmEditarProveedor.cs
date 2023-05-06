using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmEditarProveedor : Form
    {
        CL_ServicioContactoProveedores Proveedores = new CL_ServicioContactoProveedores();
        CE_Proveedores Proveedor = new CE_Proveedores();
        public FrmEditarProveedor()
        {
            InitializeComponent();
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        private void FrmEditarProveedor_Load(object sender, EventArgs e)
        {

        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtNombreProveedor.Focus();
                e.Handled = true;
            }
        }

        private void TxtNombreProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtNitProveedor.Focus();
                e.Handled = true;
            }
        }

        private void TxtNitProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDireccionProveedor.Focus();
                e.Handled = true;
            }
        }

        private void TxtDireccionProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtTelefonoProveedor.Focus();
                e.Handled = true;
            }
        }

        private void TxtTelefonoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtEmailProveedor.Focus();
                e.Handled = true;
            }
        }

        private void TxtEmailProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnEditar.Focus();
                e.Handled = true;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        public void Editar()
        {
            try
            {
                if (TxtCodigoProveedor.Text == string.Empty || TxtNombreProveedor.Text == string.Empty || TxtNitProveedor.Text == string.Empty ||
                    TxtDireccionProveedor.Text == string.Empty || TxtTelefonoProveedor.Text == string.Empty ||
                    TxtEmailProveedor.Text == string.Empty)
                {
                    MessageBox.Show("Por Favor Debe completa todos los campos", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Proveedor.Id_Proveedor = Convert.ToInt32(TxtCodigoProveedor.Text.Trim());
                    Proveedor.Nombre_Proveedor = TxtNombreProveedor.Text.Trim();
                    Proveedor.Nit = TxtNitProveedor.Text.Trim();
                    Proveedor.Direccion = TxtDireccionProveedor.Text.Trim();
                    Proveedor.Telefono = TxtTelefonoProveedor.Text.Trim();
                    Proveedor.Email = TxtEmailProveedor.Text.Trim();

                    Proveedores.Update(Proveedor);
                    MessageBox.Show("El Proveedor fue Editado correctamente", "Editar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    this.Close();
                    Actualizar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El producto no fue editado por: " + ex.Message, "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LimpiarControles()
        {
            TxtCodigoProveedor.Text = "";
            TxtNombreProveedor.Text = "";
            TxtNitProveedor.Text = "";
            TxtDireccionProveedor.Text = "";
            TxtTelefonoProveedor.Text = "";
            TxtEmailProveedor.Text = "";
        }
    }
}
