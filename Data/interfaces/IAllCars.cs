using Site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }

        IEnumerable<Car>GetFavCars{ get;  }

        Car GetobjectCar(int CarID);
    }
}
