using System.Collections.Generic;
using ServiplusEF.Enum;

namespace ServiplusEF.Models
{
    public class DetalleMantenimiento
    {
        public int DetalleMantenimientoId {get;set;}
        public int MantenimientoId {get;set;}
        public int MecanicoId {get;set;}
        public int ServicioId {get;set;}
        public decimal Precio {get;set;}
        public Etapa Estado;
        public Mantenimiento Mantenimiento {get;set;}
        public virtual ICollection<DetalleRepuesto> DetalleRepuestos {get;set;}
        public virtual Servicio Servicio {get;set;}
        public virtual Mecanico Mecanico {get;set;}
    }
}