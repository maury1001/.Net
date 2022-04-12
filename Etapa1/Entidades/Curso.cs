using System;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {

        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas {get;set;}
        public List<Alumno> Alumnos {get;set;}

        public string Direccion { get; set; }


         public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
    }
}