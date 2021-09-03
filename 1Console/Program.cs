using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace _1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            //CarManagerAddTest();
            //CarManagerTest2();

        }

        private static void CarManagerTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarManagerAddTest()
        {
            Car car1 = new Car { BrandId = 1, ColorId = 1, DailyPrice = 500, Description = "aynen", ModelYear = 2015 };


            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.ModelYear);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }
    }
}
