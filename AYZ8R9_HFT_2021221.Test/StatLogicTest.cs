using AYZ8R9_HFT_2021221.Logic;
using AYZ8R9_HFT_2021221.Logic.Exceptions;
using AYZ8R9_HFT_2021221.Models;
using AYZ8R9_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Test
{
    [TestFixture]
    class StatLogicTest
    {
        private StatisticLogic StatLogic { get; set; }
        [SetUp]
        public void Setup()
        {
            
            Mock<IStatisticRepository> mockedStatRepo = new Mock<IStatisticRepository>();
            mockedStatRepo.Setup(x => x.GetAll()).Returns(this.FakeStatObjects);
            this.StatLogic = new StatisticLogic(mockedStatRepo.Object);
        }
        [Test]
        public void ChangeTouchdownsThrowsExceptionWrongId()
        {
            Assert.Throws<WrongId>(() => StatLogic.ChangeTouchdowns(15, 15));
        }

        [Test]
        public void ChangeRushingYardsThrowsExceptionYardsCantBeMinus()
        {
            Assert.Throws<YardsCantBeMinus>(() => StatLogic.ChangeRushingyard(1, -200));
        }
        private IQueryable<Statistic> FakeStatObjects()
        {
            //-----------------------------------Teams
            Team GB = new Team() { TeamId = 1, TeamName = "Green Bay Packers", HeadCoach = "Matt LaFleur", Division = "NFC North", City = "Green Bay", Stadium = "Lambeau Field" };
            Team BR = new Team() { TeamId = 2, TeamName = "Baltimore Ravens", HeadCoach = "John Harbaugh", Division = "AFC North", City = "Baltimore", Stadium = "M&T Bank Stadium" };
            Team BB = new Team() { TeamId = 3, TeamName = "Buffalo Bills", HeadCoach = "Sean McDermott", Division = "AFC East", City = "Orchard park", Stadium = "Highmark Stadium" };
            Team HT = new Team() { TeamId = 4, TeamName = "Houston Texans", HeadCoach = "David Culley", Division = "AFC South", City = "Houston", Stadium = "NRG Stadium" };
            Team JJ = new Team() { TeamId = 5, TeamName = "Jacksonville Jaguars", HeadCoach = "Urban Meyer", Division = "AFC South", City = "Jacksonville", Stadium = "TIAA Bank Field" };
            GB.Players = new List<Player>();
            BR.Players = new List<Player>();
            BB.Players = new List<Player>();
            HT.Players = new List<Player>();
            JJ.Players = new List<Player>();

            //------------------------------------Statistics

            Statistic ARS = new Statistic() { StatId = 1, PassingYards = 1241, Touchdowns = 10 };
            Statistic AJS = new Statistic() { StatId = 2, RushingYards = 309, Touchdowns = 2 };
            Statistic DAS = new Statistic() { StatId = 3, ReceivingYards = 579, Touchdowns = 2 };
            Statistic LJS = new Statistic() { StatId = 4, PassingYards = 1519, Touchdowns = 8 };
            Statistic MBS = new Statistic() { StatId = 5, ReceivingYards = 451, Touchdowns = 5 };
            Statistic MAS = new Statistic() { StatId = 6, ReceivingYards = 400, Touchdowns = 2 };
            Statistic JAS = new Statistic() { StatId = 7, PassingYards = 1370, Touchdowns = 12 };
            Statistic SDS = new Statistic() { StatId = 8, ReceivingYards = 374, Touchdowns = 1 };
            Statistic DMS = new Statistic() { StatId = 9, PassingYards = 669, Touchdowns = 5 };
            Statistic TLS = new Statistic() { StatId = 10, PassingYards = 1146, Touchdowns = 6 };

            //------------------------------------Players

            Player AR = new Player() { PlayerId = 1, PlayerName = "Aaron Rodgers", PlayerJerseyNumber = 12, Age = 37, Position = "QB", TeamID = GB.TeamId, StatID = ARS.StatId };
            Player AJ = new Player() { PlayerId = 2, PlayerName = "Aaron Jones", PlayerJerseyNumber = 33, Age = 26, Position = "RB", TeamID = GB.TeamId, StatID = AJS.StatId };
            Player DA = new Player() { PlayerId = 3, PlayerName = "Davante Adams", PlayerJerseyNumber = 17, Age = 28, Position = "WR", TeamID = GB.TeamId, StatID = DAS.StatId };
            Player LJ = new Player() { PlayerId = 4, PlayerName = "Lamar Jackson", PlayerJerseyNumber = 8, Age = 24, Position = "QB", TeamID = BR.TeamId, StatID = LJS.StatId };
            Player MB = new Player() { PlayerId = 5, PlayerName = "Marquise Brown", PlayerJerseyNumber = 5, Age = 24, Position = "WR", TeamID = BR.TeamId, StatID = MBS.StatId };
            Player MA = new Player() { PlayerId = 6, PlayerName = "Mark Andrews", PlayerJerseyNumber = 89, Age = 26, Position = "TE", TeamID = BR.TeamId, StatID = MAS.StatId };
            Player JA = new Player() { PlayerId = 7, PlayerName = "Josh Allen", PlayerJerseyNumber = 17, Age = 25, Position = "QB", TeamID = BB.TeamId, StatID = JAS.StatId };
            Player SD = new Player() { PlayerId = 8, PlayerName = "Stefon Diggs", PlayerJerseyNumber = 14, Age = 27, Position = "WR", TeamID = BB.TeamId, StatID = SDS.StatId };
            Player DM = new Player() { PlayerId = 9, PlayerName = "Davis Mills", PlayerJerseyNumber = 10, Age = 22, Position = "QB", TeamID = HT.TeamId, StatID = DMS.StatId };
            Player TL = new Player() { PlayerId = 10, PlayerName = "Trevor Lawrence", PlayerJerseyNumber = 16, Age = 22, Position = "QB", TeamID = JJ.TeamId, StatID = TLS.StatId };
            GB.Players.Add(AR);
            GB.Players.Add(AJ);
            GB.Players.Add(DA);
            BR.Players.Add(LJ);
            BR.Players.Add(MB);
            BR.Players.Add(MA);
            BB.Players.Add(JA);
            BB.Players.Add(SD);
            HT.Players.Add(DM);
            JJ.Players.Add(TL);
            //-------------
            AR.Stat = ARS;
            AJ.Stat = AJS;
            DA.Stat = DAS;
            LJ.Stat = LJS;
            MB.Stat = MBS;
            MA.Stat = MAS;
            JA.Stat = JAS;
            SD.Stat = SDS;
            DM.Stat = DMS;
            TL.Stat = TLS;
            //--------------
            AR.Teams = GB;
            AJ.Teams = GB;
            DA.Teams = GB;
            LJ.Teams = BR;
            MB.Teams = BR;
            MA.Teams = BR;
            JA.Teams = BB;
            SD.Teams = BB;
            DM.Teams = HT;
            TL.Teams = JJ;
            List<Statistic> stats = new List<Statistic>();
            stats.Add(ARS);
            stats.Add(AJS);
            stats.Add(DAS);
            stats.Add(LJS);
            stats.Add(MBS);
            stats.Add(MAS);
            stats.Add(JAS);
            stats.Add(SDS);
            stats.Add(DMS);
            stats.Add(TLS);
            return stats.AsQueryable();
        }
    }
}
