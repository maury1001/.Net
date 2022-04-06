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
            CargarCursos();
            CargarAsignaturas();

            CargarEvaluaciones();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){Nombre = "Matemática"},
                    new Asignatura(){Nombre = "Educación Física"},
                    new Asignatura(){Nombre = "Lengua"},
                    new Asignatura(){Nombre = "Ciencias Naturales"}
                };                
                curso.Asignaturas = listaAsignaturas;
            }
        }
        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] primerNombre = {"Adrian","Sonia","Sebastian"};
            string[] segundoNombre = {"Mauricio","Beatriz","Nicolas"};
            string[] apellido = {"Allaman","Bagnoud","Rober"};

            var listaAlumnos = from n1 in primerNombre
                               from n2 in segundoNombre
                               from a1 in apellido
                               select new Alumno{Nombre = $"{n1} {n2} {a1}"};
            return listaAlumnos.OrderBy((al)=>al.UniqueId).Take(cantidad).ToList();
        }
        private void CargarEvaluaciones()
        {
            
        }



        private void CargarCursos()
        {
            Escuela = new Escuela("UNTDF", 2013, TiposEscuela.Primaria, "Argentina", "Ushuaia");

            Escuela.Cursos = new List<Curso>(){
             new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
             new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            }; ;

            
            foreach (var curso in Escuela.Cursos)
            {
                //Random rnd = new Random();
                int cantRandom = new Random().Next(5,20);
                curso.Alumnos = GenerarAlumnos(cantRandom);
            }
        }

        // // los delegados solo aceptan metodos que devuelvan booleanos y que reciban como parametro el tipo de dato generico       
        // Escuela.Cursos.RemoveAll(delegate(Curso cur){return cur.Nombre == "301";});

        // //delegado como función lambda
        // Escuela.Cursos.RemoveAll((Curso cur) => cur.Nombre == "501");



    }
}