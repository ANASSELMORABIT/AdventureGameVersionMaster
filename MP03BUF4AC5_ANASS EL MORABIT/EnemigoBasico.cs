public class EnemigoBasico : Enemigo
{
    public EnemigoBasico(string nombre) 
        : base(nombre, random.Next(5, 13), random.Next(0, 16),  true, 0)
    {
        // Enemigo básico usa la configuración base generada aleatoriamente
    }

    public override int Atacar()
    {
        return base.Atacar(); // Usa el ataque estándar del enemigo
    }

    public override int RecibirDano(int puntos)
    {
        return base.RecibirDano(puntos); // Recibe daño normalmente
    }




    public override bool OtorgarPuntoHabilidad()
    {
        return base.OtorgarPuntoHabilidad();
    }

    public override void ShowInfo()
    {
    string titulo = "🛡️ Basic Enemy Information 🛡️";
    string[] contenido = {
        $"🔹 Type: Basic Enemy",
        $"🧑‍🤝‍🧑 Name: {nombre}",
        $"💖 Health Points: {puntosVida}",
        $"🔢 Level: {nivel}",
        $"💀 Alive: {esVivo}",
        $"🏅 Skill Points: {puntosDeHabilidad}",
    };
    DecoracionUtils.MostrarConBordes(titulo, contenido);
    }

}
