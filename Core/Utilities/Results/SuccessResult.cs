using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result //inheritance
    {
        public SuccessResult(string message):base(true,message)
        {
            //base e true gönderdik çünkü success result, ve mesajımızı gönderdik.
        }
        public SuccessResult():base(true)
        {
            //tek parametreli, mesaj yok sadece true.
        }
    }
}
