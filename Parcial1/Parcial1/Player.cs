using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1
{
    class Player
    {
        public string name;
        public List<Critter> critters = new List<Critter>();
        public Critter activeCritter;
        public int activeAbility;

        public int activePosition = 0;

        public void StealCritter(Player p)
        {
            critters.Add(new Critter(p.activeCritter.name));
            p.critters.Remove(activeCritter);
        }

        public void SetActiveCritter(int n)
        {
            activeCritter = critters[n];
        }
    }
}
