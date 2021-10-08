using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageServices
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.UtcNow;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            
            return new SuccessDataResult<List<CarImage>>(CheckNullImage(carId).Data);


        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=> c.Id==id));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var oldPath = carImage.ImagePath;
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c=> c.Id==carImage.Id).ImagePath,formFile);
            carImage.Date = DateTime.UtcNow;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimit(int id)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (carImageCount>5)
            {
                return new ErrorResult(Messages.LimitExceeded);
            }
            return new SuccessResult();
        }


        private IDataResult<List<CarImage>> CheckNullImage(int id)
        {
            try
            {
                string path = @"\images\default.jpg";
                var carImageCount = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!carImageCount)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));


        }
    }
}





