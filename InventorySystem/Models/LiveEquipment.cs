using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class LiveEquipment : Item
    {
        public enum TypeOfEquipment
        {
            Camp,
            Costume,
            Weapon,
            Decoration,
            Accessories,
            Cutlery
        }
        public TypeOfEquipment EquipmentType { get; set; }
        public string Owner { get; set; }
        public override ItemType Type
        {
            get { return ItemType.LiveEquipment; }
        }
        public LiveEquipment(string id, string name, Condition itemCondition, NeedsApproval needsApproval, StorageStatus inStorage, TypeOfEquipment equipmentType, string owner)
            : base(id, name, itemCondition, needsApproval, inStorage)
        {
            EquipmentType = equipmentType;
            Owner = owner;
        }
    }
}
