namespace VistaPrincipal.Models
{
    public class Factura
    {
        public int Id { get; set; } 

        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}