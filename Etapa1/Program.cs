using System;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;


namespace CoreEscuela
{
    class Program
    {

        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            ImprimirCursosEscuela(engine.Escuela);
            //engine.Escuela.LimpiarLugar();
            int dummy = 0;
            var listaObjetos = engine.GetObjetosEscuela(out int conteoEvaluaciones,out dummy,out dummy,out dummy);
            var listaILugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar)obj;

      
        }      
          

        private static void ImprimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");        
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