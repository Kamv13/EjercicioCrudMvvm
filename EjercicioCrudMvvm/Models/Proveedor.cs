﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EjercicioCrudMvvm.Models
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Producto { get; set; }
        

    }
}
