using ReservationAPi.Data;
using ReservationAPi.Models;
using ReservationAPi.Repository.IRepository;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace ReservationAPi.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppliactionDbContext _context;
        public ReservationRepository(AppliactionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task UpdateMailStatus(int id)
        {
            var reservationInDb = await _context.Reservations.FindAsync(id);
            if (reservationInDb != null && reservationInDb.IsMailSent == false)
            {
                var smtpClient = new SmtpClient("smtp.mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("yesbychance@outlook.com", ""),
                    EnableSsl = true
                };
                smtpClient.Send("yesbychance@outlook.com", reservationInDb.Email, "Vehicle Test Drive", "Hello Message !!!");
                await _context.SaveChangesAsync();
            }
        }
    }
}
