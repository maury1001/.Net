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


            escuela.Cursos = new Curso[]{
             new Curso(){Nombre = "101"},
             new Curso(){Nombre = "201"},
             new Curso(){Nombre = "301"}
            };

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