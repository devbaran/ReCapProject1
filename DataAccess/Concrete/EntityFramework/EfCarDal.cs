using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join col in context.Colors
                             on car.ColorId equals col.Id
                             join br in context.Brands
                             on car.BrandId equals br.Id
                             select new CarDetailDto { CarName = br.Name, ColorName = col.Name, DailyPrice = car.DailyPrice };
                return result.ToList();
            }
        }
    }
}
