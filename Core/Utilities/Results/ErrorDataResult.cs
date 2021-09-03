using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //alttaki ikisi pek kullanılmaz 
        public ErrorDataResult(string message) : base(default, false, message) //sadece mesaj ve data yok, o yüzden default gönderilir data yerine...
        {

        }
        public ErrorDataResult() : base(default, false) //base e hiçbişey gönderilmiyor.
        {

        }
    }
}
