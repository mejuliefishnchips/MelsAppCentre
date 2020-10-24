using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Monster : LivingCreature 
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxDamage { get; set; }
        public int rewardExpPoints { get; set; }
        public int rewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }
        public Monster(int ID, string Name, int MaxDamage, int RewardEP, int RewardG,  int CurrentHitPoints, int MaxHitPoints) : base( CurrentHitPoints, MaxHitPoints)
        {
            id = ID;
            name = Name;
            maxDamage = MaxDamage;
            rewardExpPoints = RewardEP;
            rewardGold = RewardG;
            LootTable = new List<LootItem>();
        }

    }
}
