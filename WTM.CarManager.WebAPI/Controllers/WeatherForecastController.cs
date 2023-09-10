using Microsoft.AspNetCore.Mvc;
using WTM.CarManager.Business.Domains.Models;
using WTM.CarManager.Business.Interfaces;
using WTM.CarManager.Infrasctructure.Repositories;

namespace WTM.CarManager.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private readonly IBrandRepository _brandRepository;
       private readonly IBrandService _brandService;

        public WeatherForecastController(IBrandRepository brandRepository, IBrandService brandService)
        {
            _brandRepository = brandRepository;
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = new Brand("Teste");
            model.IsActive();
            //await _brandRepository.Add(model);
            await _brandService.Add(model);


            var lista = await _brandRepository.GetAll();
            return Ok(lista);
        }

    }




}