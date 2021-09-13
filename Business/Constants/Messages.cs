using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //static newlemeden kullanmamıza olanak verir
    {
        public static string BrandAdded="Marka eklendi.";
        public static string BrandNameInvalid="İsim geçersiz.";
        public static string MaintenanceTime="Sistem bakımda.";
        public static string BrandsListed="Markalar listelendi.";
        public static string DescriptionTooShort="Açıklama çok kısa!";
        public static string RentDateInvalid="Kiralama tarihi geçersiz veya boş.";
        public static string RentalAdded="Kiralama işlemi başarılı.";
        public static string Success="Başarılı.";
        public static string Error="Hata.";
    }
}
