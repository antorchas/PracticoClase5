<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Principal.aspx.cs" Inherits="WebApplication1.Frm_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú Principal</title>
         <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />

</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
               <div class="row mt-1">
                   <h3>Menú Principal</h3>
                   </div>
            <div class="row mt-2">
                   <div class="col-3">  
                       <asp:HyperLink ID="hLMtmientoCuentas" runat="server" NavigateUrl="~/Frm_Cuentas.aspx">Mantenimiento de Cuentas</asp:HyperLink>
                   </div>
                   <div class="col-3">  
                         <asp:HyperLink ID="hlRegistrosContables" runat="server" NavigateUrl="~/Frm_RegistrosContables.aspx">Registros Contables</asp:HyperLink>

   </div>
                   <div class="col-6">  

   </div>
                </div>
        </div>
    </form>
    

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
 
</body>
</html>
