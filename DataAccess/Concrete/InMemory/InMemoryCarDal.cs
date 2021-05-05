using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryCarDal : ICarDal    // bu kısımda sanki bellekte, veritabanında veri varmıi gibi veriler oluşturucaz.
    {
        List<Car> _cars;       // bir liste oluşturucam ve listede Car class'ını kullanacağım.
        public InMemoryCarDal() // bellekte referans aldığı zaman çalışıcak olan blok  = Generate Constructor
        {
            _cars = new List<Car>
            {
               new Car{CarId = 1, CarName= "Passat", BrandId= 1, ColorId= 1, DailyPrice = 200, Description = "Otomatik", ModelYear = 2020},
               new Car{CarId = 2, CarName= "320", BrandId= 3, ColorId= 4, DailyPrice = 300, Description = "Otomatik", ModelYear = 2020},
               new Car{CarId = 3, CarName= "A5", BrandId= 2, ColorId= 5, DailyPrice = 400, Description = "Otomatik", ModelYear = 2018},
               new Car{CarId = 7, CarName= "A7", BrandId= 2, ColorId= 2, DailyPrice = 600, Description = "Otomatik", ModelYear = 2019},
               new Car{CarId = 5, CarName= "A180", BrandId= 8, ColorId= 1, DailyPrice = 350, Description = "Otomatik", ModelYear = 2017}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // LINQ = Language Integrated Query
            // Lambda = p=>
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);  // referans Id sini yakaladık (Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul)
            _cars.Remove(carToDelete);         
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList(); // Where = içindeki şartlara uyan bitin varlıkları yeni bir liste haline getirir ve onu yapar.
        }

        public List<CarDetailDto> GetCarDetailDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarName = car.CarName;              // Listedeki gönderdiğim CarName'in adını göderdiğim car'ın adı yapabilirsin.
            carToUpdate.BrandId = car.BrandId;              // Listedeki gönderdiğim BrandId'in id'sini göderdiğim brand'ın id'si yapabilirsin.
            carToUpdate.Description = car.Description;      
            carToUpdate.DailyPrice = car.DailyPrice;           

        }
    }
}
