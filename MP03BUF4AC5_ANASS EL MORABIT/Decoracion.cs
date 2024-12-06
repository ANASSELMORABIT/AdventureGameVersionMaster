using System;
using System.Threading;

public static class DecoracionUtils
{
    // Método para mostrar texto con un efecto de escritura animada
    public static void MostrarConBordes(string titulo, string[] contenido)
    {
        string borde = new string('═', titulo.Length + 4);

        // Mostrar el título en rojo
        Console.ForegroundColor = ConsoleColor.Red;
        EscribirLinea($"╔{borde}╗");
        EscribirLinea($"║  {titulo}  ║");
        EscribirLinea($"╚{borde}╝");
        Console.ResetColor();

        // Mostrar el contenido en azul
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var linea in contenido)
        {
            EscribirLinea($"  > {linea}");
        }
        Console.ResetColor();
        Console.WriteLine();
    }

    // Método auxiliar para escribir texto letra por letra con un retraso
    public static void EscribirLinea(string texto)
    {

        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(10); // Ajusta el tiempo de retraso en milisegundos
        }
        Console.WriteLine();
    }

    // Método para mostrar un mensaje destacado (ej: Start Game, End Game)
    public static void MostrarMensajeEstilado(string mensaje)
    {
        string borde = new string('*', mensaje.Length + 6);

        Console.ForegroundColor = ConsoleColor.Green;
        EscribirLinea($"***** {borde} *****");
        Console.ForegroundColor = ConsoleColor.Magenta;
        EscribirLinea($"***   {mensaje.ToUpper()}   ***");
        Console.ForegroundColor = ConsoleColor.Green;
        EscribirLinea($"***** {borde} *****");
        Console.ResetColor();

        Console.WriteLine();
    }
}
