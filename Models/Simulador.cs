using Datos.Models;
using DatabaseWrapper.Core;
using Newtonsoft.Json;
using Watson.ORM.Sqlite;
using System.Data.SqlTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace maquinas.Models
{
    public class Maquina
    {
        public DateTime dateTime { get; set; }
        public string? machine { get; set; }
        public int state { get; set; }
        public int storage { get; set; }
        public int memory { get; set; }
        public int processor { get; set; }
        public int temperature { get; set; }
        public int kwh { get; set; }
        
        
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
                dateTime = DateTime.Now,
                machine = obj.machine,
                state = obj.state,
                storage = obj.storage,
                memory = obj.memory,
                processor = obj.processor,
                temperature = obj.temperature,
                kwh = obj.kwh,
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

                maquina.dateTime = dateTime;
                maquina.machine = N_maquina;
                maquina.state = 1;
                maquina.storage = rnd.Next(80000, 1200000);
                maquina.memory = rnd.Next(18000, 100000);
                maquina.processor = rnd.Next(70, 98);
                maquina.temperature = rnd.Next(55, 60);
                maquina.kwh = rnd.Next(103, 105);

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
            return JsonConvert.SerializeObject(data.Where(item => (item.machine) == maquina));
        }
        public string TermperaturaMaquina(string maquina)
        {
            List<DatosMaquinas> data = datos.SelectMany<DatosMaquinas>();


            return JsonConvert.SerializeObject(data);
        }

    }
}