using System.Collections.Generic;
using ServiplusEF.Enum;

namespace ServiplusEF.Models
{
    public class Repuesto
    {
        public int RepuestoId {get;set;}
        public string Descripcion {get;set;}
        public string Marca {get;set;}
        public string Modelo {get;set;}
        public decimal Precio {get;set;}
        public int Cantidad {get;set;}
        public Estado Estado {get;set;}
        public virtual ICollection<DetalleRepuesto> DetalleRepuestos {get;set;}
    }
}