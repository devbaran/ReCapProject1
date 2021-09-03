using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {

        }

        //alttaki ikisi pek kullanılmaz 
        public SuccessDataResult(string message):base(default,true,message) //sadece mesaj ve data yok, o yüzden default gönderilir data yerine...
        {

        }
        public SuccessDataResult():base(default,true) //base e hiçbişey gönderilmiyor.
        {

        }
    }
}
