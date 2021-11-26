using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    static class Menu
    {
        public static void Menus() {
            Thread.Sleep(5000); //wait for 5 second
            RestService rest = new RestService("http://localhost:49978"); //gives the url to the Rest Service class
            int choose = 0;
            while (choose != 5)
            {
                Console.Clear();
                Console.WriteLine("////////////////////////");
                Console.WriteLine("//        Menu        //");
                Console.WriteLine("//                    //");
                Console.WriteLine("//   1 - Players      //");
                Console.WriteLine("//   2 - Teams        //");
                Console.WriteLine("//   3 - Statistics   //");
                Console.WriteLine("//   4 - Non-Crud     //");
                Console.WriteLine("//   5 - Exit         //");
                Console.WriteLine("//                    //");
                Console.WriteLine("////////////////////////");
                Console.WriteLine("Choose: ");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        PlayerMenu.Executee(rest);
                        break;
                    case 2:
                        TeamMenu.Executee(rest);
                        break;
                    case 3:
                        StatisticMenu.Executee(rest);
                        break;
                    case 4:
                        NonCrudMenu.Executee(rest);
                        break;
                    case 5:
                        Console.WriteLine("Good bye!!");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
