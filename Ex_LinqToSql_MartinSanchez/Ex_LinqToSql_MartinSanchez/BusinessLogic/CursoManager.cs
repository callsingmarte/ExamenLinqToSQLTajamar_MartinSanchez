using Ex_LinqToSql_MartinSanchez.Models;
using Ex_LinqToSql_MartinSanchez.Vistas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ex_LinqToSql_MartinSanchez.BusinessLogic
{
    public class CursoManager
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["GestionCursosDBConnectionString"].ConnectionString;
        private DataClassesDataContext _context;

        public CursoManager()
        {
            _context = new DataClassesDataContext(cadenaConexion);
        }

        public List<Models.Cursos> ObtenerCursos()
        {
            return _context.Cursos.ToList();
        } 
        public void AgregarCurso(Models.Cursos curso)
        {
            Models.Cursos cursoInsertar = new Models.Cursos
            {
                Titulo = curso.Titulo,
                Descripcion = curso.Descripcion,
                FechaInicio = curso.FechaInicio,
                Duracion = curso.Duracion
            };
            _context.Cursos.InsertOnSubmit(curso);
            _context.SubmitChanges();
        } 

        public void EditarCurso(int cursoId, Models.Cursos curso)
        {
            Models.Cursos cursoUpdate = _context.Cursos.Where(c => c.CursoID == cursoId).SingleOrDefault();

            if (cursoUpdate != null)
            {
                cursoUpdate.Titulo = curso.Titulo;
                cursoUpdate.Descripcion = curso.Descripcion;
                cursoUpdate.FechaInicio = curso.FechaInicio;
                cursoUpdate.Duracion = curso.Duracion;

                _context.SubmitChanges();
            }
        } 

        public void EliminarCurso(int cursoId)
        {
            var cursosConInscripciones = _context.Inscripciones.Where(c => c.CursoID == cursoId).FirstOrDefault();

            if(cursosConInscripciones == null)
            {
                Models.Cursos curso = _context.Cursos.Where(c => c.CursoID == cursoId).SingleOrDefault();
                if (curso != null) {
                    _context.Cursos.DeleteOnSubmit(curso);
                    _context.SubmitChanges();
                }
            }
        }

        public Models.Cursos ObtenerCursoPorID(int cursoId) 
        {
            Models.Cursos curso = _context.Cursos.Where(c => c.CursoID == cursoId).SingleOrDefault();

            return curso;
        }
    }
}