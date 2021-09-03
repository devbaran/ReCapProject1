using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success) // ikili durum için 
        {
            Message = message; //getler ctor içinde set edilebilir
            //buraya success i yazmak yerine this diyerek alttaki ctora succesi yolladık çok kod yazmaktan kaçmış olduk kendimizi tekrar etmedik

        }
        public Result(bool success) //mesajsız durum için
        {
            Success = success;
        }
        //iki ctor : ctor overloading iki farklı imzaya sahibiz istediğimizi kullanabiliriz.
        public bool Success { get; }

        public string Message { get; }
    }
}
