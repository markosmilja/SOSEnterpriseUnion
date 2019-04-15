using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOSEnterpriseUnion.Models;

namespace SOSEnterpriseUnion.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gradiliste 1", Description="Opis gradilista." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gradiliste 2", Description="Opis gradilista." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gradiliste 3", Description="Opis gradilista." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gradiliste 4", Description="Opis gradilista." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gradiliste 5", Description="Opis gradilista." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gradiliste 6", Description="Opis gradilista." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}