using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool CheckCantRentable(int id);
        bool CheckCar(int id);
    }
}
