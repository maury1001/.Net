using System;
using CoreEscuela.Entidades;
using CoreEscuela.Escuela;
using static System.Console;


namespace Etapa1
{
    class Program
    {

        static void Main(string[] args)
        {
            var escuela = new Escuela("UNTDF",2013, TiposEscuela.Primaria, "Argentina", "Ushuaia");
            Console.WriteLine(escuela);

            var listaCursos = new List<Curso>(){
             new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
             new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana}
            };;

            escuela.Cursos = listaCursos;
            escuela.Cursos.Add(new Curso{Nombre = "102", Jornada = TiposJornada.Tarde});
            escuela.Cursos.Add(new Curso{Nombre = "202", Jornada = TiposJornada.Tarde});

            var otraColeccion = new List<Curso>(){
              new Curso(){Nombre = "401", Jornada = TiposJornada.Mañana},
              new Curso(){Nombre = "501", Jornada = TiposJornada.Mañana},
              new Curso(){Nombre = "502", Jornada = TiposJornada.Tarde}
             };;

            otraColeccion.Clear();
            escuela.Cursos.AddRange(otraColeccion);

            
            ImprimirCursosEscuela(escuela);
        }
            
        private static void ImprimirCursosEscuela(Escuela escuela)
        {

            WriteLine("====================");
            WriteLine("Cursos de la Escuela");
            WriteLine("====================");
            
                //El carácter ? usado dentro de una condicional que contenga como parámetro de evaluación un objeto con un atributo, sirve para indicarle a 
                //C# que solamente después de verificar la condición en el objeto y esta sea verdadera, pase a verificar la condición en el atributo.
                // es lo mismo que hacer
                // if (escuela != null && escuela.Cursos != null)
                if (escuela?.Cursos != null){
                    foreach (var curso in escuela.Cursos)
                    {
                        Console.WriteLine($"Nombre {curso.Nombre }, Id {curso.UniqueId}");
                    }                 
                }else{
                    return;   
                }     
        }
    }
}