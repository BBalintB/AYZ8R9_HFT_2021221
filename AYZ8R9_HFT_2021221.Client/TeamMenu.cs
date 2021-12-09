using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    static class TeamMenu
    {
        public static void Executee(RestService rest)
        {
            string choose = "";
            while (choose != "6")
            {
                Console.Clear();
                Console.WriteLine("///////////////////////");
                Console.WriteLine("//       Teams       //");
                Console.WriteLine("//                   //");
                Console.WriteLine("//    1 - Get all    //");
                Console.WriteLine("//    2 - Get one    //");
                Console.WriteLine("//    3 - Create     //");
                Console.WriteLine("//    4 - Update     //");
                Console.WriteLine("//    5 - Delete     //");
                Console.WriteLine("//    6 - Exit       //");
                Console.WriteLine("//                   //");
                Console.WriteLine("///////////////////////");
                Console.WriteLine("Choose: ");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                         Console.Clear();
                         Extension.ToProcess<Team>(GetTeams(rest), "All teams");
                         Console.WriteLine("Press Enter to continue...");
                         Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        var test = GetTeam(rest);
                        if (test == null)
                        {
                            Console.WriteLine("Team with that id does not exist!");
                        }
                        else {
                            Console.WriteLine(test);
                        }
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Create(rest);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Update(rest);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Delete(rest);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Leaving the table......");
                        break;
                    default:
                        break;
                }
            }
        }

        static IEnumerable<Team> GetTeams(RestService rest)
        {
            return rest.Get<Team>("/team");
        }
        static Team GetTeam(RestService rest)
        {
            Console.Write("Give me the id of the team: ");
            int pId = int.Parse(Console.ReadLine());
            return rest.GetSingle<Team>("/team/" + pId);
        }
        static void Create(RestService rest)
        {
            Console.WriteLine("Create a new team");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Name of the head coach: ");
            string cName = Console.ReadLine();
            Console.Write("Stadium:");
            string stadium = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Division: ");
            string division = Console.ReadLine();
            Team nt = new Team() { TeamName = name, HeadCoach = cName, Stadium = stadium, City = city, Division = division };
            rest.Post<Team>(nt, "/team");
            Console.WriteLine("Team succesfully created!");
        }
        static void Update(RestService rest)
        {
            Console.WriteLine("What do you want to change? Choose\nteam - Team name\ncoach - Coach name");
            string choose = Console.ReadLine();
            if (choose == "team")
            {
                Console.WriteLine("Give me the id of the team: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new name: ");
                string name = Console.ReadLine();
                rest.Put(pId, "team", name, "/team");
                Console.WriteLine("Team succesfully updated!");
            }
            else if (choose == "coach")
            {
                Console.WriteLine("Give me the id of the team: ");
                int pId = int.Parse(Console.ReadLine());
                Console.WriteLine("Give me the new coach name: ");
                string name = Console.ReadLine();
                rest.Put(pId, "coach", name, "/team");
                Console.WriteLine("Team succesfully updated!");
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
            rest.Delete(id, "/team");
            Console.WriteLine("Team succesfully deleted!");
        }
    }
}
