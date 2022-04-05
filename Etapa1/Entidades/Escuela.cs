using CoreEscuela.Entidades;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {

        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        string nombre;

        public string Nombre
        {
            get{return nombre;}
            set{nombre = value;}
        }

        public int AñoDeCreacion{get;set;}

        public string Pais{get;set;}
        public string Ciudad { get; set; }
        
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
    }
}