using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Parcial1
{
    class GameManager
    {
        static void Main(string[] args)
        {
            Critter[] critterList = { new Critter("Dark Critter"), new Critter("Light Critter"), new Critter("Fire Critter"), new Critter("Water Critter"), new Critter("Wind Critter"), new Critter("Earth Critter") };
            int a = 0;

            Player player1 = new Player();
            Player player2 = new Player();

            void ListCritters()
            {
                for ( int i = 0; i<critterList.Length; i++)
                {
                    Console.WriteLine(i + ". " + critterList[i].name);
                }
            }


            //Intro
            Console.WriteLine("Welcome to Creeter Stadium, where you send of your critters to fight with your opponents´ and steal them. Whoever looses all of their creeters first looses the game.");

            //Set Names
            Console.WriteLine("Write a name for Player 1");
            player1.name = Console.ReadLine();
            Console.WriteLine("Write a name for Player2");
            player2.name = Console.ReadLine();

            //Set Critter Collection
            Console.WriteLine(player1.name + ", choose main critter");
            ListCritters();
            Int32.TryParse(Console.ReadLine(), out a);
            player1.critters.Add(critterList[a]);
            player1.activeCritter = critterList[a];
            Console.WriteLine(player1.name + ", choose secondary critter(Write critter number)");
            ListCritters();
            Int32.TryParse(Console.ReadLine(), out a);
            player1.critters.Add(critterList[a]);

            Console.WriteLine(player2.name + ", choose main critter(Write critter number)");
            ListCritters();
            Int32.TryParse(Console.ReadLine(), out a);
            player2.critters.Add(critterList[a]);
            player2.activeCritter = critterList[a];
            Console.WriteLine(player2.name + ", choose secondary critter(Write critter number)");
            ListCritters();
            Int32.TryParse(Console.ReadLine(), out a);
            player2.critters.Add(critterList[a]);

            Console.WriteLine("GAME START");         


            //Game Loop turns
            while (player1.critters != null || player2.critters != null)
            {
                player1.activeCritter.SetTarget(player2);
                player2.activeCritter.SetTarget(player1);
                //Turns
                Turn(player1);
                Turn(player2);


                //Attack phase
                if (player1.activeCritter.baseSpeed > player2.activeCritter.baseSpeed)
                {
                    player1.activeCritter.UseSkill(player1.activeAbility);
                    if(player2.activeCritter.hp <= 0)
                    {
                        player2.activeCritter.hp = 0;
                        Console.WriteLine(player1.name + " has stolen "+ player2.name + "´s "  + player2.activeCritter.name);                       
                        player1.StealCritter(player2);
                        player2.activePosition += 1;
                        if (player2.activePosition > player2.critters.Count) break;
                        else
                        {
                            player2.activeCritter = player2.critters[player2.activePosition];
                            Console.WriteLine(player2.name + " has lost its critter, changing to " + player2.activeCritter.name);
                        }
                    }
                    else if (player1.activeCritter.hp <= 0)
                    {
                        player1.activeCritter.hp = 0;
                        Console.WriteLine(player2.name + " has stolen " + player1.name + "´s " + player1.activeCritter.name);
                        player2.StealCritter(player1);
                        player1.activePosition += 1;
                        if (player1.activePosition > player1.critters.Count) break;
                        else
                        {
                            player1.activeCritter = player1.critters[player1.activePosition];
                            Console.WriteLine(player1.name + " has lost its critter, changing to " + player1.activeCritter.name);
                        }
                    }
                    else
                    {
                        player2.activeCritter.UseSkill(player2.activeAbility);
                    }
                }
                else
                {
                    player2.activeCritter.UseSkill(player2.activeAbility);
                    if (player1.activeCritter.hp <= 0)
                    {
                        player1.activeCritter.hp = 0;
                        Console.WriteLine(player2.name + " has stolen " + player1.name + "´s " + player1.activeCritter.name);
                        player2.StealCritter(player1);
                        player1.activePosition += 1;
                        if (player1.activePosition > player1.critters.Count) break;
                        else
                        {
                            player1.activeCritter = player1.critters[player1.activePosition];
                            Console.WriteLine(player1.name + " has lost its critter, changing to " + player1.activeCritter.name);
                        }
                    }
                    else if (player2.activeCritter.hp <= 0)
                    {
                        player2.activeCritter.hp = 0;
                        Console.WriteLine(player1.name + " has stolen " + player2.name + "´s " + player2.activeCritter.name);
                        player1.StealCritter(player2);
                        player2.activePosition += 1;
                        if (player2.activePosition > player2.critters.Count) break;
                        else
                        {
                            player2.activeCritter = player2.critters[player2.activePosition];
                            Console.WriteLine(player2.name + " has lost its critter, changing to " + player2.activeCritter.name);
                        }
                    }
                    else
                    {
                        player1.activeCritter.UseSkill(player1.activeAbility);
                    }
                }
                Console.WriteLine(player1.name + "´s Critter health: " + player1.activeCritter.hp);
                Console.WriteLine(player2.name + "´s Critter health: " + player2.activeCritter.hp);
            }

            //Visctory
            if(player1.activePosition > player1.critters.Count)
            {
                Console.WriteLine("Congratulations " +player2+", you are the winner" );
            }
            if (player2.activePosition > player2.critters.Count)
            {
                Console.WriteLine("Congratulations " + player1 + ", you are the winner");
            }


            void Turn(Player p)
            {
                Console.WriteLine(p.name + ", choose an ability(Write ability number)");
                for (int i = 0; i < p.activeCritter.moveset.Length; i++)
                {
                    Console.WriteLine(i + ". " + p.activeCritter.moveset[i].name);
                }
                Int32.TryParse(Console.ReadLine(), out p.activeAbility);
            }
        }
    }
}
