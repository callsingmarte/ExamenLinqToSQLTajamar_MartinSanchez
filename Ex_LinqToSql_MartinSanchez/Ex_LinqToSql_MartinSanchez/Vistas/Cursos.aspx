<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="Ex_LinqToSql_MartinSanchez.Vistas.Cursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cursos</title>
    <!--Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="gvCursos"
                AutoGenerateColumns="false"
                OnSelectedIndexChanged="gvCursos_SelectedIndexChanged"
                DataKeyNames="CursoID"
                >
                <Columns>
                        <asp:BoundField DataField="CursoID" HeaderText="ID" />
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                        <asp:BoundField DataField="Duracion" HeaderText="Duracion" />
                        <asp:ButtonField ButtonType="Button" Text="Inscribirse" CommandName="Select"/>
                </Columns>
            </asp:GridView>
            <asp:LinkButton ID="LogoutButton" runat="server" OnClick="LogoutButton_Click" CssClass="btn btn-danger"> 
                Cerrar Sesión
            </asp:LinkButton>
        </div>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
