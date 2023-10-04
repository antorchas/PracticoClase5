using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Frm_RegistrosContables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTable();
                FillddlCuentas();



            }
        }


        private void FillddlCuentas()
        {
            SqlQuerys list = new SqlQuerys();
            DataTable dt = new DataTable();
            dt = list.ListarCuentas();

            ddlCuentas.DataSource = dt;
            ddlCuentas.DataTextField = "descripcion";
            ddlCuentas.DataValueField = "idCuenta";
            ddlCuentas.DataBind();


        }
        private int TipoCuenta()
        {
            if (rbDebe.Checked) return 0;
            else return 1;
        }
        private void Registrar()
        {
            SqlQuerys query = new SqlQuerys();
           if(query.InsertarRegistroContable(Convert.ToInt32(ddlCuentas.SelectedValue), Convert.ToDouble(txtMonto.Text), TipoCuenta()))
            {
               lblInfo.ForeColor = Color.Green;
                lblInfo.Text = "Registro contable registrado corretamente.";
            }
           else
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "El Registro contable no se pudo registrar.";
            }
            ddlRegistrosContables.DataBind();
        }
        public bool Validar(bool esEliminar = false)
        {
            lblInfo.ForeColor = Color.Red;
            if (!esEliminar)
            {

            if (ddlCuentas.SelectedIndex == -1)
            {
                lblInfo.Text = "Debe seleccionar una cuenta.";
                return false;
            }

            if(string.IsNullOrEmpty(txtMonto.Text.Trim()))
                {
                    lblInfo.Text = "Debe ingresar un monto.";
                    return false;
                }

            }
            else
            {
                if (ddlRegistrosContables.SelectedIndex == -1)
                {
                    lblInfo.Text = "Debe seleccionar un registro contable para realizar la acción requerida.";
                    return false;
                }
            }
      
            return true;
        }
        protected void FillTable()
        {
            try
            {
                DataView dt = (DataView)SqldtRegistrosContables.Select(DataSourceSelectArguments.Empty);


                if (dt != null && dt.Count > 0)
                {
                    TableRow headerRow = new TableRow();

                    TableCell headerCell1 = new TableCell();
                    headerCell1.Text = "Id";
                    headerRow.Cells.Add(headerCell1);

                    TableCell headerCell2 = new TableCell();
                    headerCell2.Text = "Descrpción";
                    headerRow.Cells.Add(headerCell2);

                    TableCell headerCell3 = new TableCell();
                    headerCell3.Text = "Debe";
                    headerRow.Cells.Add(headerCell3);

                    TableCell headerCell4 = new TableCell();
                    headerCell4.Text = "Haber";
                    headerRow.Cells.Add(headerCell4);

                    tblRegistrosContables.Rows.Add(headerRow);

                    foreach (DataRowView rowView in dt)
                    {
                        DataRow row = rowView.Row;
                        TableRow tableRow = new TableRow();

                        TableCell cell1 = new TableCell();
                        cell1.Text = row["id"].ToString();
                        tableRow.Cells.Add(cell1);

                        TableCell cell2 = new TableCell();
                        cell2.Text = row["descripcion"].ToString();
                        tableRow.Cells.Add(cell2);

                        TableCell cell3 = new TableCell();
                        cell3.Text = row["debe"].ToString();
                        tableRow.Cells.Add(cell3);

                        TableCell cell4 = new TableCell();
                        cell4.Text = row["haber"].ToString();
                        tableRow.Cells.Add(cell4);



                        tblRegistrosContables.Rows.Add(tableRow);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ObtenerRegistroContale()
        {
            SqlQuerys query = new SqlQuerys();
        
            RegistroContableModel model = new RegistroContableModel();  
            model = query.ObtenerRegistroContablePorId(Convert.ToInt32(ddlRegistrosContables.SelectedValue));

            ddlCuentas.SelectedValue = model.idCuenta.ToString().Trim();
            txtMonto.Text = model.monto.ToString().Trim();
            if (model.tipo == 0)
            {
                rbDebe.Checked = true;
                rbHaber.Checked = false;

            }

            else {
                rbDebe.Checked = false;
                rbHaber.Checked = true;
            }

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

            Registrar();
            FillTable();
            }
        }

        protected void ddlCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        protected void ddlRegistrosContables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerRegistroContale();
            FillTable();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar(true))
            {
                SqlQuerys query = new SqlQuerys();
                RegistroContableModel model = new RegistroContableModel();
                model.id = Convert.ToInt32(ddlRegistrosContables.SelectedValue);
                model.idCuenta = Convert.ToInt32(ddlCuentas.SelectedValue);
                model.tipo = TipoCuenta();
                model.monto = Convert.ToDouble(txtMonto.Text);
              if(query.ActualizarRegistroContable(model))
                {
                    lblInfo.ForeColor = Color.Green;
                    lblInfo.Text = "Registro Actualizado Correctamente.";
                }
              else
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = "El Registro no se pudo Actualizar";
                }
                ddlRegistrosContables.DataBind();
                FillTable();
            }
         
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Validar(true))
            {
                SqlQuerys query = new SqlQuerys();
               if(query.EliminarRegistroContable(Convert.ToInt32(ddlRegistrosContables.SelectedValue)))
                {
                    lblInfo.ForeColor = Color.Green;
                    lblInfo.Text = "Registro Eliminado Correctamente.";
                }
               else
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = "El Registro no se pudo Eliminar";
                }
                ddlRegistrosContables.DataBind();
                FillTable();
            }
         
        }

        protected void rbDebe_CheckedChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        protected void rbHaber_CheckedChanged(object sender, EventArgs e)
        {
            FillTable();
        }
    }
}