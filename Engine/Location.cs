using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public Location(int ID, string Name, string Description)
        {
            id = ID;
            name = Name;
            description = Description;
        }
    }

    
}
