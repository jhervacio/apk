using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace apk.Models
{
    public class Almacenado
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID_A { get; set; }

        [MaxLength(30)]
        public string Nro_P { get; set; }

        public string Fecha_I { get; set; }

        public string Fecha_S { get; set; }

        [MaxLength(4)]
        public string Temperatura { get; set; }


    }
}
