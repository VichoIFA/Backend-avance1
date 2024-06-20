using Microsoft.AspNetCore.Mvc;
using maquinas.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            var sim = new Simulador();
            return sim.ObtenerDatos();
        }
        [HttpPost]
        public String Create()
        {
            Simulador sim = new Simulador();
            return sim.CreadorDatos();
        }

        [HttpGet("{maquina}")]
        public String Get(string maquina)
        {
            Simulador sim = new Simulador();
            return sim.DatosMaquina(maquina);
        }


    }
}
