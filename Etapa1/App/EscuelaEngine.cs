using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
   
        }

        public void Inicializar()
        {
             Escuela = new Escuela("UNTDF",2013, TiposEscuela.Primaria, "Argentina", "Ushuaia");

             Escuela.Cursos = new List<Curso>(){
             new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
             new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            };;
        }

            // // los delegados solo aceptan metodos que devuelvan booleanos y que reciban como parametro el tipo de dato generico       
            // Escuela.Cursos.RemoveAll(delegate(Curso cur){return cur.Nombre == "301";});

            // //delegado como función lambda
            // Escuela.Cursos.RemoveAll((Curso cur) => cur.Nombre == "501");



    }
}