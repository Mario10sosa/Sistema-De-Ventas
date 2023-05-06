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
    public partial class FrmEmpresa : Form
    {
        
        CL_ServicioContactoEmpresas Empresas = new CL_ServicioContactoEmpresas();
        CE_Empresas Empresa = new CE_Empresas();
        public FrmEmpresa()
        {
            InitializeComponent();
            CBTipoBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CargarGrilla()
        {
            DtEmpresa.DataSource = Empresas.Mostrar();
        }

        private void AgEmp_UpdateEventHandler(object sender, FrmAgregarEmpresa.UpdateEventArgs args)
        {
            CargarGrilla();
        }

        private void EdEmp_UpdateEventHandler(object sender, FrmEditarEmpresas.UpdateEventArgs args)
        {
            CargarGrilla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarEmpresa AgregarEmpresa = new FrmAgregarEmpresa();
            AgregarEmpresa.UpdateEventHandler += AgEmp_UpdateEventHandler;
            AgregarEmpresa.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DtEmpresa.Rows.Count == 0)
            {
                MessageBox.Show("No Hay Registro Para Editar", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (DtEmpresa.SelectedRows == null)
                {
                    return;
                }
                else
                {

                    try
                    {
                        FrmEditarEmpresas EditarEmpresas = new FrmEditarEmpresas();
                        EditarEmpresas.UpdateEventHandler += EdEmp_UpdateEventHandler;
                        EditarEmpresas.TxtIdEmpresa.Text = DtEmpresa.SelectedRows[0].Cells[0].Value.ToString();
                        EditarEmpresas.TxtNombreEmpresa.Text = DtEmpresa.SelectedRows[0].Cells[1].Value.ToString();
                        EditarEmpresas.TxtDireccionEmpresa.Text = DtEmpresa.SelectedRows[0].Cells[2].Value.ToString();
                        EditarEmpresas.TxtTelefonoEmpresa.Text = DtEmpresa.SelectedRows[0].Cells[3].Value.ToString();
                        EditarEmpresas.TxtEmailEmpresa.Text = DtEmpresa.SelectedRows[0].Cells[4].Value.ToString();
                        
                        


                        EditarEmpresas.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Debe Seleccionar Un Registro Por Favor", "Editar Empresas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (DtEmpresa.Rows.Count == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Eliminar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (DtEmpresa.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult Resultados = MessageBox.Show("Esta seguro que desea eliminar esta Empresa", "Eliminar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Empresa.Id_Empresa = Convert.ToInt32(DtEmpresa.SelectedRows[0].Cells[0].Value.ToString());
                            Empresas.Delete(Empresa);
                            CargarGrilla();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe Seleccionar un registro para Eliminar", "Eliminar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

        }

        private void TxtBuscarClientes_TextChanged(object sender, EventArgs e)
        {

        }

        public void Buscar(string buscando)
        {

            Empresas.Buscar(buscando);

            try
            {
                if (CBTipoBusqueda.Text == "Codigo")
                {
                    buscando = TxtBuscarClientes.Text.Trim();
                    DtEmpresa.DataSource = Empresas.Buscar(buscando);
                }
                else if (CBTipoBusqueda.Text == "Nombre")
                {
                    buscando = TxtBuscarClientes.Text.Trim();
                    DtEmpresa.DataSource = Empresas.Buscar(buscando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La Empresa no fue encontrado por: " + ex.Message, "Buscar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
