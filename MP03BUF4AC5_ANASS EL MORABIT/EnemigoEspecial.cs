public class EnemigoEspecial : Enemigo
{
    public int resistencia { get; private set; } // Resistencia inicial aleatoria
    public int turnos { get; private set; } = 0; // Contador de turnos para disminuir resistencia

    public EnemigoEspecial(string nombre) : base(nombre, random.Next(5, 13), random.Next(0, 16), true, 0)
    {
        // EnemigoEspecial usa la configuración base generada aleatoriamente,nivel,ataqueBase,esVivo,puntosDeHabilidad)
        this.resistencia = GenerarResistencia();

    }


    public int GenerarResistencia()
    {
        Random random = new Random();
        int resistencia = random.Next(0, 6);
        return resistencia;

    }
    public override int RecibirDano(int puntos)
    {
        // Reduce el daño recibido según la resistencia
        int danoReducido = Math.Max(puntos - resistencia, 0); // Asegura que el daño no sea negativo
        int vidaRestante = base.RecibirDano(danoReducido);

        // Disminuye la resistencia progresivamente cada turno
        if (resistencia > 0)
            resistencia--;

        return vidaRestante;
    }

    public void IncrementarTurnos()
    {
        turnos++;
    }



    public override bool OtorgarPuntoHabilidad()
    {
        return base.OtorgarPuntoHabilidad();
    }
    public override void ShowInfo()
    {
        string titulo = "🌟 Enemy Special Information 🌟";
        string[] contenido = {
        $"🔹 Type: Special Enemy",
        $"🔹 Name: {nombre}",
        $"💖 Health Points: {puntosVida}",
        $"🔢 Level: {nivel}",
        $"💀 Is Alive: {esVivo}",
        $"🏅 Skill Points: {puntosDeHabilidad}",
        $"🛡️ Resistance: {resistencia}",
    };
        DecoracionUtils.MostrarConBordes(titulo, contenido);
    }

}
