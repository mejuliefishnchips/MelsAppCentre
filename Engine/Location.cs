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
        public Item itemRequiredToEnter { get; set; }
        public Quest questAvailableHere { get; set; }
        public Monster monsterLivingHere { get; set; }
        public Location locationToNorth { get; set; }
        public Location locationToEast { get; set; }
        public Location locationToSouth { get; set; }
        public Location locationToWest { get; set; }


        public Location(int ID, string Name, string Description Item ItemRequiredToEnter = null, Quest QuestAvailableHere = null, Monster MonsterLivingHere = null)
        {
            id = ID;
            name = Name;
            description = Description;
            itemRequiredToEnter = ItemRequiredToEnter;
            questAvailableHere = QuestAvailableHere;
            monsterLivingHere = MonsterLivingHere;
        }
    }

    
}
