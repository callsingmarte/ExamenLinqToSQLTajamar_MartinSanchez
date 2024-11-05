<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Ex_LinqToSql_MartinSanchez.Vistas.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AdminDashBoard</title>
    <!--Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-control text-center">
            <asp:GridView runat="server" ID="gvCursos" 
                AutoGenerateColumns="false"
                OnSelectedIndexChanged="gvCursos_SelectedIndexChanged" 
                OnRowDeleting="gvCursos_RowDeleting"
                OnRowEditing="gvCursos_RowEditing"
                OnRowCancelingEdit="gvCursos_RowCancelingEdit"
                DataKeyNames="CursoID"
            >
                <Columns>
                        <asp:BoundField DataField="CursoID" HeaderText="ID" />
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                        <asp:BoundField DataField="Duracion" HeaderText="Duracion" />
                        <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button"/>
                </Columns>
            </asp:GridView>
        </div>
        <div class="form-control card p-4 shadow">
            <h3 class="text-center mb-4">Insertar o Editar Curso</h3>
            <asp:HiddenField ID="hCursoID" runat="server" />
            <div class="form-control">
                <asp:Label runat="server" AssociatedControlID="txtTitulo" Text="Titulo"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" placeholder="Introduce un titulo"></asp:TextBox>
            </div>
            <div class="form-control">
                <asp:Label runat="server" AssociatedControlID="txtDescripcion" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Introduce una descripcion"></asp:TextBox>
            </div>
            <div class="form-control">
                <asp:Label runat="server" AssociatedControlID="txtFechaInicio" Text="Fecha Inicio"></asp:Label>
                <asp:TextBox ID="txtFechaInicio" runat="server" placeholder="Introduce una fecha de inicio"></asp:TextBox>
            </div>
            <div class="form-control">
                <asp:Label runat="server" AssociatedControlID="txtDuracion" Text="Duracion"></asp:Label>
                <asp:TextBox ID="txtDuracion" runat="server" placeholder="Introduce una duracion del curso"></asp:TextBox>
            </div>
            <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" CssClass="btn btn-primary" Text="Agregar o Editar Curso"/>
        </div>
        <asp:LinkButton ID="LogoutButton" runat="server" OnClick="LogoutButton_Click" CssClass="btn btn-danger"> 
            Cerrar Sesión
        </asp:LinkButton>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
