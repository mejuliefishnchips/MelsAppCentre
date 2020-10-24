using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Weapon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string namePlural { get; set; }
        public int maxDamage { get; set; }
        public int minDamage { get; set; }
    }
}
