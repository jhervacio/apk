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

        public string Fecha_S { get; set; }

        [MaxLength(30)]
        public string Lugar_S { get; set; }

        public string Fecha_E { get; set; }

        [MaxLength(30)]
        public string Lugar_E { get; set; }
    }
}
