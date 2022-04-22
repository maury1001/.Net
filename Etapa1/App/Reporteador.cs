using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela.App
{
    public  class Reporteador
    {

        Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> diccionario;
        public Reporteador(Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if(dicObsEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObsEsc));
            }
            diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            var respuesta = diccionario.TryGetValue(LlaveDiccionario.Evaluacion,out IEnumerable<ObjetoEscuelaBase> lista);
            if(respuesta)
            {
               return lista.Cast<Evaluacion>();
            } else
            {
                return new List<Evaluacion>();
            }
           
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion>listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            
            return (from Evaluacion ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
           
        }

        public Dictionary<string, IEnumerable<Evaluacion>>GetDiccionarioEvaluacionXAsig()
        {
           var diccionarioRta= new Dictionary<string, IEnumerable<Evaluacion>>();

           var listaAsignaturas = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asig in listaAsignaturas)
            {
                var  evalAsignaturas = from evaluacion in listaEvaluaciones
                                       where evaluacion.Asignatura.Nombre == asig
                                       select evaluacion;
                diccionarioRta.Add(asig, evalAsignaturas);
            }

           return diccionarioRta;
        }


        public Dictionary<string,IEnumerable<AlumnoPromedio>> GetPromedioAlumno()
        {
            var rta = new Dictionary<string,IEnumerable<AlumnoPromedio>>();

            var diccionarioEvalAsignatura = GetDiccionarioEvaluacionXAsig();

            foreach (var asignConEval in diccionarioEvalAsignatura)
            {
                var promediosAlumnos = from eval in asignConEval.Value
                                       group eval by new {eval.Alumno.UniqueId,
                                                          eval.Alumno.Nombre}
                                        into grupoEvalsAlumno
                                        //objeto anonimo
                                        select new AlumnoPromedio { alumnoid = grupoEvalsAlumno.Key.UniqueId,
                                                                    alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                                                    promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)};

                
                rta.Add(asignConEval.Key,promediosAlumnos);
            }


            return rta;
        }

        public Dictionary<string,IEnumerable<AlumnoPromedio>> GetTopPromedios(int topAlumnos)
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

            var diccionarioPromedios = GetPromedioAlumno();

            foreach (var promedio in diccionarioPromedios)
            {
                var topPromedios = (from promAlumno in promedio.Value
                                   orderby promAlumno.promedio descending
                                   select new AlumnoPromedio {alumnoNombre = promAlumno.alumnoNombre,
                                                              promedio = promAlumno.promedio}).Take(topAlumnos);


                rta.Add(promedio.Key,topPromedios);
            }                      

            return rta;
        }
    }
}