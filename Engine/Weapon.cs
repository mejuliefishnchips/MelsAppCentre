using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Weapon :  Item
    {
        public int maxDamage { get; set; }
        public int minDamage { get; set; }

        public Weapon( int ID, string Name, string NamePlural, int MinDamage, int MaxDamage ): base(ID, Name, NamePlural)
        {
            minDamage = MinDamage;
            maxDamage = MaxDamage;
        }
    }
}
