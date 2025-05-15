using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class IdGenerator
    {
        Random Random = new Random();

        private List<string> _usedId = new List<string>();

        public string GenerateId(string prefix)
        {
            string prefixTag = prefix.ToUpper();
            string id;
            do
            {
                int number = Random.Next(10000000, 99999999);
                id = $"{prefixTag}--{number}";
            }
            while(_usedId.Contains(id));

            _usedId.Add(id);
            return id ;

        }
    }
}
