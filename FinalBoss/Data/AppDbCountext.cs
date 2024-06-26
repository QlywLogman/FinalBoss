﻿using FinalBoss.Models.Abstrac;
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
    public class AppDbContext : Entity
    {
        public ObservableCollection<RegisterClass> Items { get; set; } = new();

        private string FILENAME { get; set; }

        public AppDbContext()
        {
            FILENAME = "Register.json";
            if (File.Exists(FILENAME))
            {
                var json = File.ReadAllText(FILENAME);
                Items = JsonSerializer.Deserialize<ObservableCollection<RegisterClass>>(json)!;
            }
            else Items = new ObservableCollection<RegisterClass>();
        }

        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(Items);
            File.WriteAllText(FILENAME, json);
        }

        public RegisterClass? GetItem(string ItemId)
        {
            return Items.FirstOrDefault(p => p.Id == ItemId);
        }
        public void AddItem(RegisterClass item) => Items.Add(item);
        public void RemoveItemt(RegisterClass item) => Items.Remove(item);
        public void RemoveItem(string id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item is not null)
                Items.Remove(item);
        }
        public void UpdateItem(RegisterClass item)
        {
            RemoveItem(item.Id);
            Items.Add(item);
        }
    }
}
