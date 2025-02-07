﻿using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    static class NonCrudMenu
    {
        public static void Executee(RestService rest)
        {
            string choose = "";
            while (choose != "6")
            {
                Console.Clear();
                Console.WriteLine("////////////////////////////////////");
                Console.WriteLine("//      Multiple table select     //");
                Console.WriteLine("//                                //");
                Console.WriteLine("//    1 - Most receivingyards     //");
                Console.WriteLine("//    2 - Most rushingyards       //");
                Console.WriteLine("//    3 - Most passingyards       //");
                Console.WriteLine("//    4 - Most touchdowns         //");
                Console.WriteLine("//    5 - Players from a team     //");
                Console.WriteLine("//    6 - Exit                    //");
                Console.WriteLine("//                                //");
                Console.WriteLine("////////////////////////////////////");
                Console.Write("Choose: ");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Console.Clear();
                        Extension.ToProcess<Player>(MostReceivingYards(rest), $"Player(s) with the most receivingyards: {MostReceivingYards(rest).FirstOrDefault().Stat.ReceivingYards}");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Extension.ToProcess<Player>(MostRushingYards(rest), $"Player(s) with the most rushingyards: {MostRushingYards(rest).FirstOrDefault().Stat.RushingYards}");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Extension.ToProcess<Player>(MostPassingYards(rest), $"Player(s) with the most passingyards: {MostPassingYards(rest).FirstOrDefault().Stat.PassingYards}");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Extension.ToProcess<Player>(MostTouchdowns(rest), $"Player(s) with the most touchdowns: {MostTouchdowns(rest).FirstOrDefault().Stat.Touchdowns}");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Console.Write("Give me the team name: ");
                        string team = Console.ReadLine();
                        var test = PlayersByTeam(rest, team);
                        if (test == null)
                        {
                            Console.WriteLine("The team does not exist!");
                        }
                        else {
                            Extension.ToProcess<Player>(test, team);
                        }
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Leaving the table......");
                        break;
                }

            }
        }
        static IEnumerable<Player> MostReceivingYards(RestService rest) {
            return rest.Get<Player>("/Noncrud/MostReceivingYards");
        }
        static IEnumerable<Player> MostRushingYards(RestService rest)
        {
            return rest.Get<Player>("/Noncrud/MostRushingYards");
        }
        static IEnumerable<Player> MostPassingYards(RestService rest)
        {
            return rest.Get<Player>("/Noncrud/MostPassingYards");
        }
        static IEnumerable<Player> MostTouchdowns(RestService rest)
        {
            return rest.Get<Player>("/Noncrud/MostTouchdowns");
        }

        static IEnumerable<Player> PlayersByTeam(RestService rest, string team)
        {
         
            return rest.Get<Player>("/Noncrud/PlayersByTeam/"+team);
        }
    }
}
