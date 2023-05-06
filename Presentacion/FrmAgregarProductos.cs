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
using Entidades;

namespace Presentacion
{
    public partial class FrmAgregarProductos : Form
    {
        CE_Productos Producto = new CE_Productos();
        CL_ServiocioContactoProductos Productos = new CL_ServiocioContactoProductos();
        public FrmAgregarProductos()
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

        private void FrmAgregarProductos_Load(object sender, EventArgs e)
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
                if (TxtCodigo.Text == string.Empty || TxtNombre.Text == string.Empty || TxtPresentacion.Text == string.Empty ||
                    TxtDescripcion.Text == string.Empty || TxtPrecioVenta.Text == string.Empty ||
                    TxtCostoUnitario.Text == string.Empty)
                {
                    MessageBox.Show("Por Favor Debe completa todos los campos", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    
                    Producto.Id_Producto = Convert.ToInt32(TxtCodigo.Text);
                    Producto.Nombre_Producto = TxtNombre.Text.Trim();
                    Producto.Descripcion = TxtDescripcion.Text.Trim();
                    Producto.Presentacion = TxtPresentacion.Text.Trim();
                    Producto.Costo_Unitario = Convert.ToInt32(TxtCostoUnitario.Text.Trim());
                    Producto.Precio_Venta = Convert.ToInt32(TxtPrecioVenta.Text.Trim());
                   

                    Productos.Save(Producto);
                    MessageBox.Show("El producto fue agregado correctamente", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    TxtCodigo.Focus();
                    Agregar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El producto no fue agregado por: " + ex.Message, "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        void LimpiarControles()
        {
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtDescripcion.Text = "";
            TxtPresentacion.Text = "";
            TxtCostoUnitario.Text = "";
            TxtPrecioVenta.Text = "";
        }
        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtNombre.Focus();
                e.Handled = true;
            }
        }
        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDescripcion.Focus();
                e.Handled = true;
            }
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtPresentacion.Focus();
                e.Handled = true;
            }
        }

        private void TxtPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtCostoUnitario.Focus();
                e.Handled = true;
            }
        }

        private void TxtCostoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtPrecioVenta.Focus();
                e.Handled = true;
            }
        }

        private void TxtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnAgregar.Focus();
                e.Handled = true;
            }
        }

        
    }
}
