namespace CoreEscuela.Util
{
    
    public static class Printer
    {

        public static void DibujarLinea(int tam = 10)
        {
            Console.WriteLine("".PadLeft(tam,'='));
        }

        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length +4;
            DibujarLinea(tamaño);
            Console.WriteLine($"| {titulo} |");
            DibujarLinea(tamaño);
        }


        public static void PresioneENTER()
        {
            WriteTitle("Presione ENTER");
        }
    }
}