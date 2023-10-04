<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_RegistrosContables.aspx.cs" Inherits="WebApplication1.Frm_RegistrosContables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registros Contables</title>
         <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
 <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
                 <div class="row mt-1">
        <h4>Registros Contables</h4>
        </div>
           
             <div class="row mt-1">

                 <div class="col-4">

                     <asp:DropDownList ID="ddlCuentas" runat="server" CssClass="js-example-basic-single" DataTextField="descripcion" DataValueField="idCuenta" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlCuentas_SelectedIndexChanged" >
</asp:DropDownList>
                 </div>
                 <div class="col-3"> 
                     <asp:Label ID="Label1" runat="server" Text="Monto:"></asp:Label>
                     <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                 </div>
                   <div class="col-3"> 
                         <div class="row mt-1">
                                <div class="col-6"> 
                                    <asp:RadioButton ID="rbDebe" runat="server" Text="Debe" GroupName="Tipo" AutoPostBack="True" OnCheckedChanged="rbDebe_CheckedChanged" Checked="True" />
                                </div>
                             <div class="col-6"> 
                                 <asp:RadioButton ID="rbHaber" runat="server" Text ="Haber" GroupName="Tipo" AutoPostBack="True" OnCheckedChanged="rbHaber_CheckedChanged"/>
                          
</div>
                             </div>
 
  </div>
                    <div class="col-2">  
                        <asp:Button ID="btnConfirmar" runat="server" Text="Registrar" OnClick="btnConfirmar_Click" />
                           <asp:HyperLink ID="hplVolver" runat="server" NavigateUrl="~/Frm_Principal.aspx">volver</asp:HyperLink>
                    </div>
               </div>
              <div class="row mt-3"> 
                    <div class="col-4">
       <asp:DropDownList ID="ddlRegistrosContables" runat="server" CssClass="js-example-basic-single" DataTextField="Descripcion" DataValueField="id" Width="300px" AutoPostBack="True" DataSourceID="sqlRistrosCtblesVisualizar" OnSelectedIndexChanged="ddlRegistrosContables_SelectedIndexChanged"  >
</asp:DropDownList>
                        </div>
                  <div class="col-2">
                      <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                      </div>
                           <div class="col-2">
<asp:Button ID="btnEliminar" runat="server"  BackColor="red" ForeColor="White"  Text="Eliminar" OnClick="btnEliminar_Click" />
</div>

              </div>
           

</div>
        <div class="row mt-2">  
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
        </div>
                              <div class="row mt-5">
                     <div class="col-10">
                            <asp:Table ID="tblRegistrosContables" CssClass="table" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
   </asp:Table>
                     </div>
                 </div>
             
        </div>
             <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>

<script>
    


    function Confirmar() {
        return confirm('¿Estás seguro de que deseas eliminar esta cuenta?');
    }

    document.addEventListener("DOMContentLoaded", function () {
        $(".js-example-basic-single").select2();
    });
    

   

</script>
         <asp:SqlDataSource ID="SqldtRegistrosContables" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" SelectCommand="  select a.id, b.descripcion, case when a.tipo = 0 then Convert(nvarchar, a.monto) else '-' end Debe,
  case when a.tipo = 1 then Convert(nvarchar,a.monto) else '-' end Haber
  from RegistrosContables a, Cuentas b
  where a.idCuenta = b.idCuenta"></asp:SqlDataSource>
         <asp:SqlDataSource ID="sqlRistrosCtblesVisualizar" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" SelectCommand=" select a.id, case when a.tipo = 0 then  b.descripcion + ' - Debe ' + Convert(nvarchar, a.monto) else 
	b.descripcion + ' - Haber ' + Convert(nvarchar, a.monto) end Descripcion
  from RegistrosContables a, Cuentas b
  where a.idCuenta = b.idCuenta"></asp:SqlDataSource>
    </form>
             </body>
</html>
