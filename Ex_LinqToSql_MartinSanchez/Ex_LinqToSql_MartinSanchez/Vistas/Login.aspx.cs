using Ex_LinqToSql_MartinSanchez.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace Ex_LinqToSql_MartinSanchez.Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        private UsuarioManager _usuarioManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            _usuarioManager = new UsuarioManager();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;

            if(_usuarioManager.Autenticar(correo, contrasena))
            {
                Session["UsuarioCorreo"] = correo;

                if (_usuarioManager.EsUsuarioAdmin(correo))
                {
                    Server.Transfer("~/Vistas/AdminDashboard.aspx");
                }
                else
                {
                    Server.Transfer("~/Vistas/Cursos.aspx");
                }
            }
            else
            {
                errorMsg.Text = "Nombre de usuario o contraseña incorrectos";
                errorMsg.ForeColor = Color.Red;
            }
        }
    }
}