public class Jugador : Personajes
{
    public int turnosDesdeUltimaHabilidad { get; set; } = 0; // Para gestionar habilidades especiales (como ataques dobles, bloqueos, etc.).
    public int enemigosDerrotados { get; set; } = 0; // Número de enemigos derrotados consecutivamente (usado para ganar puntos de habilidad).
    public string Tipo { get; set; }
    
    public int puntosTotales { get; set; } = 0; // Puntos totales acumulados

    public Jugador(string nombre, int puntosVida, int nivel, bool esVivo, int puntosDeHabilidad, string descripcion)
        : base(nombre, puntosVida, nivel, esVivo, puntosDeHabilidad, descripcion)
    {
        this.Tipo = "Normal";
    }

    public override int Atacar()
    {
        Random random = new Random();
        int tirada = random.Next(1, 7) + random.Next(1, 7);
        return tirada + (int)(puntosDeHabilidad * 0.1);
    }

    public override int RecibirDano(int puntos)
    {
        return base.RecibirDano(puntos);
    }

    public override void SubirNivel()
    {
        base.SubirNivel();
    }

    public override bool EstaVivo()
    {
        return base.EstaVivo();
    }

    public virtual void SubirPuntosDeHabilidad()
    {
        enemigosDerrotados += 1;
        if (enemigosDerrotados % 2 == 0)
        {  //(aumentan al derrotar dos enemigos consecutivos)
            puntosDeHabilidad += 1;
        }
        SubirNivel(); // Por cada enemigo derrotado, el jugador sube 1 nivel

        // Asignar puntos totales al derrotar un enemigo
        puntosTotales += 100;  // Se le asignan 100 puntos por cada enemigo derrotado
    }

    // Manejo de turnos para habilidades especiales
    public void IncrementarTurnosDesdeUltimaHabilidad()
    {
        turnosDesdeUltimaHabilidad++;
    }

    public virtual void ResetTurnosDesdeUltimaHabilidad()
    {
        turnosDesdeUltimaHabilidad = 0;
    }

    public virtual void ShowInfo()
    {
        string titulo = "🎮 Player Information 🎮";
        string[] contenido = {
            $"👤 Type: {Tipo}",
            $"🧑‍🤝‍🧑 Name: {nombre}",
            $"💖 Health Points: {puntosVida}",
            $"🔢 Level: {nivel}",
            $"🏅 Skill Points: {puntosDeHabilidad}",
            $"⏳ Turns Since Last Skill: {turnosDesdeUltimaHabilidad}",
            $"💥 Enemies Defeated: {enemigosDerrotados}",
            $"🏆 Total Points: {puntosTotales}",  // Mostrar los puntos totales aquí
            $"📜 Description: {descripcion} (Normal)"
        };
        DecoracionUtils.MostrarConBordes(titulo, contenido);
    }
}
