﻿using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic
{
    public interface IPlayerLogic
    {
        //crud
        Player GetPlayer(int id);
        void CreatePlayer(Player NewPlayer);
        void Delete(int id);
        void ChangeName(int id, string newName);
        void ChangeJerseyNumber(int id, int number);
        void ChangePlayer(Player player);
        IEnumerable<Player> GetAllPlayers();
        //non-crud
        IEnumerable<Player> MostReceivingYards();
        IEnumerable<Player> MostPassingYards();
        IEnumerable<Player> MostRushingYards();
        IEnumerable<Player> MostTouchdowns();
        IEnumerable<Player> PlayersByTeam(string name);

    }
}
