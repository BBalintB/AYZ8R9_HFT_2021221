using AYZ8R9_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext ctx):base(ctx){/**/}
        public void ChangeName(int id, string newName)
        {
            var player = GetOne(id);
            player.PlayerName = newName;
            ctx.SaveChanges();
        }

        public void ChangeJerseyNumber(int id, int number)
        {
            var player = GetOne(id);
            player.PlayerJerseyNumber = number;
            ctx.SaveChanges();
        }

        public override void Create(Player NewPlayer)
        {
            ctx.Add(NewPlayer);
            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var player = GetOne(id);
            ctx.Remove(player);
            ctx.SaveChanges();
        }

        public override Player GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.PlayerId == id);
        }
    }
}
