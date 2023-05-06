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
using Logica;

namespace Presentacion
{
    public partial class FrmClientes : Form
    {
        CL_ServicioContactoCLientes Clientes = new CL_ServicioContactoCLientes();
        CE_Clientes Cliente = new CE_Clientes();
 
        public FrmClientes()
        {
            InitializeComponent();
            CBTipoBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CargarGrilla()
        {
            DtClientes.DataSource = Clientes.Mostrar();
        }

        private void AgClie_UpdateEventHandler(object sender, FrmAgregarClientes.UpdateEventArgs args)
        {
            CargarGrilla();
        }

        private void EdClie_UpdateEventHandler(object sender, FrmEditarClientes.UpdateEventArgs args)
        {
            CargarGrilla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarClientes agregarClientes = new FrmAgregarClientes();
            agregarClientes.UpdateEventHandler += AgClie_UpdateEventHandler;
            agregarClientes.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DtClientes.Rows.Count == 0)
            {
                MessageBox.Show("No Hay Registro Para Editar", "Editar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (DtClientes.SelectedRows == null)
                {
                    return;
                }
                else
                {

                    try
                    {
                        FrmEditarClientes EditarClientes = new FrmEditarClientes();
                        EditarClientes.UpdateEventHandler += EdClie_UpdateEventHandler;
                        EditarClientes.TxtCodigoCliente.Text = DtClientes.SelectedRows[0].Cells[0].Value.ToString();
                        EditarClientes.TxtNombreCliente.Text = DtClientes.SelectedRows[0].Cells[1].Value.ToString();
                        EditarClientes.TxtCedulaCliente.Text = DtClientes.SelectedRows[0].Cells[2].Value.ToString();
                        EditarClientes.TxtDireccionCliente.Text = DtClientes.SelectedRows[0].Cells[3].Value.ToString();
                        EditarClientes.MTxtTelefonoCliente.Text = DtClientes.SelectedRows[0].Cells[4].Value.ToString();
                        EditarClientes.TxtEmailCliente.Text = DtClientes.SelectedRows[0].Cells[5].Value.ToString();


                        EditarClientes.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Debe Seleccionar Un Registro Por Favor", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (DtClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Eliminar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (DtClientes.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult Resultados = MessageBox.Show("Esta seguro que desea eliminar este Cliente", "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Cliente.Id_Cliente = Convert.ToInt32(DtClientes.SelectedRows[0].Cells[0].Value.ToString());
                            Clientes.Delete(Cliente);
                            CargarGrilla();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe Seleccionar un registro para Eliminar", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

        }

        private void TxtBuscarClientes_TextChanged(object sender, EventArgs e)
        {
            Buscar(TxtBuscarClientes.Text);
        }

        public void Buscar(string buscando)
        {

            Clientes.Buscar(buscando);

            try
            {
                if (CBTipoBusqueda.Text == "Codigo")
                {
                    buscando = TxtBuscarClientes.Text.Trim();
                    DtClientes.DataSource = Clientes.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Nombre")
                {
                    buscando = TxtBuscarClientes.Text.Trim();
                    DtClientes.DataSource = Clientes.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Cedula")
                {
                    buscando = TxtBuscarClientes.Text.Trim();
                    DtClientes.DataSource = Clientes.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Telefono")
                {
                    buscando = TxtBuscarClientes.Text.Trim();
                    DtClientes.DataSource = Clientes.Buscar(buscando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El cliente no fue encontrado por: " + ex.Message, "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
