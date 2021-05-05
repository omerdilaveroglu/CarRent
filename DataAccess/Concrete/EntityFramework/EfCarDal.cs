using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from p in context.Cars          // veri tabınında bir Cars tablosu var bu tabloyu (p = takma isim)
                             join b in context.Brands        // veri tabanındaki Brands tablosuyla birliştir. (b = Takma isim)
                             on p.BrandId equals b.BrandId   // Cars tablosunun içindeki BrandId = Brands toblosunun içindeki BrandId demek
                             join c in context.Colors        // veri tabanındaki Colors tablosunuda birleştir. (c = takma isim)
                             on p.ColorId equals c.ColorId   // Cars tablosndaki ColorId = Colors tablosundaki ColorId'ye 
                             select new CarDetailDto
                             {
                                 CarName = p.CarName,       // Dto işte bunun için kullanılır, sadece buradaki verileri istiyoruz ama
                                 BrandName = b.BrandName,   // _hepsi farklı tablolarda bunun için biz bir "CarDetailDto" oluşturduk ve
                                 ColorName = c.ColorName,   // _sadece çekmek istediğimiz verileri yazdık. İstediklerimizde farklı 
                                 DailyPrice = p.DailyPrice  // _tablolarda olduğu için tabloları join ettik yani birleştirdik.
                             };
                return result.ToList();
            }    
        }
    }
}
