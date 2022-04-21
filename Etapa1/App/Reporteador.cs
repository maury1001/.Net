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





    }
}