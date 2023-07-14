using NotasTeste.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasTeste.Data
{
    internal class NotasDatabase
    {
        SQLiteAsyncConnection Database;
        public NotasDatabase()
        {

        }
        async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constants.DatabasePath,Constants.Flags);
            var result = await Database.CreateTableAsync<Nota>();
        }

        public async Task<List<Nota>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Nota>().ToListAsync();
        }
        public async Task<Nota> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Nota>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public async Task<int> SaveItemAsync(Nota item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }
        public async Task<int> DeleteItemAsync(Nota item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
    
}

