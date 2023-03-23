using ReservationAPi.Models;

namespace ReservationAPi.Repository.IRepository
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservations();
        Task UpdateMailStatus(int id);
    }
}
