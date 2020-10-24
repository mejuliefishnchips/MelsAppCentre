using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int gold { get; set; }
        public int experiencePoints { get; set; }
        public int level { get; set; }

        public Player(int CurrentHitPoints, int MaxHitPoints, int Gold, int EP, int Level ) : base (CurrentHitPoints, MaxHitPoints)
        {
            gold = Gold;
            experiencePoints = EP;
            level = Level;
        }
    }
}
