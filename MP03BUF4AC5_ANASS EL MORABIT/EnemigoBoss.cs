public class Boss : Enemigo
{
    public int Resistencia { get; private set; } = 5; // Resistencia inicial fija
    public int turnosDesdeUltimaRegeneracion { get; set; } = 0; // Contador para regeneración de vida
    public  int VidaInicial { get; set; } = 15; // Vida inicial fija del Boss
    public  int NivelInicial { get; set; } = 20; // Nivel fijo del Boss

    public Boss(string nombre)
    : base(nombre, 15, 20, true, 0)
{
    this.puntosVida = VidaInicial; // Asegura que use la vida inicial fija
    this.nivel = NivelInicial;     // Asegura que use el nivel inicial fijo
}


    // Habilidad especial: Doble ataque
    public override int Atacar()
    {
        int tirada1 = random.Next(1, 7) + random.Next(1, 7); // Primera tirada
        int tirada2 = random.Next(1, 7) + random.Next(1, 7); // Segunda tirada
        int ataqueTotal = tirada1 + tirada2 ; // Suma de ambas tiradas más ataque base
        return ataqueTotal;
    }

    // Override del método RecibirDano para incluir resistencia
    public override int RecibirDano(int puntos)
    {
        int danoReducido = Math.Max(puntos - Resistencia, 0); // Aplica resistencia al daño
        return base.RecibirDano(danoReducido);
    }

    // Habilidad especial: Regeneración de vida
    public void RegenerarVida()
    {
        if (turnosDesdeUltimaRegeneracion >= 3)
        {
            puntosVida += 2; // Recupera 2 puntos de vida
            turnosDesdeUltimaRegeneracion = 0; // Reinicia el contador de regeneración

            // Validar que la vida no exceda su máximo inicial
            if (puntosVida > VidaInicial)
            {
                puntosVida = VidaInicial;
            }
        }
    }

    // Incrementar el contador de turnos desde la última regeneración
    public void IncrementarTurnos()
    {
        turnosDesdeUltimaRegeneracion++;
    }

    // Información detallada del Boss
    public override void ShowInfo()
    {
    string titulo = "👹 Boss Enemy Information 👹";
    string[] contenido = {
        $"🔹 Type: Boss Enemy",
        $"🧑‍🤝‍🧑 Name: {nombre}",
        $"💖 Health Points: {puntosVida}",
        $"🔢 Level: {nivel}",
        $"💀 Alive: {esVivo}",
        $"🏅 Skill Points: {puntosDeHabilidad}",
        $"🛡️ Resistance: {Resistencia}",
        $"⏳ Turns Since Last Regeneration: {turnosDesdeUltimaRegeneracion}"
    };
    DecoracionUtils.MostrarConBordes(titulo, contenido);
    }

}
