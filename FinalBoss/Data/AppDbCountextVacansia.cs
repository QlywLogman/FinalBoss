using FinalBoss.Models.Abstrac;
using FinalBoss.Models.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalBoss.Data
{
    public class AppDbCountextVacansia : Entity
    {
        public ObservableCollection<VacansiaClass> Items { get; set; }

        private string FILENAME { get; set; }

        public AppDbCountextVacansia()
        {
            FILENAME = "Vacansia.json";
            if (File.Exists(FILENAME))
            {
                var json = File.ReadAllText(FILENAME);
                Items = JsonSerializer.Deserialize<ObservableCollection<VacansiaClass>>(json)!;
            }
            else Items = new ObservableCollection<VacansiaClass>();
        }

        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(Items);
            File.WriteAllText(FILENAME, json);
        }

        public VacansiaClass? GetItem(string ItemId)
        {
            return Items.FirstOrDefault(p => p.Id == ItemId);
        }
        public void AddItem(VacansiaClass item) => Items.Add(item);
        public void RemoveItemt(VacansiaClass item) => Items.Remove(item);
        public void RemoveItem(string id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item is not null)
                Items.Remove(item);
        }
        public void UpdateItem(VacansiaClass item)
        {
            RemoveItem(item.Id);
            Items.Add(item);
        }
    }
}
