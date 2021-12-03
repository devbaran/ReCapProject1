using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string directory = Environment.CurrentDirectory + @"\wwwroot";
        public static string path = @"/images/";
        public static string Add(IFormFile formFile)
        {
            var sourcepath = Path.GetTempFileName();
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            var extension = Path.GetExtension(formFile.FileName);
            var newFileName = Guid.NewGuid().ToString("N") + extension;
            //The format parameter can be "N", "D", "B", "P", or "X". If format is null or an empty string (""), "D" is used.

            File.Move(sourcepath, directory + path + newFileName);
            return (path + newFileName).Replace("\\", "/");
        }
        public static IResult Delete(string oldPath)
        {
            path = (directory + oldPath).Replace("/", "\\");
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName);
            var newFileName = Guid.NewGuid().ToString("N") + extension;
            if (sourcePath.Length>0)
            {
                using (var stream= new FileStream(directory+path+newFileName,FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(directory + sourcePath);
            return (path + newFileName).Replace("\\", "/");
        }
    }
}
