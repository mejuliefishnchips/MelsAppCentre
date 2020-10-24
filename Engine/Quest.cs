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
        public Item rewardItem { get; set; }
        public List<QuestCompletionItem> QuestCompletionItems { get; set; }


        public Quest(int ID, string Name, string Description, int RewardEP, int RewardG, Item RewardItem = null)
        {
            id = ID;
            name = Name;
            description = Description;
            rewardExpPoints = RewardEP;
            rewardGold = RewardG;
            rewardItem = RewardItem;

            QuestCompletionItems = new List<QuestCompletionItem>();
        }

    }
}
