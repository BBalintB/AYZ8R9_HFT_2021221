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
                if (item == player)
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
            if (id > playerRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            return playerRepo.GetOne(id);
        }
        #endregion
        
    }
}
