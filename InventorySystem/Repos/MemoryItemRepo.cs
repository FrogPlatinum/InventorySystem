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
        //Memory list for items
        private readonly List<Item> _items = new List<Item>();

        //Add item to list
        public void Add(Item item)
        {
            _items.Add(item);
        }

        //Remove item from list
        public void Delete(Item item)
        {
            _items.Remove(item);
        }

        //Edit existing item
        public void Update(Item editItem)
        {
            foreach(Item item in _items)
            {
                if(item.Id == editItem.Id)
                {
                    //Generic properties
                    item.Name = editItem.Name;
                    item.ItemCondition = editItem.ItemCondition;
                    item.ApprovalStatus = editItem.ApprovalStatus;
                    item.InStorage = editItem.InStorage;

                    //Book specific
                    if(item is Book book && editItem is Book editBook)
                    {
                        book.Author = editBook.Author;
                        book.Edition = editBook.Edition;
                        book.System = editBook.System;
                    }
                    //Board Game specific
                    else if(item is BoardGame game && editItem is BoardGame editGame)
                    {
                        game.Edition = editGame.Edition;
                        game.MinPlayer = editGame.MinPlayer;
                        game.MaxPlayer = editGame.MaxPlayer;
                    }
                    //Live Equipment specific
                    else if(item is LiveEquipment equipment && editItem is LiveEquipment editEquipment)
                    {
                        equipment.EquipmentType = editEquipment.EquipmentType;
                        equipment.Owner = editEquipment.Owner;
                    }
                    return;
                }
            }
            throw new Exception("Item not found");
        }

        public Item GetById(string id)
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

        public List<Loan> GetLoanHistory(Item item)
        {
            return item.Loans;
        }
    }
}
