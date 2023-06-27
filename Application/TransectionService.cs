using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TransectionService: ITransectionService
    {
        private readonly ITransectionRepository _TransectionReposity;

        public TransectionService(ITransectionRepository ITransectionRepositorys)
        {
            _TransectionReposity = ITransectionRepositorys;
        }
        public IEnumerable<Transection> GetAllTransection()
        {
            return _TransectionReposity.GetAllTransection();
        }

        public Transection GetTransectionById(int id)
        {
            return _TransectionReposity.GetTransectionById(id);
        }

        public void AddTransection(Transection Transections)
        {
             _TransectionReposity.AddTransection(Transections);
        }

        public void UpdateTransection(Transection Transections)
        {
            _TransectionReposity.UpdateTransection(Transections);
        }

        public void DeleteTransection(int id)
        {
            _TransectionReposity.DeleteTransection(id);
        }




    }
}
