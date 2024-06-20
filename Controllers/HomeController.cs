using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using simulador.Models;
using Funciones.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var Imprimir = new RetornarDatos();
            return Imprimir.DatosJson();
        }
        [HttpGet("{maquina}")]
        public String Get(string maquina)
        {
            var sim = new funciones();
            return sim.DatosMaquina(maquina);
        }

        [HttpPost]
        public String Create()
        {
            var sim = new RetornarDatos();
            return sim.DatosJson();
        }
    }
}
