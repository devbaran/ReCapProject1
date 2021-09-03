using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=98000,Description="Kazasız temiz"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2015,DailyPrice=165000,Description="Lokal boya yok, sıfır gibi."},
                new Car{Id=3,BrandId=2,ColorId=4,ModelYear=2007,DailyPrice=55000,Description="Sağ arka kapı boyalı."},
                new Car{Id=4,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=199000,Description="Sıfır km hiç kullanılmadı."}
            };
        }

        public void Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _cars.Add(car);
            }
            else
            {
                Console.WriteLine("HATA");
            }
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=> p.Id==car.Id);
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
            return _cars; //geçici
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=> c.Id== Id ).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
