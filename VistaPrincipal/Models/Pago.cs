using System.ComponentModel.DataAnnotations;

namespace VistaPrincipal.Models
{
    public class Pago
    {
        public int Id { get; set; } 

        public int FacturaId { get; set; } 
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
    }
}