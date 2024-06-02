using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public IAnimalService _animalService;
        //private readonly IHttpContextAccessor _httpContextAccessor; , IHttpContextAccessor httpContextAccessor
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
            //_httpContextAccessor = httpContextAccessor;
        }

        [ProducesResponseType(typeof(AnimalInfo), StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<AnimalInfo> GetAllAnimals()
        {
            var myListJson = HttpContext.Session.GetString("animalInfoList");
            if (myListJson != null)
            {
                var lAnimalInfoFromSession = JsonConvert.DeserializeObject<List<AnimalInfo>>(myListJson) ?? new List<AnimalInfo>();
                if (lAnimalInfoFromSession != null && lAnimalInfoFromSession.Count() > 0)
                {
                    return lAnimalInfoFromSession;
                }
            }
            
            return _animalService.GetAllAnimalInfo();
        }

        [ProducesResponseType(typeof(AnimalInfo), StatusCodes.Status404NotFound)]
        [HttpGet]
        public AnimalInfo GetAnimalInfo(int id)
        {
            return _animalService.GetAnimalInfo(id);
        }

        [ProducesResponseType(typeof(AnimalInfo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult SaveAnimalInfo(AnimalInfo animalInfo)
        {
            try
            {
                _animalService.SaveAnimalInfo(animalInfo);
                //var session = _httpContextAccessor.HttpContext.Session;
                List<AnimalInfo> lAnimalInfo = _animalService.GetAllAnimalInfo();
                //lAnimalInfo.Add(animalInfo);
                HttpContext.Session.SetString("animalInfoList", JsonConvert.SerializeObject(lAnimalInfo));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
