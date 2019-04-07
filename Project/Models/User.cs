using System.Collections.Generic;

namespace argument.Models
{
    public class User
    {

        public List<Item> Inventory { get; set; }
        public User()
        {

            Inventory = new List<Item>();
        }
    }
}