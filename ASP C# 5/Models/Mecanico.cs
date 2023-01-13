using System.Collections.Generic;
using ServiplusEF.Enum;

namespace ServiplusEF.Models
{
    public class Mecanico : Persona
    {
        public Especialidad Especialidad {get;set;}
        public decimal Salario {get;set;}
        public virtual ICollection<DetalleMantenimiento> DetalleMantenimientos {get;set;}
    }
}