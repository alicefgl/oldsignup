using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Prenotazione
{
    [Key]
    public string? Email { get; set; } required
    public string? Nome { get; set; } required
    public string? Cognome { get; set; } required
    public DateTime DataDiNascita { get; set; } required
    public Sesso _Sesso { get; set; } required
    public Ruolo _Ruolo { get; set; }
    
    public enum Sesso{
        Maschio,
        Femmina,
        Non_specificato,
    }
        public enum Ruolo{
        Docente,
        Studente,
        Genitore,
    }
}