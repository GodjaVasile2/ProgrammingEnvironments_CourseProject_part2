using DriversManagement.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversManagement
{
    public class Driver
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeDriver { get; set; }
        public string Adress { get; set; }
        public string DetaliiDriver { get { return NumeDriver + " " + Adress; } }
        [OneToMany]
        public List<ListaJobe> ListaJobe { get; set; }
    }
}
