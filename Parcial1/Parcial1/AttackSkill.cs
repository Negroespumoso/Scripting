using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1
{
    class AttackSkill : Skill
    {
        public AttackSkill(string n)
        {
            if (n == "Annihilate")
            {
                name = n;
                affinity = "Water";
                power = 10;
            }
            else if (n == "Slap")
            {
                name = n;
                affinity = "Earth";
                power = 4;
            }
            else if (n == "Roast")
            {
                name = n;
                affinity = "Fire";
                power = 6;
            }
        }
    }
}
