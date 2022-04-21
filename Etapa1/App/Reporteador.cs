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
            var listaEvaluaciones = GetListaEvaluaciones();
            
            return (from Evaluacion ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
           
        }

        public Dictionary<string, IEnumerable<Evaluacion>>GetDiccionarioEvaluacionXAsig()
        {
           var diccionarioRta= new Dictionary<string, IEnumerable<Evaluacion>>();

           return diccionarioRta;
        }





    }
}