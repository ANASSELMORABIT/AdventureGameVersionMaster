using System.Collections.Generic;

public static class PersonajesEpeciales
{
    public static List<Jugador> Jugadores { get; private set; } = new List<Jugador>();

    static PersonajesEpeciales()
    {
        InicializarPersonajes();
    }

    private static void InicializarPersonajes() { 
        Jugadores.Add(new Mago("Draco",10));
        Jugadores.Add(new Arquero("Gandalf",10));
        Jugadores.Add(new Guerrero("Aragorn",10));
    }
}