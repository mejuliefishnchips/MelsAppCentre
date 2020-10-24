using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class HealingPotion : Item
    {
        public int amountToHeal { get; set; }

        public HealingPotion (int ID, string Name, string NamePlural, int AmountToHeal) : base (ID, Name, NamePlural )
        {
            amountToHeal = AmountToHeal;
        }
    }
}
