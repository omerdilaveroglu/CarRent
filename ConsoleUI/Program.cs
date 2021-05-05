using DataAccess.Concrate.InMemory;
using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
            ////Ioc
            ////Data Transformation Object = DTOs
            //UserTest();


        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName);
                }
            }
        }

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " / " + car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
