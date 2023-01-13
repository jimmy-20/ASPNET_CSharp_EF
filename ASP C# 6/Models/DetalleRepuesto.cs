namespace ServiplusEF.Models
{
    public class DetalleRepuesto
    {
        public int DetalleMantenimientoId {get;set;}
        public int RepuestoId {get;set;}
        public decimal Precio {get;set;}
        public int Cantidad {get;set;}
        public virtual DetalleMantenimiento DetalleMantenimiento {get;set;}
        public virtual Repuesto Repuesto {get;set;}
    }
}