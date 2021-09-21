using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity); // Car için doğrulama yapacağım çalışacağım tip ise (car) veya hangi entity kullanılacaksa....
            var result = validator.Validate(context); //carvalidator kullanarak ilgili context'i yani car ı doğrula demek
            if (!result.IsValid) //result geçerli değil ise
            {
                throw new ValidationException(result.Errors); //hata fırlat
            }
        }
    }
}
