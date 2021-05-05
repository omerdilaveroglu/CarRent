using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentContext>, IRentalDal
    {
        public bool CheckCantRentable(int id)
        {
            using (CarRentContext context = new CarRentContext())
            {
                bool checkRentable = context.Set<Rental>().Any(p => p.CarId == id && p.ReturnDate == null);
                return checkRentable;
            }
        }

        public bool CheckCar(int id)
        {
            using (CarRentContext context = new CarRentContext())
            {
                bool checkCar = context.Set<Car>().Any(p => p.CarId == id);
                return checkCar;
            }
        }
    }
}
