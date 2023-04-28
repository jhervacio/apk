using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace apk.Models
{
    public class Cosecha
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID_C { get; set; }

        [MaxLength(30)]
        public DateTime Fecha_C { get; set; }

        [MaxLength(30)]
        public string Abono { get; set; }

        [MaxLength(30)]
        public string Dotacion { get; set; }

        [MaxLength(6)]
        public string Tamaño { get; set; }

        [MaxLength(10)]
        public string Madurez { get; set; }

    }
}
