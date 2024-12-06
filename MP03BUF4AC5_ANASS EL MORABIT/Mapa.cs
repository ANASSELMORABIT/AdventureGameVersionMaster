public class Mapa
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public int EnemyNumber { get; set; }
    

    public Mapa(string nombre, string descripcion, int Enemies)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.EnemyNumber = Enemies;
        
    }
    public virtual void AboutMapa()
    {
    string titulo = $"🌍 Map Information: {Nombre} 🌍"; 
    string[] contenido = { 
        $"🗺️ Name: {Nombre}",
        $"📜 Description: {Descripcion}",
        $" 👹 Enemies: {EnemyNumber} "
    };
    DecoracionUtils.MostrarConBordes(titulo, contenido);
    }



}