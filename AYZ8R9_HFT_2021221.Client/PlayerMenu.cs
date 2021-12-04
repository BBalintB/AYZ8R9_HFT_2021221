using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    static class PlayerMenu
    {
        public static void Executee(RestService rest) {
            int choose = 0;
            while (choose != 6)
            {
                Console.Clear();
                Console.WriteLine("///////////////////////");
                Console.WriteLine("//      Players      //");
                Console.WriteLine("//                   //");
                Console.WriteLine("//    1 - Get all    //");
                Console.WriteLine("//    2 - Get one    //");
                Console.WriteLine("//    3 - Create     //");
                Console.WriteLine("//    4 - Update     //");
                Console.WriteLine("//    5 - Delete     //");
                Console.WriteLine("//    6 - Exit       //");
                Console.WriteLine("//                   //");
                Console.WriteLine("///////////////////////");
                Console.WriteLine("If you want to create a player first you have to add a new statistic for him!");
                Console.Write("Choose: ");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Extension.ToProcess<Player>(GetPlayers(rest), "All players");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(GetPlayer(rest));
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Create(rest);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Update(rest);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Delete(rest);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Leaving the table......");
                        break;
                    default:
                        break;
                }
            }
        }

        static IEnumerable<Player> GetPlayers(RestService rest) {
            return rest.Get<Player>("player");
        }
        static Player GetPlayer(RestService rest)
        {
            Console.WriteLine("Give me the id of the player: ");
            int pId = int.Parse(Console.ReadLine());
            return rest.GetSingle<Player>("player/"+pId);
        }
        static void Create(RestService rest)
        {
            Console.WriteLine("Create a new player");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Jersey number (1-99): ");
            int jerseNumber = int.Parse(Console.ReadLine());
            Console.Write("Position(QB,HB,FB,TE,WR):");
            string position = Console.ReadLine();
            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());
            Player pp = new Player() { PlayerName = name, PlayerJerseyNumber = jerseNumber, Position = position, Age = age };
            Console.WriteLine("Give me the stat id: ");
            pp.StatID = int.Parse(Console.ReadLine());
            Console.WriteLine("Give me the team id: ");
            pp.TeamID = int.Parse(Console.ReadLine());    
            rest.Post<Player>(pp, "player");
        }
        static void Update(RestService rest)
        {
            Console.WriteLine("What do you want to change? Choose\nname - Player name\njersey - Player jersey number");
            string choose = Console.ReadLine();
            if (choose == "name")
            {
                Console.WriteLine("Give me the id of the player: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new name: ");
                string name = Console.ReadLine();
                
                rest.Put(pId, "name", name, "player");
            }
            else if (choose == "jersey")
            {
                Console.WriteLine("Give me the id of the player: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new jersey number: ");
                int number = int.Parse(Console.ReadLine());
                rest.Put(pId, "jersey", number.ToString(), "player");
            }
            else {
                Console.WriteLine("Theres is no option like this: "+choose);
            }
        }
        static void Delete(RestService rest)
        {
            Console.WriteLine("Give me the id that you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "player");
        }
    }
}
