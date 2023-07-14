

using NotasTeste.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasTeste.Models
{
    
    public class Nota
    {
        private NotasDatabase database = new NotasDatabase();

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public async Task<Nota> CarregaNota()
        {
            var items = await database.GetItemsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                
            });
            if(items.Count == 0)
            {
                return new Nota();
            } else
            {
                return items[0];
            }
        }
        public async Task<int> SaveNotaAsync(Nota nota)
        {
 
                return await database.SaveItemAsync(nota);
        }

        public async Task<int> DeleteNotaAsync(Nota nota)
        {

            return await database.DeleteItemAsync(nota);
        }
    }

   

}
