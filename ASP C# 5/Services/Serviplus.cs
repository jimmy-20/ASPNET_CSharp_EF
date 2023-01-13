using System.Collections.Generic;
using ServiplusEF.Context;
using ServiplusEF.Models;

namespace ASP_C__5.Services
{
    public class Serviplus : IServiplus
    {
        private ServiplusContext DBContext;

        public Serviplus (ServiplusContext context){
            DBContext = context;
            DBContext.Database.EnsureCreated();
        }

        public IEnumerable<Cliente> GetCliente()
        {
            return DBContext.Cliente;
        }
    }

    public interface IServiplus{
        IEnumerable<Cliente> GetCliente();
    }
}