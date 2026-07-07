namespace WatchlistApp_Proyect.Models;

public enum TipoContenido
{
  Serie,
  Pelicula
}

public class WatchlistItem
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Titulo { get; set; } = string.Empty;
  public string PortadaUrl { get; set; } = string.Empty;
  public TipoContenido Tipo { get; set; } = TipoContenido.Pelicula;
  public int? NumeroEpisodios { get; set; } 
  public bool Visto { get; set; } = false;
  public DateTime FechaAgregado { get; set; } = DateTime.Now;
}