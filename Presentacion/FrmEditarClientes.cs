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
    public partial class FrmEditarClientes : Form
    {
        CL_ServicioContactoCLientes Clientes = new CL_ServicioContactoCLientes();
        CE_Clientes Cliente = new CE_Clientes();
        public FrmEditarClientes()
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
        private void FrmEditarClientes_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtNombreCliente.Focus();
                e.Handled = true;
            }
        }

        private void TxtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtCedulaCliente.Focus();
                e.Handled = true;
            }
        }

        private void TxtCedulaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDireccionCliente.Focus();
                e.Handled = true;
            }
        }

        private void TxtDireccionCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MTxtTelefonoCliente.Focus();
                e.Handled = true;
            }
        }

        private void MTxtTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtEmailCliente.Focus();
                e.Handled = true;
            }
        }

        private void TxtEmailCliente_KeyPress(object sender, KeyPressEventArgs e)
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
                if (TxtCodigoCliente.Text == string.Empty || TxtNombreCliente.Text == string.Empty || TxtCedulaCliente.Text == string.Empty ||
                    TxtDireccionCliente.Text == string.Empty || MTxtTelefonoCliente.Text == string.Empty ||
                    TxtEmailCliente.Text == string.Empty)
                {
                    MessageBox.Show("Por Favor Debe completa todos los campos", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Cliente.Id_Cliente = Convert.ToInt32(TxtCodigoCliente.Text.Trim());
                    Cliente.Nombre = TxtNombreCliente.Text.Trim();
                    Cliente.Cedula = TxtCedulaCliente.Text.Trim();
                    Cliente.Direccion = TxtDireccionCliente.Text.Trim();
                    Cliente.Telefono = MTxtTelefonoCliente.Text.Trim();
                    Cliente.Email = TxtEmailCliente.Text.Trim();

                    Clientes.Update(Cliente);
                    MessageBox.Show("El Cliente fue Editado correctamente", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    this.Close();
                    Actualizar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Cliente no fue editado por: " + ex.Message, "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LimpiarControles()
        {
            TxtCodigoCliente.Text = "";
            TxtNombreCliente.Text = "";
            TxtCedulaCliente.Text = "";
            TxtDireccionCliente.Text = "";
            MTxtTelefonoCliente.Text = "";
            TxtEmailCliente.Text = "";
        }

    }
}
