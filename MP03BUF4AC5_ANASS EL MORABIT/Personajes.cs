public class Personajes
{
    public string nombre { get; set; }
    public int puntosVida { get; set; }
    public int nivel { get; set; }

    public bool esVivo { get; set; }

    public int puntosDeHabilidad { get; set; }

    public string descripcion { get; set; }



    public Personajes(string Nombre, int PuntosVida, int Nivel, bool EsVivo, int PuntosDeHabilidad, string Descripcion = "Descripción no especificada")
    {
        this.nombre = Nombre;
        this.puntosVida = PuntosVida;
        this.nivel = Nivel;
        this.esVivo = EsVivo;
        this.puntosDeHabilidad = PuntosDeHabilidad;
        this.descripcion = Descripcion;
    }



    public virtual int Atacar()
    { //Realiza una tirada de ataque (suma tirada de dos dados + modificadores).
        Random random = new Random();
        int tirada = random.Next(1, 7) + random.Next(1, 7); // Ambos dados son de 6 caras
        return tirada + (int)(puntosDeHabilidad * 0.1);
    }

    public virtual int RecibirDano(int puntos)
    {
        this.puntosVida -= puntos;
        if (this.puntosVida <= 0)
        {
            this.puntosVida = 0; // Evitar valores negativos
            this.esVivo = false;
        }
        return this.puntosVida;
    }

    public virtual void SubirNivel()
    { //Aumenta el nivel del personaje.
        this.nivel++;

    }

    public virtual bool EstaVivo()
    {  //Indica si el personaje esta vivo.
        if (this.puntosVida > 0)
        {
            return true;
        }
        return false;
    }
}