using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class LivingCreature
    {
        public int maxHitPoints { get; set; }
        public int currentHitPoints { get; set; }

        public LivingCreature(int CurrentHitPoints, int MaxHitPoints)
        {
            currentHitPoints = CurrentHitPoints;
            maxHitPoints = MaxHitPoints;
        }
    }
}
