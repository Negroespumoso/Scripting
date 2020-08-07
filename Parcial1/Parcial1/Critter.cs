using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1
{
    class Critter
    {
        public string name;
        float baseAttack;
        float baseDefense;
        public float baseSpeed;
        string affinity;
        public Skill[] moveset = new Skill[2];
        public float hp;

        Critter target;

        float damageValue;
        float currentAttack;
        float currentDefense;
        float currentSpeed;


        public void SetTarget(Player a)
        {
            target = a.activeCritter;
        }

        public void UseSupport(int a)
        {
            if (moveset[a].name == "AtkUp" && currentAttack<(baseAttack*1.9))
            {
                currentAttack += currentAttack * 0.2f;
            }
            else if (moveset[a].name == "DefUp" && currentDefense<(baseDefense*1.6))
            {
                currentDefense += currentDefense * 0.2f;
            }
            else if (moveset[a].name == "SpdDown" && target.currentSpeed<(baseSpeed*1.6))
            {
                target.currentSpeed -= currentSpeed * 0.3f;
            }
            Console.WriteLine(name + " uses support skill.");
        }
        public void UseSkill(int a)
        {
            if (moveset[a] is AttackSkill)
            {
                float affinityMultiplier = 1;
                if (affinity == moveset[a].affinity)
                {
                    affinityMultiplier = 0.5f;
                }

                else if (affinity == "Dark")
                {
                    if (moveset[a].affinity == "Light")
                    {
                        affinityMultiplier = 2;
                    }
                }

                else if (affinity == "Light")
                {
                    if (moveset[a].affinity == "Dark")
                    {
                        affinityMultiplier = 2;
                    }
                }

                else if (affinity == "Fire")
                {
                    if (moveset[a].affinity == "Water")
                    {
                        affinityMultiplier = 0.5f;
                    }
                }

                else if (affinity == "Water")
                {
                    if (moveset[a].affinity == "Fire")
                    {
                        affinityMultiplier = 2;
                    }
                    else if (moveset[a].affinity == "Wind")
                    {
                        affinityMultiplier = 0.5f;
                    }
                }

                else if (affinity == "Wind")
                {
                    if (moveset[a].affinity == "Water")
                    {
                        affinityMultiplier = 2;
                    }
                    else if (moveset[a].affinity == "Earth")
                    {
                        affinityMultiplier = 2;
                    }
                }

                else if (affinity == "Earth")
                {
                    if (moveset[a].affinity == "Fire")
                    {
                        affinityMultiplier = 0;
                    }
                    else if (moveset[a].affinity == "Wind")
                    {
                        affinityMultiplier = 0.5f;
                    }
                }
                damageValue = (moveset[a].power * baseAttack) + affinityMultiplier;
                target.hp -= damageValue;
                Console.WriteLine(name + " hits " + target.name + " for " + damageValue + " damage.");
            }
            else UseSupport(a);
        }

        public Critter(string n)
        {
            if (n == "Fire Critter")
            {
                name = n;                
                baseAttack = 8;
                baseDefense = 5;
                baseSpeed = 7;
                affinity = "Fire";
                moveset[0] = new AttackSkill("Roast");
                moveset[1] = new SupportSkill("AtkUp");
                hp = 70;

                currentAttack = baseAttack;
                currentDefense = baseDefense;
                currentSpeed = baseSpeed;
            }

            else if (n == "Dark Critter")
            {
                name = n;
                baseAttack = 7;
                baseDefense = 4;
                baseSpeed = 5;
                affinity = "Dark";
                moveset[0] = new AttackSkill("Annihilate");
                moveset[1] = new SupportSkill("SpdDown");
                hp = 80;

                currentAttack = baseAttack;
                currentDefense = baseDefense;
                currentSpeed = baseSpeed;
            }

            else if (n == "Light Critter")
            {
                name = n;
                baseAttack = 10;
                baseDefense = 2;
                baseSpeed = 10;
                affinity = "Light";
                moveset[0] = new AttackSkill("Roast");
                moveset[1] = new SupportSkill("AtkUp");
                hp = 50;

                currentAttack = baseAttack;
                currentDefense = baseDefense;
                currentSpeed = baseSpeed;
            }

            else if (n == "Water Critter")
            {
                name = n;
                baseAttack = 6;
                baseDefense = 5;
                baseSpeed = 4;
                affinity = "Water";
                moveset[0] = new AttackSkill("Slap");
                moveset[1] = new SupportSkill("SpdDown");
                hp = 80;

                currentAttack = baseAttack;
                currentDefense = baseDefense;
                currentSpeed = baseSpeed;
            }

            else if (n == "Wind Critter")
            {
                name = n;
                baseAttack = 8;
                baseDefense = 3;
                baseSpeed = 7;
                affinity = "Wind";
                moveset[0] = new AttackSkill("Annihilate");
                moveset[1] = new SupportSkill("AtkUp");
                hp = 65;

                currentAttack = baseAttack;
                currentDefense = baseDefense;
                currentSpeed = baseSpeed;
            }

            else if (n == "Earth Critter")
            {
                name = n;
                baseAttack = 4;
                baseDefense = 10;
                baseSpeed = 2;
                affinity = "Earth";
                moveset[0] = new AttackSkill("Slap");
                moveset[1] = new SupportSkill("DefUp");
                hp = 100;

                currentAttack = baseAttack;
                currentDefense = baseDefense;
                currentSpeed = baseSpeed;
            }
        }
    }
}
