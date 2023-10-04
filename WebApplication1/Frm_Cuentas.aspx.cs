using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Frm_Cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTable();
                FillddlCuentas();

            }
        }
        private bool Validar()

        {
            lblInfo.ForeColor = System.Drawing.Color.Red;
            SqlQuerys sqlQuerys = new SqlQuerys();
            if (rbRegistrar.Checked)
            {
                if (sqlQuerys.ExistsCuenta(txtDescripcion.Text.Trim()))
            {
            
                lblInfo.Text = "La cuenta que intenta ingresar ya se cuentra registrada";
                FillTable();
                return false;
            }
            }
            else
            {
                if(ddlCuentas.SelectedIndex == -1)
                {
                    lblInfo.Text = "No hay cuentas registradas para realizar la acción que desea.";
                    return false;
                }
            }
            if (!rbEliminar.Checked)
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                lblInfo.Text = "Debe ingresar una cuenta para realizar la acción seleccionada.";
                FillTable();
                return false;
            }
            }
            return true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            SqlQuerys query = new SqlQuerys();
            if (Validar())
            {
                if (rbRegistrar.Checked)
                {

               if(query.InsertarCuenta(txtDescripcion.Text.Trim()))
                    {
                        FillTable();
                        FillddlCuentas();
                        lblInfo.ForeColor = System.Drawing.Color.Green;
                        lblInfo.Text = "La cuenta se registró correctamente!";
                    } else
                    {
                        lblInfo.ForeColor = System.Drawing.Color.Red;
                        lblInfo.Text = "La cuenta no se pudo registrar";
                    }
               
                }
                else if (rbEditar.Checked)
                {
                    if (query.EditarCuenta(Convert.ToInt32(ddlCuentas.SelectedValue), txtDescripcion.Text.Trim()))
                    {
                        FillTable();
                        FillddlCuentas();
                        lblInfo.ForeColor = System.Drawing.Color.Green;
                        lblInfo.Text = "La cuenta se actualizó correctamente!";
                    }
                    else
                    {
                        lblInfo.ForeColor = System.Drawing.Color.Red;
                        lblInfo.Text = "La cuenta no se pudo actualizar";
                    }
                }

                else if (rbEliminar.Checked)
                {
                    if (query.EliminarCuenta(Convert.ToInt32(ddlCuentas.SelectedValue)))
                    {
                        FillTable();
                        FillddlCuentas();
                        lblInfo.ForeColor = System.Drawing.Color.Green;
                        lblInfo.Text = "La cuenta se eliminó correctamente!";
                    }
                    else
                    {
                        lblInfo.ForeColor = System.Drawing.Color.Red;
                        lblInfo.Text = "La cuenta no se pudo eliminar.";
                    }
                }
                else
                {
                    lblInfo.ForeColor=System.Drawing.Color.Red;
                    lblInfo.Text = "Debe seleccionar una acción ha realizar.";
                }


            }



        }
        protected void FillTable()
        {
            try
            {
                DataView dt = (DataView)SqlDTListadoCategorias.Select(DataSourceSelectArguments.Empty);


                if (dt != null && dt.Count > 0)
                {
                    TableRow headerRow = new TableRow();

                    TableCell headerCell1 = new TableCell();
                    headerCell1.Text = "Id";
                    headerRow.Cells.Add(headerCell1);

                    TableCell headerCell2 = new TableCell();
                    headerCell2.Text = "Descrpción";
                    headerRow.Cells.Add(headerCell2);

                    tblCuentas.Rows.Add(headerRow);

                    foreach (DataRowView rowView in dt)
                    {
                        DataRow row = rowView.Row;
                        TableRow tableRow = new TableRow();

                        TableCell cell1 = new TableCell();
                        cell1.Text = row["idCuenta"].ToString();
                        tableRow.Cells.Add(cell1);

                        TableCell cell2 = new TableCell();
                        cell2.Text = row["descripcion"].ToString();
                        tableRow.Cells.Add(cell2);



                        tblCuentas.Rows.Add(tableRow);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", $"alert('Error');", true);
            }
        }

      private void  FillddlCuentas()
        {
            SqlQuerys list = new SqlQuerys();
            DataTable dt = new DataTable(); 
            dt = list.ListarCuentas();

            ddlCuentas.DataSource = dt;
            ddlCuentas.DataTextField = "descripcion";
            ddlCuentas.DataValueField = "idCuenta";
            ddlCuentas.DataBind();  
           

        }

      

        protected void ddlCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtDescripcion.Text = ddlCuentas.SelectedItem.Text;
            FillTable();              
      
     
        }
    }
}