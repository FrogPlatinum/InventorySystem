using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem.Repos
{
    public class MemoryItemRepo : IItemRepo
    {
        private readonly List<Item> _items = new List<Item>();
        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Delete(string id)
        {
            foreach(Item item in _items)
            {
                if(id == item.Id)
                {
                    _items.Remove(item);
                }
            }
        }

        public void Update(Item item)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Id == item.Id)
                {
                    _items[i] = item;
                    return;
                }
            }
        }

        public Item? GetById(string id)
        {
            foreach (Item item in _items)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }
    }
}
