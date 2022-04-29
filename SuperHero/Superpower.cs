using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero
{
    public class Superpower
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Superpower() { }

        public Superpower(int ID, string Name, string Description) 
        { 
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
