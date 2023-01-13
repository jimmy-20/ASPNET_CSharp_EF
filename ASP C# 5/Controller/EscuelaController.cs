using ASP_C__5.Services;
using Microsoft.AspNetCore.Mvc;
using ServiplusEF.Models;
using System.Collections.Generic;
using System.Linq;
namespace ASP_C__5.Controller
{
    public class EscuelaController : ControllerBase
    {
        private IServiplus Services;
        
        public EscuelaController(IServiplus s){
            Services = s;
        }

        [HttpGet("/Serviplus")]
        public IEnumerable<Cliente> Index(){
            return Services.GetCliente().ToList();
        }
    }
}