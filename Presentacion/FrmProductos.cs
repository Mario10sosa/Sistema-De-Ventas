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
    public partial class FrmProductos : Form
    {
        CL_ServiocioContactoProductos Productos = new CL_ServiocioContactoProductos();
        CE_Productos Producto = new CE_Productos();
        public FrmProductos()
        {
            
            InitializeComponent();
            CBTipoBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarGrilla();

            
        }

        void CargarGrilla()
        {
            DtProductos.DataSource = Productos.Mostrar();
        }
        private void AgPro_UpdateEventHandler(object sender, FrmAgregarProductos.UpdateEventArgs args)
        {
            CargarGrilla();
        }
        private void EdPro_UpdateEventHandler(object sender, FrmEditarProductos.UpdateEventArgs args)
        {
            CargarGrilla();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarProductos AgregarProductos = new FrmAgregarProductos();
            AgregarProductos.UpdateEventHandler += AgPro_UpdateEventHandler;
            AgregarProductos.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DtProductos.Rows.Count == 0)
            {
                MessageBox.Show("No Hay Registro Para Editar", "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (DtProductos.SelectedRows == null)
                {
                    return;
                }
                else
                {

                    try
                    {
                        FrmEditarProductos EditarProductos = new FrmEditarProductos();
                        EditarProductos.UpdateEventHandler += EdPro_UpdateEventHandler;
                        EditarProductos.TxtCodigo.Text = DtProductos.SelectedRows[0].Cells[0].Value.ToString();
                        EditarProductos.TxtNombre.Text = DtProductos.SelectedRows[0].Cells[1].Value.ToString();
                        EditarProductos.TxtDescripcion.Text = DtProductos.SelectedRows[0].Cells[2].Value.ToString();
                        EditarProductos.TxtPresentacion.Text = DtProductos.SelectedRows[0].Cells[3].Value.ToString();
                        EditarProductos.TxtCostoUnitario.Text = DtProductos.SelectedRows[0].Cells[4].Value.ToString();
                        EditarProductos.TxtPrecioVenta.Text = DtProductos.SelectedRows[0].Cells[5].Value.ToString();


                        EditarProductos.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Debe Seleccionar Un Registro Por Favor", "Editar Prodcuto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public void Eliminar()
        {
            if (DtProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (DtProductos.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult Resultados = MessageBox.Show("Esta seguro que desea eliminar este producto", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Producto.Id_Producto = Convert.ToInt32(DtProductos.SelectedRows[0].Cells[0].Value.ToString());
                            Productos.Delete(Producto);
                            CargarGrilla();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe Seleccionar un registro para Eliminar", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

        }

        private void TxtBuscarProductos_TextChanged(object sender, EventArgs e)
        {
            Buscar(TxtBuscarProductos.Text);
        }

        public void Buscar(string buscando)
        {
            
            Productos.Buscar(buscando);
            
            try
            {
                if(CBTipoBusqueda.Text == "Codigo")
                {
                    buscando = TxtBuscarProductos.Text.Trim();
                    DtProductos.DataSource = Productos.Buscar(buscando);
                }
                else if(CBTipoBusqueda.Text == "Nombre")
                {
                    buscando = TxtBuscarProductos.Text.Trim();
                    DtProductos.DataSource = Productos.Buscar(buscando);
                }
                else if(CBTipoBusqueda.Text == "Decripcion")
                {
                    buscando = TxtBuscarProductos.Text.Trim();
                    DtProductos.DataSource = Productos.Buscar(buscando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Producto no fue encontrado por: " + ex.Message, "Buscar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      
    }
}
