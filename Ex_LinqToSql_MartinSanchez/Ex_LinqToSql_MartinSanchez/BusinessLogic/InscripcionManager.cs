using Ex_LinqToSql_MartinSanchez.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ex_LinqToSql_MartinSanchez.BusinessLogic
{
    public class InscripcionManager
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["GestionCursosDBConnectionString"].ConnectionString;
        private DataClassesDataContext _context;

        public InscripcionManager()
        {
            _context = new DataClassesDataContext(cadenaConexion);
        }

        public void InscribirUsuarioEnCurso(int CursoId, int usuarioId)
        {
            Inscripciones inscripcion = _context.Inscripciones.Where(i => i.UsuarioID == usuarioId).FirstOrDefault();
            //Los usuarios solo se pueden inscribir en un curso
            if (inscripcion == null) {
                Inscripciones inscripcionInsertar = new Inscripciones
                {
                    CursoID = CursoId,
                    UsuarioID = usuarioId
                };

                _context.Inscripciones.InsertOnSubmit(inscripcionInsertar);
                _context.SubmitChanges();
            }
        }
    }
}