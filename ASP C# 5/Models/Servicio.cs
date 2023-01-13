using System.Collections.Generic;
using ServiplusEF.Enum;

namespace ServiplusEF.Models
{
    public class Servicio
    {
        public int ServicioId {get;set;}
        public string Descripcion {get;set;}
        public TipoMantenimiento TipoMantenimiento {get;set;}
        public decimal Precio {get;set;}
        public Estado Estado {get;set;}
        public virtual ICollection<DetalleMantenimiento> DetalleMantenimientos {get;set;}
    }
}