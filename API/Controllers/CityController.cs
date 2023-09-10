using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.CategoryDtos;
using EindomsHavnAPI.Repositories.AboutRepository;
using EindomsHavnAPI.Repositories.CategoryRepository;
using EindomsHavnAPI.Repositories.CityRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
       private readonly ICityRepository _cityRepository;


       public CityController(ICityRepository cityRepository)
       {
              _cityRepository = cityRepository;
       }

       [HttpGet]
        public async Task<IActionResult> GetAllCityWithCount()
        {
            var result = await _cityRepository.GetCitiesWithCount();
            return Ok(result);
        }
    }
}
