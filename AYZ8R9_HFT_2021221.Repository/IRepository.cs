using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T NewLine); //add new line
        T GetOne(int id);//read one line by id
        IQueryable<T> GetAll();//read all lines
        void Delete(int id);//delete line by id
    }
}
