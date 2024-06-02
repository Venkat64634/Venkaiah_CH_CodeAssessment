using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public IVehicleService _VehicleService;
        public VehicleController(IVehicleService VehicleService)
        {
            _VehicleService = VehicleService;
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var myListJson = HttpContext.Session.GetString("vehicleList");
            if (myListJson != null)
            {
                var lVehicleFromSession = JsonConvert.DeserializeObject<List<Vehicle>>(myListJson) ?? new List<Vehicle>();
                if (lVehicleFromSession != null && lVehicleFromSession.Count() > 0)
                {
                    return lVehicleFromSession;
                }
            }

            return _VehicleService.GetAllVehicles();
        }

        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status404NotFound)]
        [HttpGet]
        public Vehicle GetVehicleInfo(int id)
        {
            return _VehicleService.GetVehicle(id);
        }

        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult SaveVehicle(Vehicle vehicle)
        {
            try
            {
                _VehicleService.SaveVehicle(vehicle);
                // Since we dont have database save, to display the newly added records, Persist into session.
                List<Vehicle> lVehicle = _VehicleService.GetAllVehicles();
                HttpContext.Session.SetString("vehicleList", JsonConvert.SerializeObject(lVehicle));
                //return Ok();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
