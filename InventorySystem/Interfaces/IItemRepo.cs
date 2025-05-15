using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Models;

namespace InventorySystem.Interfaces
{
    public interface IItemRepo
    {
        public void Add(Item item);
        public IEnumerable<Item> GetAll();
        public Item GetById(string id);
        public void Update(Item item);
        public void Delete(string id);
    }
}
