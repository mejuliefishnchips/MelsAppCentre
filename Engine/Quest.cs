using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Quest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int rewardExpPoints { get; set; }
        public int rewardGold { get; set; }

    }
}
