using InterceuticalsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceuticalsService.Dao
{
    public interface IProduct
    {
        List<Product> GetProducts(int id);
    }
}
