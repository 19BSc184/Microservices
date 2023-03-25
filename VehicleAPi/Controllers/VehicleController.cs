using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAPi.Models;
using VehicleAPi.Repository.IRepository;

namespace VehicleAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Vehicle>>Get()
        {
            return  await _vehicleRepository.GetVehicles();
        }
        [HttpGet("{id}")]
        public async Task<Vehicle>Get(int id)
        {
            return await _vehicleRepository.GetVehicleById(id);
        }
        [HttpPost]
        public async Task Post([FromBody] Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicle(vehicle);
        }

        
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleRepository.UpdateVehicle(id, vehicle);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleRepository.DeleteVehicle(id);
        }

    }
}
