using System;
using CoreEscuela.Entidades;
using CoreEscuela.Escuela;

namespace Etapa1
{
    class Program
    {

        static void Main(string[] args)
        {
            var escuela = new Escuela("UNTDF",2013);
            escuela.Pais = "Argentina";
            escuela.Ciudad = "Ushuaia";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);

        }
    }

}