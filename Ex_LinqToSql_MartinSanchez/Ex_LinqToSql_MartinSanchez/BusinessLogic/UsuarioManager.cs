using Ex_LinqToSql_MartinSanchez.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ex_LinqToSql_MartinSanchez.BusinessLogic
{
    public class UsuarioManager
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["GestionCursosDBConnectionString"].ConnectionString;
        private DataClassesDataContext _context;

        public UsuarioManager()
        {
            _context = new DataClassesDataContext(cadenaConexion);
        }

        public bool Autenticar(string correo, string contrasena)
        {
            Usuarios usuario = _context.Usuarios.Where(u => u.Correo == correo && u.Contrasena == contrasena).SingleOrDefault();

            bool autenticar = (usuario != null) ? true : false;
            
            return autenticar;
        }

        public Usuarios ObtenerUsuarioPorCorreo(string correo)
        {
            Usuarios usuario = _context.Usuarios.Where(u => u.Correo == correo).SingleOrDefault();            

            return usuario;
        }

        public bool EsUsuarioAdmin(string correo)
        {
            Usuarios usuario = ObtenerUsuarioPorCorreo(correo);

            bool esAdmin = usuario.Rol == "Admin" ? true : false;

            return esAdmin;
        }
    }
}