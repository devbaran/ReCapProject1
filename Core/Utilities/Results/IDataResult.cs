using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //veri içerdiği için tip gerekli <T>
    {
        T Data { get; }
        //diğerleri IResult'dan geliyor


    }
}
