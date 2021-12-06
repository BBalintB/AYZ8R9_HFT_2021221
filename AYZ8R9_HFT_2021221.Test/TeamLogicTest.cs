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
    class TeamLogicTest
    {
        private TeamLogic TeamLogic { get; set; }
        [SetUp]
        public void Setup()
        {

            Mock<ITeamRepository> mockedTeamRepo = new Mock<ITeamRepository>();
            mockedTeamRepo.Setup(x => x.GetAll()).Returns(this.FakeTeamObjects);
            this.TeamLogic = new TeamLogic(mockedTeamRepo.Object);
        }
        [Test]
        public void EmptyNameThrowsException()
        {
            var xy = Assert.Throws<NameIsEmpty>(() => TeamLogic.ChangeCoach(2, ""));
        }

        [Test]
        public void CreateThrowsExceptionIfTheTeamExist()
        {
            Assert.Throws<AlreadyExist>(() => TeamLogic.CreateTeam(new Team() { TeamId = 1, TeamName = "Green Bay Packers", HeadCoach = "Matt LaFleur", Division = "NFC North", City = "Green Bay", Stadium = "Lambeau Field" }));
        }
        private IQueryable<Team> FakeTeamObjects()
        {
            //-----------------------------------Teams
            Team GB = new Team() { TeamId = 1, TeamName = "Green Bay Packers", HeadCoach = "Matt LaFleur", Division = "NFC North", City = "Green Bay", Stadium = "Lambeau Field" };
            Team BR = new Team() { TeamId = 2, TeamName = "Baltimore Ravens", HeadCoach = "John Harbaugh", Division = "AFC North", City = "Baltimore", Stadium = "M&T Bank Stadium" };
            Team BB = new Team() { TeamId = 3, TeamName = "Buffalo Bills", HeadCoach = "Sean McDermott", Division = "AFC East", City = "Orchard park", Stadium = "Highmark Stadium" };
            Team HT = new Team() { TeamId = 4, TeamName = "Houston Texans", HeadCoach = "David Culley", Division = "AFC South", City = "Houston", Stadium = "NRG Stadium" };
            Team JJ = new Team() { TeamId = 5, TeamName = "Jacksonville Jaguars", HeadCoach = "Urban Meyer", Division = "AFC South", City = "Jacksonville", Stadium = "TIAA Bank Field" };
            Team TBB = new Team() { TeamId = 6, TeamName = "Tampa Bay Buccaners", HeadCoach = "Bruce Arians", Division = "NFC South", City = "Tampa", Stadium = "Raymond James Stadium" };
            Team NS = new Team() { TeamId = 7, TeamName = "New Orleans Saints", HeadCoach = "Sean Payton", Division = "NFC South", City = "New Orleans", Stadium = "Superdome" };
            Team IC = new Team() { TeamId = 8, TeamName = "Indianapolis Colts", HeadCoach = "Frank Reich", Division = "AFC South", City = "Indianapolis", Stadium = "Lucas Oil Stadium" };
            Team MV = new Team() { TeamId = 9, TeamName = "Minnesota Vikings", HeadCoach = "Mike Zimmer", Division = "NFC North", City = "Eden Praire", Stadium = "U. S. Bank Stadium" };
            GB.Players = new List<Player>();
            BR.Players = new List<Player>();
            BB.Players = new List<Player>();
            HT.Players = new List<Player>();
            JJ.Players = new List<Player>();
            TBB.Players = new List<Player>();
            NS.Players = new List<Player>();
            IC.Players = new List<Player>();
            MV.Players = new List<Player>();

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
            Statistic TBS = new Statistic() { StatId = 11, PassingYards = 2500, Touchdowns = 11 };
            Statistic LFS = new Statistic() { StatId = 12, RushingYards = 1800, Touchdowns = 8 };
            Statistic MES = new Statistic() { StatId = 13, ReceivingYards = 1210, Touchdowns = 3 };
            Statistic JWS = new Statistic() { StatId = 14, PassingYards = 1040, Touchdowns = 5 };
            Statistic MTS = new Statistic() { StatId = 15, ReceivingYards = 650, Touchdowns = 1 };
            Statistic AKS = new Statistic() { StatId = 16, RushingYards = 1422, Touchdowns = 4 };
            Statistic CWS = new Statistic() { StatId = 17, PassingYards = 1321, Touchdowns = 8 };
            Statistic JTS = new Statistic() { StatId = 18, RushingYards = 1942, Touchdowns = 12 };
            Statistic THS = new Statistic() { StatId = 19, ReceivingYards = 942, Touchdowns = 4 };
            Statistic KCS = new Statistic() { StatId = 20, PassingYards = 1752, Touchdowns = 8 };

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
            Player TB = new Player() { PlayerId = 11, PlayerName = "Tom Brady", PlayerJerseyNumber = 12, Age = 43, Position = "QB", TeamID = TBB.TeamId, StatID = TBS.StatId };
            Player LF = new Player() { PlayerId = 12, PlayerName = "Leonard Fournette", PlayerJerseyNumber = 7, Age = 26, Position = "RB", TeamID = TBB.TeamId, StatID = LFS.StatId };
            Player ME = new Player() { PlayerId = 13, PlayerName = "Mike Evans", PlayerJerseyNumber = 13, Age = 28, Position = "WR", TeamID = TBB.TeamId, StatID = MES.StatId };
            Player JW = new Player() { PlayerId = 14, PlayerName = "Jameis Winston", PlayerJerseyNumber = 2, Age = 27, Position = "QB", TeamID = NS.TeamId, StatID = JWS.StatId };
            Player MT = new Player() { PlayerId = 15, PlayerName = "Michael Thomas", PlayerJerseyNumber = 13, Age = 28, Position = "WR", TeamID = NS.TeamId, StatID = MTS.StatId };
            Player AK = new Player() { PlayerId = 16, PlayerName = "Alvin Kamara", PlayerJerseyNumber = 41, Age = 26, Position = "HB", TeamID = NS.TeamId, StatID = AKS.StatId };
            Player CW = new Player() { PlayerId = 17, PlayerName = "Carson Wentz", PlayerJerseyNumber = 2, Age = 28, Position = "QB", TeamID = IC.TeamId, StatID = CWS.StatId };
            Player JT = new Player() { PlayerId = 18, PlayerName = "Jonathan Taylor", PlayerJerseyNumber = 28, Age = 22, Position = "RB", TeamID = IC.TeamId, StatID = JTS.StatId };
            Player TH = new Player() { PlayerId = 19, PlayerName = "T.Y. Hilton", PlayerJerseyNumber = 13, Age = 32, Position = "WR", TeamID = IC.TeamId, StatID = THS.StatId };
            Player KC = new Player() { PlayerId = 20, PlayerName = "Kirk Cousins", PlayerJerseyNumber = 8, Age = 33, Position = "QB", TeamID = MV.TeamId, StatID = KCS.StatId };
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
            TBB.Players.Add(TB);
            TBB.Players.Add(LF);
            TBB.Players.Add(ME);
            NS.Players.Add(JW);
            NS.Players.Add(MT);
            NS.Players.Add(AK);
            IC.Players.Add(CW);
            IC.Players.Add(JT);
            IC.Players.Add(TH);
            MV.Players.Add(KC);

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
            TB.Stat = TBS;
            LF.Stat = LFS;
            ME.Stat = MES;
            JW.Stat = JWS;
            MT.Stat = MTS;
            AK.Stat = AKS;
            CW.Stat = CWS;
            JT.Stat = JTS;
            TH.Stat = THS;
            KC.Stat = KCS;
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
            TB.Teams = TBB;
            LF.Teams = TBB;
            ME.Teams = TBB;
            JW.Teams = NS;
            MT.Teams = NS;
            AK.Teams = NS;
            CW.Teams = IC;
            JT.Teams = IC;
            TH.Teams = IC;
            KC.Teams = MV;

            List<Team> team = new List<Team>();
            team.Add(GB);
            team.Add(BR);
            team.Add(BB);
            team.Add(HT);
            team.Add(JJ);
            team.Add(TBB);
            team.Add(NS);
            team.Add(IC);
            team.Add(MV);

            return team.AsQueryable();
        }
    }
}
