using AYZ8R9_HFT_2021221.Data;
using AYZ8R9_HFT_2021221.Logic;
using AYZ8R9_HFT_2021221.Models;
using AYZ8R9_HFT_2021221.Repository;
using System;
using System.Linq;

namespace AYZ8R9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PlayersDatabase.mdf;Integrated Security=True
            PlayersContext ctx = new PlayersContext();
            TeamRepository tRepo = new TeamRepository(ctx);
            PlayerRepository pRepo = new PlayerRepository(ctx);
            StatisticRepository sRepo = new StatisticRepository(ctx);
            PlayerLogic pLogic = new PlayerLogic(pRepo);
            var p1 = pLogic.MostReceivingYards();
            var p2 = p1.Select(x => x.PlayerName).FirstOrDefault();
            var mostTouchdowns = pLogic.MostTouchdowns();
            var name = mostTouchdowns.Select(x => x.PlayerName).SingleOrDefault();
            ;
        }
    }
}
