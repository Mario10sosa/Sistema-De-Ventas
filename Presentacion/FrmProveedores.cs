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
    public partial class FrmProveedores : Form
    {
        CL_ServicioContactoProveedores Proveedores = new CL_ServicioContactoProveedores();
        CE_Proveedores Proveedore = new CE_Proveedores();
        public FrmProveedores()
        {
            InitializeComponent();
            CBTipoBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CargarGrilla()
        {
            DtProveedores.DataSource = Proveedores.Mostrar();
        }

        private void AgProv_UpdateEventHandler(object sender, FrmAgregarProveedores.UpdateEventArgs args)
        {
            CargarGrilla();
        }

        private void EdProv_UpdateEventHandler(object sender, FrmEditarProveedor.UpdateEventArgs args)
        {
            CargarGrilla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarProveedores agregarProveedores = new FrmAgregarProveedores();
            agregarProveedores.UpdateEventHandler += AgProv_UpdateEventHandler;
            agregarProveedores.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DtProveedores.Rows.Count == 0)
            {
                MessageBox.Show("No Hay Registro Para Editar", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (DtProveedores.SelectedRows == null)
                {
                    return;
                }
                else
                {

                    try
                    {
                        FrmEditarProveedor EditarProveedor = new FrmEditarProveedor();
                        EditarProveedor.UpdateEventHandler += EdProv_UpdateEventHandler;
                        
                        EditarProveedor.TxtCodigoProveedor.Text = DtProveedores.SelectedRows[0].Cells[0].Value.ToString();
                        EditarProveedor.TxtNombreProveedor.Text = DtProveedores.SelectedRows[0].Cells[1].Value.ToString();
                        EditarProveedor.TxtNitProveedor.Text = DtProveedores.SelectedRows[0].Cells[2].Value.ToString();
                        EditarProveedor.TxtDireccionProveedor.Text = DtProveedores.SelectedRows[0].Cells[3].Value.ToString();
                        EditarProveedor.TxtTelefonoProveedor.Text = DtProveedores.SelectedRows[0].Cells[4].Value.ToString();
                        EditarProveedor.TxtEmailProveedor.Text = DtProveedores.SelectedRows[0].Cells[5].Value.ToString();


                        EditarProveedor.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Debe Seleccionar Un Registro Por Favor", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (DtProveedores.Rows.Count == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (DtProveedores.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult Resultados = MessageBox.Show("Esta seguro que desea eliminar este Proveedor", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Proveedore.Id_Proveedor = Convert.ToInt32(DtProveedores.SelectedRows[0].Cells[0].Value.ToString());
                            Proveedores.Delete(Proveedore);
                            CargarGrilla();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe Seleccionar un registro para Eliminar", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

        }

        private void TxtBuscarClientes_TextChanged(object sender, EventArgs e)
        {
            Buscar(TxtBuscarProveedor.Text);
        }

        public void Buscar(string buscando)
        {

            Proveedores.Buscar(buscando);

            try
            {
                if (CBTipoBusqueda.Text == "Codigo")
                {
                    buscando = TxtBuscarProveedor.Text.Trim();
                    DtProveedores.DataSource = Proveedores.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Nombre")
                {
                    buscando = TxtBuscarProveedor.Text.Trim();
                    DtProveedores.DataSource = Proveedores.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Nit")
                {
                    buscando = TxtBuscarProveedor.Text.Trim();
                    DtProveedores.DataSource = Proveedores.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Telefono")
                {
                    buscando = TxtBuscarProveedor.Text.Trim();
                    DtProveedores.DataSource = Proveedores.Buscar(buscando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Proveedor no fue encontrado por: " + ex.Message, "Buscar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
