namespace ServiplusEF.Models
{
    public class Cliente : Persona
    {    
        public virtual ICollection<Vehiculo> Vehiculos {get;set;}
    }
}