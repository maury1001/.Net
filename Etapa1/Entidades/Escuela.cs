using CoreEscuela.Entidades;
using CoreEscuela.Util;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {

        public int AñoDeCreacion{get;set;}

        public string Pais{get;set;}
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        
        public TiposEscuela TipoEscuela{get;set;}

        public List<Curso> Cursos {get;set;}


        //constructor tradicional
        // public Escuela (string nombre, int año)
        // {
        //     this.nombre = nombre;
        //     this.AñoDeCreacion = año;
        // }
        
        public Escuela (string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);
        public Escuela (string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            //asignación de tuplas
            (Nombre, AñoDeCreacion) = (nombre, año);
            this.Pais = pais;
            this.Ciudad = ciudad;
        }

        public override string ToString()
        {                                                 //esto es igual a '\n' 
            return $"Nombre:{Nombre}, Tipo:{TipoEscuela} {System.Environment.NewLine} Pais:{Pais}, Ciudad:{Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Cursos...");

            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre} Limpia");
        }

    }
}