using AYZ8R9_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public class TeamRepository : Repository<Team>,ITeamRepository
    {
        public TeamRepository(DbContext ctx) : base(ctx)
        {
        }

        public void Changecoach(int id, string newCoach)
        {
            var team = GetOne(id);
            team.HeadCoach = newCoach;
            ctx.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var team = GetOne(id);
            team.TeamName = newName;
            ctx.SaveChanges();
        }

        public override void Create(Team NewTeam)
        {
            ctx.Add(NewTeam);
            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var team = GetOne(id);
            ctx.Remove(team);
            ctx.SaveChanges();
        }

        public override Team GetOne(int id)
        {
            return GetAll().FirstOrDefault(x => x.TeamId == id);
        }
    }
}
