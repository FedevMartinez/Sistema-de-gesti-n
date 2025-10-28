public class DolarResponse
{
    public string Moneda { get; set; }
    public string Casa { get; set; }
    public string Nombre { get; set; }
    public decimal Compra { get; set; }
    public decimal Venta { get; set; }
    public DateTime FechaActualizacion { get; set; }
}

public class DolarData
{
    public decimal CompraOficial { get; set; }
    public decimal VentaOficial { get; set; }
    public decimal CompraBlue { get; set; }
    public decimal VentaBlue{ get; set; }
}