using System;
using System.Diagnostics;
using System.Threading;
using MyGame;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int opcion;

        Logo.Mostrar();

        do
        {
            // Mostrar el menú y obtener la selección del jugador
            opcion = ReglasJuegoMenu.GameMenuSelection();

            switch (opcion)
            {
                case 1:
                    IniciarJuego();
                    break;

                case 2:
                    ReglasJuegoMenu.AboutGame();
                    break;

                case 3:
                    showInfoMapas();
                    break;

                case 4:
                    showInfoPersonajesEspeciales();
                    break;

                case 5:
                    DecoracionUtils.MostrarMensajeEstilado("Exiting the game. See you next time! 👋");
                    break;

                default:
                    DecoracionUtils.MostrarMensajeEstilado("Invalid option. Please try again.");
                    break;
            }

            // Pausa para que el usuario pueda leer la salida antes de que el menú se muestre nuevamente
            if (opcion != 5)
            {
                DecoracionUtils.MostrarMensajeEstilado("\nPress any key to return to the menu...");
                Console.ReadKey();
            }

        } while (opcion != 5); // Salir del bucle si el usuario selecciona la opción 5
    }

    // Funciones del juego

    static void showInfoPersonajesEspeciales()
    {
        // Este método muestra la información de los personajes especiales del juego (Mago, Arquero y Guerrero)
        DecoracionUtils.MostrarMensajeEstilado("Special Characters of the Game:");
        for (int i = 0; i < 3; i++)
        {
            PersonajesEpeciales.Jugadores[i].ShowInfo();
        }
    }

    static void showInfoMapas()
    {
        // Este método muestra la información de los mapas del juego
        DecoracionUtils.MostrarMensajeEstilado("Maps of the Game: 🗺️");
        for (int i = 0; i < 3; i++)
        {
            RegistroMapas.Mapas[i].AboutMapa();
        }
    }









    public static void IniciarJuego()
    {
        List<string> frasesMotivadoras = new List<string>
    {
        "⚔️ Heroes aren't born, they are forged in the heat of battle.",
        "🌟 The path of a warrior is paved with challenges and triumphs.",
        "🛡️ Stand firm, for the storm only makes you stronger.",
        "🔥 Your courage ignites the flames of hope in the darkest of times.",
        "⚡ Each battle won is a step closer to immortality.",
        "🏹 Precision and patience are the marks of a true archer.",
        "🔮 Magic flows through those who dare to dream and believe.",
        "💪 Strength is not just physical; it's the will to keep fighting.",
        "🧠 Strategy and wisdom conquer brute force every time.",
        "🚶 The journey of a thousand miles begins with a single step."
    };
        // Guardar el tiempo de inicio
        DateTime tiempoInicio = DateTime.Now;

        // Crear al jugador
        Jugador Player = new Jugador("Player", 10, 1, true, 0, "Player");

        // Empezar el juego desde el Primer Mapa y verificar si el jugador sigue adelante
        if (!Play.JugarPerimaraMapa(ref Player, frasesMotivadoras))
        {
            
            MostrarTiempoTranscurrido(tiempoInicio);
            // Si el jugador pierde, finalizar el juego
            return;
        }

        // Mostrar el tiempo transcurrido después de terminar el primer mapa
        MostrarTiempoTranscurrido(tiempoInicio);

        // Continuar con el Segundo Mapa si el jugador ha superado el primero
        if (!Play.JugarSegundoMapa(
           ref Player, frasesMotivadoras))
        {
            
            MostrarTiempoTranscurrido(tiempoInicio);
            // Si el jugador pierde, finalizar el juego
            return;
        }

        // Mostrar el tiempo transcurrido después de terminar el segundo mapa
        MostrarTiempoTranscurrido(tiempoInicio);

        // Finalmente, jugar el Tercer Mapa si el jugador ha superado los dos anteriores
        if (!Play.JugarTercerMapa(ref Player, frasesMotivadoras))
        {
            MostrarTiempoTranscurrido(tiempoInicio);
            // Si el jugador pierde en el tercer mapa, finalizar el juego
            return;
        }

        // Mostrar el tiempo transcurrido después de terminar el tercer mapa
        MostrarTiempoTranscurrido(tiempoInicio);

        // Si el jugador supera todos los mapas, mostrar un mensaje de victoria
        DecoracionUtils.MostrarMensajeEstilado("🎉 Congratulations! You've completed your adventure and proven your worth!");

    }

    public static void MostrarTiempoTranscurrido(DateTime tiempoInicio)
    {
        // Calcular el tiempo transcurrido
        TimeSpan tiempoTranscurrido = DateTime.Now - tiempoInicio;
        string tiempoFormateado = tiempoTranscurrido.ToString(@"hh\:mm");
        // Mostrar el tiempo transcurrido
        DecoracionUtils.MostrarMensajeEstilado($"Time elapsed so far: {tiempoFormateado} ⏳");

    }









}