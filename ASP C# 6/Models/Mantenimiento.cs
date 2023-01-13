using ServiplusEF.Enum;

namespace ServiplusEF.Models
{
    public class Mantenimiento
    {
        public int MantenimientoId {get;set;}
        public int VehiculoId {get;set;}
        public DateTime FechaIngreso {get;set;}
        public DateTime FechaSalida {get;set;}
        public Etapa Estado {get;set;}
        public virtual Vehiculo Vehiculo {get;set;}
        public virtual ICollection<DetalleMantenimiento> DetalleMantenimientos {get;set;}

    }
}