using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)  //attributelara type ı böyle atıyoruz.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen validatorType bir IValidator değilse hata ver
            {
                throw new Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //onbefore içi bomboştu onu burda override ettik kullandık
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //burası reflection, çalışma anında newleme yani instance yaratır..
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //kullanılan validator ın çalışma tipini bul diyor, hangi entity kullanıyor...
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // invocation = method
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
