using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public abstract class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public enum Condition
        {
            New,
            Good,
            Used,
            Damaged
        }

        public enum NeedsApproval
        {
            Yes,
            No
        }

        public enum StorageStatus
        {
            Yes,
            No
        }

        public enum ItemType
        {
            Book,
            BoardGame,
            LiveEquipment
        }
        public Condition ItemCondition { get; set; }
        public NeedsApproval ApprovalStatus { get; set; }
        public StorageStatus InStorage {  get; set; }

        public List<Loan>? Loans { get; set; }
        public abstract ItemType Type { get; }

        public Item(string id, string name, Condition itemCondition, NeedsApproval needsApproval, StorageStatus inStorage)
        {
            Id = id;
            Name = name;
            ItemCondition = itemCondition;
            ApprovalStatus = needsApproval;
            InStorage = inStorage;
        }
    }
}
