using Datos.Models;
using DatabaseWrapper.Core;
using Newtonsoft.Json;
using Watson.ORM.Sqlite;
using System.Data.SqlTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace maquinas.Models
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
    public class Simulador
    {
        /// 
        private WatsonORM datos { get; set; }

        public Simulador()
        {
            DatabaseSettings settings = new DatabaseSettings("./maquina.db");
            this.datos = new WatsonORM(settings);
            this.datos.InitializeDatabase();
            this.datos.InitializeTable(typeof(DatosMaquinas));
        }
        private void Insertar(Maquina obj)
        {
            DatosMaquinas entidad = new DatosMaquinas
            {
                storage = obj.storage,
                memory = obj.memory,
                temperature = obj.temperature,
                state = obj.state,
                kwh = obj.kwh,
                dateTime = DateTime.Now,
                estacion = obj.estacion,

            };
            DatosMaquinas inserted = this.datos.Insert<DatosMaquinas>(entidad);
        }

        ///
        public string CreadorDatos()
        {
            List<Maquina> lista = new List<Maquina>();
            Random rnd = new Random();
            DateTime dateTime = DateTime.Now;

            string[] Maquinas = ["maquina1", "maquina2", "maquina3"];
                
            foreach (string N_maquina in Maquinas)
            {
                var maquina = new Maquina();

                maquina.storage = rnd.Next(80000, 1200000);
                maquina.memory = rnd.Next(18000, 100000);
                maquina.temperature = rnd.Next(55, 60);
                maquina.state = 1;
                maquina.kwh = rnd.Next(103, 105);
                maquina.dateTime = dateTime;
                maquina.estacion = N_maquina;

                lista.Add(maquina);
                this.Insertar(maquina);
            }
            return JsonConvert.SerializeObject(lista);
        }
        public string ObtenerDatos()
        {
            List<DatosMaquinas> data = datos.SelectMany<DatosMaquinas>();
            return JsonConvert.SerializeObject(data);
        }
        public string DatosMaquina(string maquina)
        {
            List<DatosMaquinas> data = datos.SelectMany<DatosMaquinas>();
            return JsonConvert.SerializeObject(data.Where(item => (item.estacion) == maquina));
        }


    }
}