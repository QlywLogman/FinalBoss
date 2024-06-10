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
    public class AppDbCountextCv : Entity
    {
        public ObservableCollection<CVclass> Items { get; set; } = new();

        private string FILENAME { get; set; }

        public AppDbCountextCv()
        {
            FILENAME = "Vacansia.json";
            if (File.Exists(FILENAME))
            {
                var json = File.ReadAllText(FILENAME);
                Items = JsonSerializer.Deserialize<ObservableCollection<CVclass>>(json)!;
            }
            else Items = new ObservableCollection<CVclass>();
        }

        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(Items);
            File.WriteAllText(FILENAME, json);
        }

        public CVclass? GetItem(string ItemId)
        {
            return Items.FirstOrDefault(p => p.Id == ItemId);
        }
        public void AddItem(CVclass item) => Items.Add(item);
        public void RemoveItemt(CVclass item) => Items.Remove(item);
        public void RemoveItem(string id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item is not null)
                Items.Remove(item);
        }
        public void UpdateItem(CVclass item)
        {
            RemoveItem(item.Id);
            Items.Add(item);
        }

    }
}
