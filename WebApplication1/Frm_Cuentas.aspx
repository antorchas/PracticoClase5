<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Cuentas.aspx.cs" Inherits="WebApplication1.Frm_Cuentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento de Cuentas</title>

     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
 <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />

    


</head>
<body>
    <form id="form1" runat="server">
             <div class="container">
                       <div class="row mt-1">
                           <h4>Mantenimiento de Cuentas</h4>
                           </div>
                 <div class="row mt-1">
                     <div class="col-4">

                  <asp:TextBox ID="txtDescripcion" runat="server" Width="350px" placeholder ="Nombre Categoría" ToolTip="Cargar la Descripcion" onkeyup ="Filtro()"></asp:TextBox>
                     </div>
                  <div class="col-1">

   <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                  </div>
                        <div class="col-2">
<asp:RadioButton ID="rbRegistrar" runat="server" Text="Registrar" GroupName="Accion" Checked="True" />
                            </div>
                     <div class="col-2">
                         <asp:RadioButton ID="rbEditar" Text="Editar" runat="server" GroupName="Accion" />
                         </div>
                     <div class="col-2">
                         <asp:RadioButton Text="Eliminar" ID="rbEliminar" runat="server" GroupName="Accion" />
                     </div>

                        <div class="col-1"> 
                      <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Frm_Principal.aspx">Volver</asp:HyperLink>
                        </div>
                 </div>
                                <div class="row mt-1">
                     <asp:DropDownList ID="ddlCuentas" runat="server" CssClass="js-example-basic-single" DataTextField="descripcion" DataValueField="idCuenta" Width="542px" AutoPostBack="True" OnSelectedIndexChanged="ddlCuentas_SelectedIndexChanged">
</asp:DropDownList>
               </div>
                    <div class="row mt-1">
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    </div>
                 <div class="row mt-1">
                     <div class="col-10">
                            <asp:Table ID="tblCuentas" CssClass="table" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
   </asp:Table>
                     </div>
                 </div>
         
         
             </div>
     
             <asp:SqlDataSource ID="SqlDTListadoCategorias" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" SelectCommand="SELECT [idCuenta], [descripcion] FROM [Cuentas]"></asp:SqlDataSource>


    </form>

         <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
 



    <script>
        function Filtro() {
            let filtro = document.getElementById('txtDescripcion').value.toLowerCase();
            let tabla = document.getElementById('tblCuentas');
            let filas = tabla.getElementsByTagName('tr');
            for (var i = 1; i < filas.length; i++) {
                var fila = filas[i];
                var celdas = fila.getElementsByTagName('td');
                var mostrarFila = false;
                for (var j = 0; j < celdas.length; j++) {
                    var celda = celdas[j];
                    if (celda) {
                        var contenido = celda.textContent || celda.innerText;
                        if (contenido.toLowerCase().indexOf(filtro) > -1) {
                            mostrarFila = true;
                            break;
                        }
                    }
                }
                fila.style.display = mostrarFila ? '' : 'none';
            }
        }


        function Confirmar() {
            return confirm('¿Estás seguro de que deseas eliminar esta cuenta?');
        }

        document.addEventListener("DOMContentLoaded", function () {
            $(".js-example-basic-single").select2();
        });
        

   

    </script>
   
     </body>
</html>
