﻿﻿using System;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using CoreEscuela.App;

namespace CoreEscuela
{
    class Program
    {

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evaList = reporteador.GetListaEvaluaciones();
            var asigList = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDiccionarioEvaluacionXAsig();
            var topProm = reporteador.GetTopPromedios(5);
            
            Printer.WriteTitle("Captura de una Evaluación por Consola");

            var newEval = new Evaluacion();
            string nombre,notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El nombre de la evaluación no puede estar vacío");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            } 

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notaString = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(notaString))
            {
                throw new ArgumentException("El valor de la nota no puede ser vacio");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if(newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluacion ha sido ingresado correctamente");
                }
                catch(ArgumentOutOfRangeException arge)
                {
                    Printer.WriteTitle(arge.Message);
                }
                catch(Exception)
                {
                    Printer.WriteTitle("El valor de la nota no es un numero válido");
                    
                }
                finally
                {
                    Printer.WriteTitle("FINALLY");
                }
                             
            } 
            
        }

        private static void AccionDelEvento(object? sender, EventArgs e)
        {
            Printer.WriteTitle("FIN PROGRAMA");
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