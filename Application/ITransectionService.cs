using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ITransectionService
    {
        IEnumerable<Transection> GetAllTransection();
        Transection GetTransectionById(int id);
        void AddTransection(Transection Transections);
        void UpdateTransection(Transection Transections);
        void DeleteTransection(int id);
    }
}
