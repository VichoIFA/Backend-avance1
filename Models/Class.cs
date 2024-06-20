using Microsoft.Extensions.ObjectPool;
using simulador.Models;
using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace simulador.Models
{
    public class Maquina
    {
        public int storage { get; set; }
        public int memory { get; set; }
        public int temperature { get; set; }
        public int state { get; set; }
        public int kwh { get; set; }
        public DateTime dateTime { get; set; }
        public string? estacion { get; set; }
    }
    public class RetornarDatos
    {
        public Maquina CreadorDatos(int seed, string nombre)
        {
            Random rnd = new Random(seed);
            DateTime dateTime = DateTime.Now;

            return new Maquina
            {
                storage = rnd.Next(80000, 1200000),
                memory = rnd.Next(18000, 100000),
                temperature = rnd.Next(55, 60),
                state = 1,
                kwh = rnd.Next(103, 105),
                dateTime = dateTime,
                estacion = nombre,
            };
        }
        public string DatosJson()
        {
            List<Maquina> DatosFinal = new List<Maquina>();
            for (int i = 0; i <= 10; i++)
            {
                var DatosMaquina1 = CreadorDatos(new Random().Next(), "maquina1");
                var DatosMaquina2 = CreadorDatos(new Random().Next(), "maquina2");
                var DatosMaquina3 = CreadorDatos(new Random().Next(), "maquina3");

                DatosFinal.AddRange([DatosMaquina1, DatosMaquina2, DatosMaquina3]);
            }
            return System.Text.Json.JsonSerializer.Serialize(DatosFinal);
        }
    }
}

namespace Funciones.Models
{
    public class funciones
    {
        RetornarDatos datos = new RetornarDatos();

        public string DatosMaquina(string buscar)
        {
            string DatosJson = datos.DatosJson();
            List<Maquina>? maquinas = JsonConvert.DeserializeObject<List<Maquina>>(DatosJson);
            List<Maquina> MaquinasSeleccionadas = new List<Maquina>();
            //Estas tres lineas son para rescatar los datos de la "base de datos" y crear un nuevo json donde guardar los datos filtrados

            foreach(var maquina in maquinas)
            {
                if (maquina.estacion == buscar)
                {
                    MaquinasSeleccionadas.Add(maquina);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(MaquinasSeleccionadas);
        }
    }
}