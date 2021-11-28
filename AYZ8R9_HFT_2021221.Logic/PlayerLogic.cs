using AYZ8R9_HFT_2021221.Logic.Exceptions;
using AYZ8R9_HFT_2021221.Models;
using AYZ8R9_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        #region CRUD
        IPlayerRepository playerRepo;
        public PlayerLogic(IPlayerRepository playerRepos)
        {
            this.playerRepo = playerRepos;
        }
        public void ChangeJerseyNumber(int id, int number)
        {
            if (id > playerRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            else if (number < 1 || number > 99)
            {
                throw new JerseyNumberIsNotGood("[Err] The jersey number is not good....");
            }
            else {
                playerRepo.ChangeJerseyNumber(id, number);
            }
            
        }

        public void ChangeName(int id, string newName)
        {
            if (id > playerRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            else if (newName == "")
            {
                throw new NameIsEmpty("[Err] The name is empty....");
            }
            else {
                playerRepo.ChangeName(id, newName);
            }
        }

        public void CreatePlayer(Player NewPlayer)
        {
            
            if (TheSame(NewPlayer))
            {
                throw new AlreadyExist("[Err] The player is already exist...");
            }
            playerRepo.Create(NewPlayer);
        }

        bool TheSame(Player player) {
            bool theSame = false;
            foreach (var item in playerRepo.GetAll())
            {
                if (item.PlayerName == player.PlayerName && item.PlayerJerseyNumber == player.PlayerJerseyNumber && item.Position == player.Position && item.Age == player.Age)
                {
                    theSame = true;
                }
            }
            return theSame;
        }

        public void Delete(int id)
        {
            if (!TheSame(id))
            {
                throw new ItDoesNotExist("[Err] The player is not exist...");
            }
            playerRepo.Delete(id);
        }
        bool TheSame(int id)
        {
            bool notTheSame = false;
            foreach (var item in playerRepo.GetAll())
            {
                if (item.PlayerId == id)
                {
                    notTheSame = true;
                }
            }
            return notTheSame;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return playerRepo.GetAll();
        }

        public Player GetPlayer(int id)
        {
            if (!TheSame(id))
            {
                throw new WrongId("[Err] The id not good...");
            }
            return playerRepo.GetOne(id);
        }
        #endregion
        #region Non-CRUD
        public IEnumerable<Player> MostReceivingYards()
        {
            int yard = playerRepo.GetAll().Max(x => x.Stat.ReceivingYards);
            var mostReYard = from x in playerRepo.GetAll()
                            where x.Stat.ReceivingYards.Equals(yard)
                            select x;
            ;
            return mostReYard;
        }

        public IEnumerable<Player> MostPassingYards()
        {
            var yard = playerRepo.GetAll().Max(x => x.Stat.PassingYards);
            var mostPaYard = from x in playerRepo.GetAll()
                            where x.Stat.PassingYards == yard
                            select x;
            return mostPaYard;
        }

        public IEnumerable<Player> MostRushingYards()
        {
            var yard = playerRepo.GetAll().Max(x => x.Stat.RushingYards);
            var mostRuYard = from x in playerRepo.GetAll()
                             where x.Stat.RushingYards == yard
                             select x;
            return mostRuYard;
        }

        public IEnumerable<Player> MostTouchdowns()
        {
            var yard = playerRepo.GetAll().Max(x => x.Stat.Touchdowns);
            var mostTD = from x in playerRepo.GetAll()
                             where x.Stat.Touchdowns == yard
                             select x;
            return mostTD;
        }

        public IEnumerable<Player> PlayersByTeam(string name)
        {
            if (!TheSame(name))
            {
                throw new ItDoesNotExist($"The team with the name: {name} does not exist..");
            }
            var team = from x in playerRepo.GetAll()
                        where x.Teams.TeamName == name
                        select x;
            return team;
        }
        bool TheSame(string name)
        {
            bool notTheSame = false;
            foreach (var item in playerRepo.GetAll())
            {
                if (item.Teams.TeamName == name)
                {
                    notTheSame = true;
                }
            }
            return notTheSame;
        }
        #endregion
    }
}
