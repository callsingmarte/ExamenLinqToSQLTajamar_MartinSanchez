<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccesoDenegado.aspx.cs" Inherits="NorthWindAplicacion.Vistas.AccesoDenegado" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Acceso Denegado</title>
<style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            padding: 50px;
        }
        .container {
            max-width: 600px;
            margin: auto;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #d9534f;
        }
        p {
            color: #333;
        }
        .btn {
            display: inline-block;
            padding: 10px 20px;
            margin-top: 20px;
            font-size: 16px;
            color: #fff;
            background-color: #337ab7;
            text-decoration: none;
            border-radius: 5px;
        }
        .btn:hover {
            background-color: #286090;
        }
</style>
</head>
<body>
<form id="form1" runat="server">
    <div class="container">
        <h1>Acceso Denegado</h1>
        <p>No tienes permiso para acceder a esta página.</p>
        <p>Si crees que esto es un error, por favor contacta al administrador.</p>
        <a href="Login.aspx" class="btn">Volver a Inicio</a>
    </div>
</form>
</body>
</html>