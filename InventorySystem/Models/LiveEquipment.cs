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
        public string Owner { get; set; }
        public override ItemType Type
        {
            get { return ItemType.LiveEquipment; }
        }
    }
}
