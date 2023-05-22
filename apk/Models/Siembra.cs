using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace apk.Models
{
    public class Siembra
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID_S { get; set; }

        public string Fecha_Siembra { get; set; }

        [MaxLength(30)]
        public string T_Semilla { get; set; }


        [MaxLength(30)]
        public string Rot_Tierra { get; set; }

        [MaxLength(30)]
        public string Nro_Lote { get; set; }


    }
}
