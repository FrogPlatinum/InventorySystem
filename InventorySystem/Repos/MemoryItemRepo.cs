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

        //IdGenerator
        IdGenerator idGenerator = new IdGenerator();

        public MemoryItemRepo()
        {
            //Sample Book 1
            string book1Id = idGenerator.GenerateId("Bk");
            Book bookToAdd1 = new Book(book1Id,"Dune", Item.Condition.New, Item.NeedsApproval.No, Item.StorageStatus.Yes, "Frank Herbert", "1st", "Literature");
            _items.Add(bookToAdd1);

            //Sample Book 2
            string book2Id = idGenerator.GenerateId("Bk");
            Book bookToAdd2 = new Book(book2Id, "Three Body Problem", Item.Condition.Used, Item.NeedsApproval.No, Item.StorageStatus.Yes, "Cixin Liu", "2nd", "Literature");
            _items.Add(bookToAdd2);

            //Sample Book 3
            string book3Id = idGenerator.GenerateId("Bk");
            Book bookToAdd3 = new Book(book3Id, "Players Handbook", Item.Condition.Good, Item.NeedsApproval.Yes, Item.StorageStatus.Yes, "WoTC", "5th", "DnD");
            _items.Add(bookToAdd3);

            //Sample Boardgame 1
            string bg1Id = idGenerator.GenerateId("bg");
            BoardGame gameToAdd1 = new BoardGame(bg1Id, "Radlands", Item.Condition.Used, Item.NeedsApproval.No, Item.StorageStatus.Yes, "2nd", 2, 2);
            _items.Add(gameToAdd1);

            //Sample Boardgame 2
            string bg2Id = idGenerator.GenerateId("bg");
            BoardGame gameToAdd2 = new BoardGame(bg2Id, "Twilight Imperium", Item.Condition.Damaged, Item.NeedsApproval.Yes, Item.StorageStatus.No, "4th", 2, 8);
            _items.Add(gameToAdd2);

            //Sample LiveEquipment 1
            string le1Id = idGenerator.GenerateId("le");
            LiveEquipment leToAdd1 = new LiveEquipment(le1Id, "Plate Armor", Item.Condition.New, Item.NeedsApproval.Yes, Item.StorageStatus.Yes, LiveEquipment.TypeOfEquipment.Costume, "Cainhurst Vilebloods");
            _items.Add(leToAdd1);

            //Sample LiveEuipment 2
            string le2Id = idGenerator.GenerateId("le");
            LiveEquipment leToAdd2 = new LiveEquipment(le2Id, "Greatsword", Item.Condition.Used, Item.NeedsApproval.No, Item.StorageStatus.No, LiveEquipment.TypeOfEquipment.Weapon, "The Blood Beast");
            _items.Add(leToAdd2);

        }

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
