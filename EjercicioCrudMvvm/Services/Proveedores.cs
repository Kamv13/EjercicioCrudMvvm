using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioCrudMvvm.Models;
using SQLite;

namespace EjercicioCrudMvvm.Services
{
    public class ProveedoresService
    {
        private readonly SQLiteConnection _connection;

        public ProveedoresService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedores.db3");

            _connection = new SQLiteConnection(dbPath);

            _connection.CreateTable<Proveedor>();
        
        }

        public List<Proveedor> GetAll() { 
            return _connection.Table<Proveedor>().ToList();
         }

        public int Insert(Proveedor proveedor) 
        { 
        return _connection.Insert(proveedor);
        }

        public int Update(Proveedor proveedor)
        { 
        return _connection.Update(proveedor);
        }

        public int Delete(Proveedor proveedor)
        { 
        return _connection.Delete(proveedor);
        }
    }
}
