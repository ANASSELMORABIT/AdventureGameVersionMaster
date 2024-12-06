public class Arquero : Jugador
{
    // Atributos específicos para la clase Arquero
    public int turnosDesdeAtaqueDoble { get; set; } = 0; // Contador para el ataque doble

    // Constructor reducido: inicializa el Arquero solo con nombre y puntos de habilidad
    public Arquero(string nombre, int puntosDeHabilidad)
        : base(nombre, 10, 1, true, puntosDeHabilidad, "**Initial Life: 10 ❤️. Gains +3 attack points per roll 🎲. Can perform a double attack (two consecutive rolls) once every three turns ⚔️.**")
    {
        this.Tipo = "Arquero";
        this.puntosTotales = 0;
    }

    // Override del método Atacar para incluir el ataque adicional de +3
    public override int Atacar()
    {
        Random random = new Random();
        int tirada = random.Next(1, 7) + random.Next(1, 7); // Tirada de dos dados de 6 caras
        return tirada + 3 + (int)(puntosDeHabilidad * 0.1); // Suma ataque base, +3 adicional y bono por puntos de habilidad
    }

    public override void SubirPuntosDeHabilidad()
    {
        base.SubirPuntosDeHabilidad();
    }

    // Método para realizar un ataque doble (dos tiradas consecutivas) si es posible
    public int AtacarDoble()
    {
        if (turnosDesdeAtaqueDoble >= 3)
        {
            ResetTurnosDesdeAtaqueDoble(); // Resetea el contador de turnos tras realizar el ataque doble
            Random random = new Random();
            int tirada1 = random.Next(1, 7) + random.Next(1, 7); // Primera tirada de ataque
            int tirada2 = random.Next(1, 7) + random.Next(1, 7); // Segunda tirada de ataque
            int ataqueDoble = tirada1 + tirada2 + 3 + (int)(puntosDeHabilidad * 0.1); // Se suman las dos tiradas + bonus
            DecoracionUtils.MostrarMensajeEstilado($"{nombre} performed a double attack, dealing {ataqueDoble} points of damage.");
            return ataqueDoble;
        }
        else
        {
            DecoracionUtils.MostrarMensajeEstilado($"⚠️ Double attack is not available. You need to wait {3 - turnosDesdeAtaqueDoble} more turn(s). ⏳");
            return 0; // Si no se puede hacer el ataque doble, retorna 0
        }
    }

    public override void SubirNivel()
    {
        base.SubirNivel();
    }
    // Incrementar el contador de turnos desde el último ataque doble
    public void IncrementarTurnosDesdeAtaqueDoble()
    {
        turnosDesdeAtaqueDoble++; // Incrementa el contador de turnos cada vez que pase un turno
    }

    // Resetea el contador de turnos del ataque doble
    public void ResetTurnosDesdeAtaqueDoble()
    {
        turnosDesdeAtaqueDoble = 0; // Reinicia el contador manualmente
    }

    // Método para mostrar información específica del Arquero
    public override void ShowInfo()
    {
        string titulo = "🏹 Archer Information 🏹";
        string[] contenido = {
        $"🔹 Type: {Tipo}",
        $"🧑‍🤝‍🧑 Name: {nombre}",
        $"💖 Health Points: {puntosVida}",
        $"🔢 Level: {nivel}",
        $"🏅 Skill Points: {puntosDeHabilidad}",
        $"⚡ Turns Since Double Attack: {turnosDesdeAtaqueDoble}",
        $"🏆 Enemies Defeated: {enemigosDerrotados}",
        $"🏆 Total Points: {puntosTotales}",
        $"📜 Description: {descripcion}"
    };
        DecoracionUtils.MostrarConBordes(titulo, contenido);
    }

}
