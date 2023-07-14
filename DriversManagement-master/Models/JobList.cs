using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DriversManagement.Models
{
   public class JobList
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [ForeignKey(typeof(ListaJobe))] public int ListaJobeID { get; set; }
        public int JobID { get; set; }
    }
}
