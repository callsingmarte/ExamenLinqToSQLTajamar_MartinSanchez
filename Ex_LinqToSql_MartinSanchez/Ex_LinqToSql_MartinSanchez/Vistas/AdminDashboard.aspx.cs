using Ex_LinqToSql_MartinSanchez.BusinessLogic;
using Ex_LinqToSql_MartinSanchez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ex_LinqToSql_MartinSanchez.Vistas
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        private CursoManager _cursoManager;

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

                if (usuario.Rol != "Admin")
                {
                    Server.Transfer("~/Vistas/AccesoDenegado.aspx");
                }
            }
            _cursoManager = new CursoManager();

            if (!IsPostBack) {
                gvCursos.DataSource = _cursoManager.ObtenerCursos();
                gvCursos.DataBind();
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {

            if (txtTitulo.Text != null && txtDuracion.Text != null && txtFechaInicio.Text != null)
            {
                Models.Cursos cursoInsertar = new Models.Cursos
                {
                    Titulo = txtTitulo.Text,
                    Descripcion = txtDescripcion.Text,
                    FechaInicio = Convert.ToDateTime(txtFechaInicio.Text),
                    Duracion = Convert.ToInt32(txtDuracion.Text)
                };


                if (hCursoID.Value != null)
                {                   
                    _cursoManager.EditarCurso(Convert.ToInt32(hCursoID.Value), cursoInsertar);
                    gvCursos.EditIndex = -1;
                }
                else
                {
                    _cursoManager.AgregarCurso(cursoInsertar);
                }

                gvCursos.DataSource = _cursoManager.ObtenerCursos();
                gvCursos.DataBind();

                hCursoID.Value = null;
                txtTitulo.Text = "";
                txtDescripcion.Text = "";
                txtFechaInicio.Text = "";
                txtDuracion.Text = "";

            }
        }

        protected void gvCursos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cursoID = Convert.ToInt32(gvCursos.DataKeys[e.RowIndex].Value.ToString());
            _cursoManager.EliminarCurso(cursoID);
            gvCursos.DataSource = _cursoManager.ObtenerCursos();
            gvCursos.DataBind();
        }

        protected void gvCursos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int cursoID = Convert.ToInt32(gvCursos.DataKeys[e.NewEditIndex].Value.ToString());

            Models.Cursos curso = _cursoManager.ObtenerCursoPorID(cursoID);

            if (curso != null)
            {
                hCursoID.Value = cursoID.ToString();
                txtTitulo.Text = curso.Titulo;
                txtDescripcion.Text = curso.Descripcion;
                txtFechaInicio.Text = curso.FechaInicio.ToString();
                txtDuracion.Text = curso.Duracion.ToString();
            }
            gvCursos.EditIndex = -1;
        }

        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Server.Transfer("~/Vistas/Login.aspx");
        }

        protected void gvCursos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCursos.EditIndex = -1;    
        }
    }
}