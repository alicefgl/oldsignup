using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

public class Prodotto
{
    [Key]
    public NomeP? _NomeP { get; set; } required
    public int? quantita { get; set; } 
    
    public enum NomeP{
        Raspberry_Pi_Pico,
        Raspberry_Pi_Pico_W,
        Raspberry_RP2040_Zero,
        MacroPad_RP2040
    }

}