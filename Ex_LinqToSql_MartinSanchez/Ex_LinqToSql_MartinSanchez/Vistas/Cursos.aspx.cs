using Ex_LinqToSql_MartinSanchez.BusinessLogic;
using Ex_LinqToSql_MartinSanchez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ex_LinqToSql_MartinSanchez.Vistas
{
    public partial class Cursos : System.Web.UI.Page
    {
        private CursoManager _cursoManager;
        private InscripcionManager _inscripcionManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCorreo"] == null)
            {
                Response.Redirect("~/Vistas/Login.aspx");
            }
            else
            {
                UsuarioManager usuarioManager = new UsuarioManager();
                string correo = Session["UsuarioCorreo"].ToString();
                Usuarios usuario = usuarioManager.ObtenerUsuarioPorCorreo(correo);

                if(usuario.Rol != "Usuario")
                {
                    Response.Redirect("AccesoDenegado.aspx");
                }
            }

            _cursoManager = new CursoManager();
            _inscripcionManager = new InscripcionManager();
            if (!IsPostBack)
            {
                gvCursos.DataSource = _cursoManager.ObtenerCursos();
                gvCursos.DataBind();
            }
        }

        //Inscribirse en curso
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            string correo = Session["UsuarioCorreo"].ToString();
            Usuarios usuario = usuarioManager.ObtenerUsuarioPorCorreo(correo);

            int cursoID = Convert.ToInt32(gvCursos.SelectedRow.Cells[0].Text);

            _inscripcionManager.InscribirUsuarioEnCurso(cursoID, usuario.UsuarioID);
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Server.Transfer("~/Vistas/Login.aspx");
        }
    }
}