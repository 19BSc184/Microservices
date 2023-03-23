using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPi.Models;
using ReservationAPi.Repository;
using ReservationAPi.Repository.IRepository;

namespace ReservationAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            var reservations = await _reservationRepository.GetReservations();
            return reservations;
        }
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            await _reservationRepository.UpdateMailStatus(id);
        }

    }
}
