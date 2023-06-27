using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TransectionRepository:ITransectionRepository
    {

        private readonly ProductDbContext _dbContext;

        public TransectionRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Transection> GetAllTransection()
        {
            return _dbContext.Transections;
        }

        public Transection GetTransectionById(int id)
        {
            return _dbContext.Transections.Find(id);
        }

        public void AddTransection(Transection Transections)
        {
            _dbContext.Transections.Add(Transections);
            _dbContext.SaveChanges();
        }

        public void UpdateTransection(Transection Transections)
        {
            _dbContext.Transections.Update(Transections);
            _dbContext.SaveChanges();
        }

        public void DeleteTransection(int id)
        {
            var Transection = _dbContext.Transections.Find(id);
            if (Transection != null)
            {
                _dbContext.Transections.Remove(Transection);
                _dbContext.SaveChanges();
            }
        }
    }
}
