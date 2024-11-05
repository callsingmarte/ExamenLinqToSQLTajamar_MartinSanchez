<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ex_LinqToSql_MartinSanchez.Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!--Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="form-container card p-4 shadow">
            <h3 class="text-center mb-4">Iniciar Sesion de Usuario</h3>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCorreo" class="form-label" Text="Correo:"></asp:Label>
                <asp:TextBox runat="server" ID="txtCorreo" TextMode="Email" CssClass="form-control" placeholder="Ingresa tu correo"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtContrasena" class="form-label" Text="Contraseña:"></asp:Label>
                <asp:TextBox runat="server" ID="txtContrasena" TextMode="Password" CssClass="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="errorMsg"></asp:Label>
            </div>
            <div class="d-grid gap-2 mt-2">
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-primary" Text="Iniciar Sesion"/>
            </div>
        </div>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
