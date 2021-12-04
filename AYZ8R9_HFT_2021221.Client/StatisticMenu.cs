using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    static class StatisticMenu
    {
        public static void Executee(RestService rest)
        {
            int choose = 0;
            while (choose != 6)
            {
                Console.Clear();
                Console.WriteLine("///////////////////////////");
                Console.WriteLine("//       Statistic       //");
                Console.WriteLine("//                       //");
                Console.WriteLine("//    1 - Get all        //");
                Console.WriteLine("//    2 - Get one        //");
                Console.WriteLine("//    3 - Create         //");
                Console.WriteLine("//    4 - Update         //");
                Console.WriteLine("//    6 - Exit           //");
                Console.WriteLine("//    5 - Delete         //");
                Console.WriteLine("//                       //");
                Console.WriteLine("///////////////////////////");
                Console.Write("Choose: ");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Extension.ToProcess<Statistic>(GetTeams(rest), "All statistics");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(GetTeam(rest));
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

        static IEnumerable<Statistic> GetTeams(RestService rest)
        {
            return rest.Get<Statistic>("/stat");
        }
        static Statistic GetTeam(RestService rest)
        {
            Console.Write("Give me the id of the statistic: ");
            int pId = int.Parse(Console.ReadLine());
            return rest.GetSingle<Statistic>("/stat/" + pId);
        }
        static void Create(RestService rest)
        {
            Console.WriteLine("Create a new statistic");
            Console.Write("Passingyards: ");
            int pYards = int.Parse(Console.ReadLine());
            Console.Write("Rushingyards: ");
            int ruYards = int.Parse(Console.ReadLine());
            Console.Write("Receivingyards: ");
            int reYards = int.Parse(Console.ReadLine());
            Console.Write("Touchdowns: ");
            int touchD = int.Parse(Console.ReadLine());
            Statistic stat = new Statistic() { PassingYards = pYards, RushingYards = ruYards, ReceivingYards = reYards, Touchdowns = touchD };

            rest.Post<Statistic>(stat, "/stat");
        }
        static void Update(RestService rest)
        {
            Console.WriteLine("What do you want to change? Choose\nPassing - Passingyards\nRushing - Rushingyards\nReceiving - Receivingyards\nTouchdowns - Touchdowns");
            string choose = Console.ReadLine();
            if (choose == "Passing")
            {
                Console.WriteLine("Give me the id of the statistic: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new passingyards: ");
                int pYards = int.Parse(Console.ReadLine());

                rest.Put(pId, "Passing", pYards.ToString(), "/stat");
            }
            else if (choose == "Rushing")
            {
                Console.WriteLine("Give me the id of the statistic: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new rushingyards: ");
                int ruYards = int.Parse(Console.ReadLine());
                rest.Put(pId, "Rushing", ruYards.ToString(), "/stat");
            }
            else if (choose == "Receiving")
            {
                Console.WriteLine("Give me the id of the statistic: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new receivingyards: ");
                int reYards = int.Parse(Console.ReadLine());
                rest.Put(pId, "Receiving", reYards.ToString(), "/stat");
            }
            else if (choose == "Touchdowns")
            {
                Console.WriteLine("Give me the id of the statistic: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new receivingyards: ");
                int touchD = int.Parse(Console.ReadLine());
                rest.Put(pId, "Touchdowns", touchD.ToString(), "/stat");
            }
            else
            {
                Console.WriteLine("Theres is no option like this: " + choose);
            }
        }
        static void Delete(RestService rest)
        {
            Console.WriteLine("Give me the id that you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "/stat");
        }
    }
}
