using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageServices _carImageServices;


        public CarImagesController(ICarImageServices carImageServices)
        {
            _carImageServices = carImageServices;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageServices.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile formFile)
        {
            var result = _carImageServices.Add(formFile, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var carImage = _carImageServices.GetById(id);
            var result = _carImageServices.Delete(carImage.Data);


            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile formFile)
        {
            var result = _carImageServices.Update(formFile, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
    }
}
