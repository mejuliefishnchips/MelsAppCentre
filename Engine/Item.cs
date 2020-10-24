﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string namePlural { get; set; }

        public Item (int ID, string Name, string NamePlural)
        {
            id = ID;
            name = Name;
            namePlural = NamePlural;
        }
    }
}
