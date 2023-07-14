using NotasTeste.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasTeste.Models
{
    internal class TodasNotas
    {
        private NotasDatabase database = new NotasDatabase(); 
        public ObservableCollection<Nota> Notas { get; set; } = new ObservableCollection<Nota>();
        public async Task<ObservableCollection<Nota>> CarregaNotas()
        {
            var items = await database.GetItemsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Notas.Clear();
                foreach (var item in items) Notas.Add(item);
            });
            return Notas;
        }

    }
}
