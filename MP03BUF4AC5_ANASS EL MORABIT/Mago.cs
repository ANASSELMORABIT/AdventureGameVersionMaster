public class Mago : Jugador
{
    // Atributos específicos para la clase Mago
    public int turnosDesdeRecuperacionVida { get; set; } = 0; // Contador para la habilidad de recuperación de vida

    // Constructor
    public Mago(string nombre, int puntosDeHabilidad) 
        : base(nombre, 8, 1, true, puntosDeHabilidad, "**Initial Life: 8 ❤️. Gains +4 attack points per roll 🎲. If an enemy is defeated, recovers 2 life points every three turns ♻️.**")
    {
        // Inicialización adicional específica del mago (si es necesario)
        this.Tipo = "Mago";
        this.puntosTotales = 0;
    }

    // Override del método Atacar para incluir el ataque adicional de +4
    public override int Atacar()
    {
        Random random = new Random();
        int tirada = random.Next(1, 7) + random.Next(1, 7); // Tirada de dos dados de 6 caras
        return tirada + 4 + (int)(puntosDeHabilidad * 0.1); // Suma ataque base, +4 adicional y bono por puntos de habilidad
    }

    // Override del método RecibirDano para reducir vida
    public override int RecibirDano(int puntos)
    {
        return base.RecibirDano(puntos); // Llamamos al método base para actualizar la vida
    }

    // Override del método SubirNivel para aumentar el nivel
    public override void SubirNivel()
    {
        base.SubirNivel(); // Llamamos al método base para subir nivel
    }


    public override void SubirPuntosDeHabilidad()
    {
        base.SubirPuntosDeHabilidad();
    }

    // Habilidad especial: Recuperación de vida cada tres turnos si el jugador derrota a un enemigo
    public void RecuperarVida()
    {
        if (turnosDesdeRecuperacionVida >= 3)
        {
            puntosVida += 2; // Recupera 2 puntos de vida
            ResetTurnosRecuperacionVida(); // Reinicia el contador de turnos
            DecoracionUtils.MostrarMensajeEstilado($"{nombre} has regained 2 health points.");
        }
    }

    // Incrementar el contador de turnos desde la última recuperación de vida
    public void IncrementarTurnosRecuperacionVida()
    {
        turnosDesdeRecuperacionVida++; // Incrementa el contador cada turno
    }

    // Resetea el contador de turnos de la habilidad especial
    public void ResetTurnosRecuperacionVida()
    {
        turnosDesdeRecuperacionVida = 0; // Reinicia el contador manualmente
    }

    // Mostrar información específica del Mago
   public override void ShowInfo()
    {
    string titulo = "🧙‍♂️ Mage Information 🧙‍♀️"; // Updated title for the Mage class
    string[] contenido = {
        $"⚔️ Type: Mage",
        $"🧑‍🦱 Name: {nombre}",
        $"💖 Health Points: {puntosVida}",
        $"🔢 Level: {nivel}",
        $"🏅 Skill Points: {puntosDeHabilidad}",
        $"⏳ Turns Since Last Skill: {turnosDesdeUltimaHabilidad}",
        $"❤️‍🩹 Turns Since Health Recovery: {turnosDesdeRecuperacionVida}",
        $"💥 Enemies Defeated: {enemigosDerrotados}",
        $"🏆 Total Points: {puntosTotales}",
        $"📜 Description: {descripcion}"
    };
    DecoracionUtils.MostrarConBordes(titulo, contenido);
    }

}
