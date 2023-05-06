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
    public partial class FrmEditarEmpresas : Form
    {
        CL_ServicioContactoEmpresas Empresas = new CL_ServicioContactoEmpresas();
        CE_Empresas Empresa = new CE_Empresas();
        public FrmEditarEmpresas()
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
        private void FrmEditarEmpresas_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtNombreEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDireccionEmpresa.Focus();
                e.Handled = true;
            }
        }

        private void TxtDireccionEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtTelefonoEmpresa.Focus();
                e.Handled = true;
            }
        }

        private void TxtTelefonoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtEmailEmpresa.Focus();
                e.Handled = true;
            }
        }

        private void TxtEmailEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
                if (TxtNombreEmpresa.Text == string.Empty || TxtDireccionEmpresa.Text == string.Empty ||
                    TxtTelefonoEmpresa.Text == string.Empty || TxtEmailEmpresa.Text == string.Empty)
                {
                    MessageBox.Show("Por Favor Debe completa todos los campos", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Empresa.Id_Empresa = Convert.ToInt32(TxtIdEmpresa.Text.Trim());
                    Empresa.Nombre = TxtNombreEmpresa.Text.Trim();
                    Empresa.Direccion = TxtDireccionEmpresa.Text.Trim();
                    Empresa.Telefono = TxtTelefonoEmpresa.Text.Trim();
                    Empresa.Email = TxtEmailEmpresa.Text.Trim();

                    Empresas.Update(Empresa);
                    MessageBox.Show("La Empresa fue Editado correctamente", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    this.Close();
                    Actualizar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La Empresas no fue editado por: " + ex.Message, "Editar Empresas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LimpiarControles()
        {
            TxtNombreEmpresa.Text = "";
            TxtDireccionEmpresa.Text = "";
            TxtTelefonoEmpresa.Text = "";
            TxtEmailEmpresa.Text = "";
        }
    }
}
