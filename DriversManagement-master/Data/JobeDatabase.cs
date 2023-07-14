using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriversManagement.Models;

namespace DriversManagement.Data
{
    public class JobeDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public JobeDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaJobe>().Wait();
            _database.CreateTableAsync<Job>().Wait(); 
            _database.CreateTableAsync<JobList>().Wait();
            _database.CreateTableAsync<Driver>().Wait();
        }
        public Task<List<ListaJobe>> GetShopListsAsync() { return _database.Table<ListaJobe>().ToListAsync(); }
        public Task<ListaJobe> GetShopListAsync(int id) { return _database.Table<ListaJobe>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SaveShopListAsync(ListaJobe slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeleteShopListAsync(ListaJobe slist) 
        { return _database.DeleteAsync(slist);
        }
        public Task<int> SaveProductAsync(Job obiectiv) 
        {
            if (obiectiv.ID != 0) 
            { 
                return _database.UpdateAsync(obiectiv); 
            }
            else 
            {
                return _database.InsertAsync(obiectiv); 
            }
        }
        public Task<int> DeleteProductAsync(Job obiectiv) 
        {
            return _database.DeleteAsync(obiectiv); 
        }
        public Task<List<Job>> GetProductsAsync()
        { return _database.Table<Job>().ToListAsync(); }
        public Task<int> SaveListProductAsync(JobList listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Job>> GetListProductsAsync(int listaobiectiveid)
        {
            return _database.QueryAsync<Job>(
            "select O.ID, O.Description from Job O"
            + " inner join JobList OL" 
            + " on O.ID = OL.JobID where OL.ListaJobeID = ?", 
            
            listaobiectiveid);
        }
        public Task<List<Driver>> GetShopsAsync() 
        {
            return _database.Table<Driver>().ToListAsync(); 
        }
        public Task<int> SaveShopAsync(Driver apartament) 
        {
            if (apartament.ID != 0) { return _database.UpdateAsync(apartament); } else { return _database.InsertAsync(apartament); } }

        public Task<int> DeleteShopAsync(Driver apartament)
        {
            return _database.DeleteAsync(apartament);
        }
    }
}
