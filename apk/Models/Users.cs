using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace apk.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID { get; set; }

        [MaxLength(30)]
        public string Correo { get; set; }

        [MaxLength(30)]
        public string Nombre{ get; set; }

        [MaxLength(30)]
        public string Apellido { get; set; }

        [MaxLength(30)]
        public string Telefono { get; set; }

        [MaxLength(16)]
        public string Contraseña { get; set; }


       

    }
}
