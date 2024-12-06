public class Enemigo : Personajes
{
    protected static Random random = new Random();
    
    

    public Enemigo(string nombre, int vida, int nivel,bool esVivo, int puntosDeHabilidad) 
        : base(nombre, random.Next(5, 13), random.Next(0, 16), true, 0)     
    {    /* Enemigo no tiene un ataque base fijo pues pongo 0*/

        
        // Vida, nivel y ataque base son generados aleatoriamente
    }

    // Método para calcular el ataque del enemigo mediante tirada aleatoria
    public override int Atacar()
    {
        int tirada = random.Next(1, 7) + random.Next(1, 7); // Tirada de dos dados de 6 caras
        int ataqueTotal = tirada ; // Se suma el ataque base al resultado de los dados
        return ataqueTotal;
    }

    // Método para otorgar un punto de habilidad al jugador con probabilidad del 50%
    public virtual bool OtorgarPuntoHabilidad()
    {
        return random.Next(0, 2) == 1; // 50% de probabilidad de otorgar un punto de habilidad
    }

    // Método para gestionar la recepción de daño
    public override int RecibirDano(int puntos)
    {
        this.puntosVida -= puntos;
        if (this.puntosVida <= 0)
        {
            this.puntosVida = 0; // Asegurarse de no tener valores negativos
            this.esVivo = false; // El enemigo muere si los puntos de vida llegan a 0
        }
        return this.puntosVida;
    }



public virtual void ShowInfo()
{
    string titulo = "👹 Enemy Information 👹";
    string[] contenido = {
        $"🔹 Type: Enemy",
        $"🧑‍🤝‍🧑 Name: {nombre}",
        $"💖 Health Points: {puntosVida}",
        $"🔢 Level: {nivel}",
        $"💀 Alive: {esVivo}",
        $"🏅 Skill Points: {puntosDeHabilidad}",
    };
    DecoracionUtils.MostrarConBordes(titulo, contenido);
}

    


}
