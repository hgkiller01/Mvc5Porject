using Mvc5Porject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc5Porject.Adapter.InterFace
{
    public interface IDessertAdapter
    {
        List<Dessert> GetList();
        bool Create(Dessert dessert);
        bool Update(Dessert dessert);
        bool Delete(int dessertID);
    }
}
