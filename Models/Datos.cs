using ExpressionTree;
using DatabaseWrapper.Core;
using Watson.ORM;
using Watson.ORM.Core;

namespace Datos.Models
{
    [Table("datos")]
    public class DatosMaquinas
    {
        [Column("id", true, DataTypes.Int, false)]
        public int Id { get; set; }

        [Column("Storage", false, DataTypes.Int, false)]
        public int? storage { get; set; }
        [Column("Memory", false, DataTypes.Int, false)]
        public int? memory { get; set; }
        [Column("Temperature", false, DataTypes.Int, false)]
        public int? temperature { get; set; }
        [Column("State", false, DataTypes.Int, false)]
        public int? state { get; set; }
        [Column("kwh", false, DataTypes.Int, false)]
        public int? kwh { get; set; }
        [Column("dateTime", false, DataTypes.DateTime, false)]
        public DateTime? dateTime { get; set; }
        [Column("estacion", false, DataTypes.Nvarchar, 8,false)]
        public string? estacion { get; set; }
    }
}
