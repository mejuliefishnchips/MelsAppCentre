using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Monster
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxHitPoints { get; set; }
        public int currentHitPoints { get; set; }
        public int maxDamage { get; set; }
        public int rewardExpPoints { get; set; }
        public int rewardGold { get; set; }

    }
}
