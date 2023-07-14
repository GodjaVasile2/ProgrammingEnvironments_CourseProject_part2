using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DriversManagement.Models
{
    public class ListaJobe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(1000), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(typeof(Driver))] 
        public int DriverID { get; set; }
    }
}
