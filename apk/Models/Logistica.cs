using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace apk.Models
{
    public class Logistica
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID_L { get; set; }

        [MaxLength(30)]
        public string Nro_P { get; set; }

        public DateTime Fecha_I { get; set; }

        public DateTime Fecha_S { get; set; }

        [MaxLength(4)]
        public string Temperatura { get; set; }
    }
}
