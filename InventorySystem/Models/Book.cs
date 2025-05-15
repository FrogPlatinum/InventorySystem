using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Book : Item
    {
        public string Author { get; set; }
        public string Edition { get; set; }
        public string System {  get; set; }
        public override ItemType Type
        {
            get { return ItemType.Book; }
        }

        public Book(string id, string name, Condition condition, NeedsApproval approval, StorageStatus storage) : base(id, name, condition, approval, storage)
        {
            
        }
    }
}
