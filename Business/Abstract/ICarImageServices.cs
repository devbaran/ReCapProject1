using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageServices
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int id);
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile formFile,CarImage carImage);
        IResult Update(IFormFile formFile, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
