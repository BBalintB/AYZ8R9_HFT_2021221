using AYZ8R9_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public class StatisticRepository : Repository<Statistic>, IStatisticRepository
    {
        public StatisticRepository(DbContext ctx) : base(ctx)
        {
        }

        public void ChangePassingyard(int id, int newPYards)
        {
            var stat = GetOne(id);
            stat.PassingYards = newPYards;
            ctx.SaveChanges();
        }

        public void ChangeRecievingyard(int id, int newReYards)
        {
            var stat = GetOne(id);
            stat.ReceivingYards = newReYards;
            ctx.SaveChanges();
        }

        public void ChangeRushingyard(int id, int newRuYards)
        {
            var stat = GetOne(id);
            stat.RushingYards = newRuYards;
            ctx.SaveChanges();
        }

        public void ChangeTouchdowns(int id, int newScore)
        {
            var stat = GetOne(id);
            stat.Touchdowns = newScore;
            ctx.SaveChanges();
        }

        public void Change(Statistic other)
        {
            var stat = GetOne(other.StatId);
            if (stat == null)
            {
                throw new ArgumentException("Item not exist...");
            }
            foreach (var item in stat.GetType().GetProperties())
            {
                if (item.GetAccessors().FirstOrDefault(t=>t.IsVirtual)==null)
                {
                    item.SetValue(stat, item.GetValue(other));
                }
            }
            ctx.SaveChanges();
        }

        public override void Create(Statistic NewStatistic)
        {
            ctx.Add(NewStatistic);
            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var stat = GetOne(id);
            ctx.Remove(stat);
            ctx.SaveChanges();
        }

        public override Statistic GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.StatId == id);
        }
    }
}
