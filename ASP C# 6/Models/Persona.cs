using ServiplusEF.Enum;

namespace ServiplusEF.Models
{
    public abstract class Persona
    {
        public int Id {get;set;}
        public string PrimerNombre {get;set;}
        public string? SegundoNombre{get;set;}
        public string PrimerApellido {get;set;}
        public string? SegundoApellido {get;set;}
        public string? Telefono {get;set;}
        public string Direccion {get;set;}
        public string Correo {get;set;}
        public Estado? Estado {get;set;}
    }
}