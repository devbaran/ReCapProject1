using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //burada artık voidlere IResult datalara ise IDataResult verilecek
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
