public class Guerrero : Jugador
{
    public int AtaqueAdicional { get; private set; } = 2; // +2 puntos en cada tirada de ataque.
    public int TurnosDesdeBloqueo { get; private set; } = 0; // Contador de turnos para la habilidad especial de bloqueo.

    // Constructor simplificado: inicializa solo con el nombre y los puntos de habilidad
    public Guerrero(string nombre, int puntosDeHabilidad)
        : base(nombre, 12, 1, true, puntosDeHabilidad, "**Initial Life: 12 ❤️. Blocks one attack every 3 turns 🛡️ and gains +2 attack points per roll 🎲.**")
    {
        this.Tipo = "Guerrero";
        this.puntosTotales = 0;
    }

    // Sobrescribir el método Atacar para añadir el AtaqueAdicional
    public override int Atacar()
    {
        Random random = new Random();
        int tirada = random.Next(1, 7) + random.Next(1, 7); // Tirada de dos dados
        return tirada + AtaqueAdicional + (int)(puntosDeHabilidad * 0.1); // Suma ataque base, ataque adicional y bono
    }

    // Método para bloquear un ataque enemigo
    public bool BloquearAtaque()
    {
        if (TurnosDesdeBloqueo >= 3) // Bloquea si han pasado 3 turnos
        {
            TurnosDesdeBloqueo = 0; // Resetea el contador de turnos
            DecoracionUtils.MostrarMensajeEstilado($"{nombre} bloqueó el ataque enemigo.");
            return true; // Ataque bloqueado
        }
        else
        {
            DecoracionUtils.MostrarMensajeEstilado($"El bloqueo no está disponible. Debes esperar {3 - TurnosDesdeBloqueo} turno(s).");
            return false; // Bloqueo no disponible
        }
    }

    // Incrementar los turnos desde el último bloqueo
    public void IncrementarTurnosDesdeBloqueo()
    {
        TurnosDesdeBloqueo++; // Incrementa los turnos de bloqueo
    }

    public override void SubirPuntosDeHabilidad()
    {
        base.SubirPuntosDeHabilidad();
    }


    public override void ResetTurnosDesdeUltimaHabilidad()
    {
        base.ResetTurnosDesdeUltimaHabilidad();
    }
    // Método para subir de nivel y mejorar sus atributos
    public override void SubirNivel()
    {
        base.SubirNivel(); // Incrementa el nivel llamando al método base
    }

    // Mostrar información específica del Guerrero
    public override void ShowInfo()
    {
        string titulo = "🛡️ Warrior Information 🛡️";
        string[] contenido = {
            $"⚔️ Type: {Tipo}",
            $"🧑‍🤝‍🧑 Name: {nombre}",
            $"💖 Health Points: {puntosVida}",
            $"🔢 Level: {nivel}",
            $"🏅 Skill Points: {puntosDeHabilidad}",
            $"⏳ Turns Since Last Skill: {turnosDesdeUltimaHabilidad}",
            $"🛡️ Turns Since Last Block: {TurnosDesdeBloqueo}",
            $"💥 Enemies Defeated: {enemigosDerrotados}",
            $"🏆 Total Points: {puntosTotales}",
            $"📜 Description: {descripcion}"
        };
        DecoracionUtils.MostrarConBordes(titulo, contenido);
    }
}
