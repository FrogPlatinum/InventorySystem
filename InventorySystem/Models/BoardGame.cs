using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class BoardGame : Item
    {
        public string Edition {  get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public override ItemType Type
        {
            get { return ItemType.BoardGame; }
        }
    }
}
