using System.Collections.Generic;

namespace ServiplusEF.Models
{
    public class Vehiculo
    {
        public int VehiculoId {get;set;}
        public int ClienteId {get;set;}
        public string Marca {get;set;}
        public string Modelo {get;set;}
        public int Año {get;set;}
        public virtual Cliente Cliente {get;set;}
        public virtual ICollection<Mantenimiento> Mantenimientos {get;set;}
    }
}