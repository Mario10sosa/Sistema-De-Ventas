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
    public partial class FrmAgregarEmpresa : Form
    {
        CL_ServicioContactoEmpresas Empresas = new CL_ServicioContactoEmpresas();
        CE_Empresas Empresa = new CE_Empresas();
        public FrmAgregarEmpresa()
        {
            InitializeComponent();
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        private void FrmAgregarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private bool Guardar()
        {
            try
            {
                if (TxtIdEmpresa.Text == string.Empty || TxtNombreEmpresa.Text == string.Empty || TxtDireccionEmpresa.Text == string.Empty ||
                    TxtTelefonoEmpresa.Text == string.Empty || TxtEmailEmpresa.Text == string.Empty)
                {
                    MessageBox.Show("Por Favor Debe completa todos los campos", "Agregar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    Empresa.Id_Empresa = Convert.ToInt32(TxtIdEmpresa.Text);
                    Empresa.Nombre = TxtNombreEmpresa.Text.Trim();
                    Empresa.Direccion = TxtDireccionEmpresa.Text.Trim();
                    Empresa.Telefono = TxtTelefonoEmpresa.Text.Trim();
                    Empresa.Email = TxtEmailEmpresa.Text.Trim();


                    Empresas.Save(Empresa);
                    MessageBox.Show("La Empresa fue agregado correctamente", "Agregar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    TxtIdEmpresa.Focus();
                    Agregar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La Empresa no fue agregado por: " + ex.Message, "Agregar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        void LimpiarControles()
        {
            TxtIdEmpresa.Text = "";
            TxtNombreEmpresa.Text = "";
            TxtDireccionEmpresa.Text = "";
            TxtTelefonoEmpresa.Text = "";
            TxtEmailEmpresa.Text = "";
        }

        private void TxtIdEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtNombreEmpresa.Focus();
                e.Handled = true;
            }
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
                BtnAgregar.Focus();
                e.Handled = true;
            }
        }
    }
}
