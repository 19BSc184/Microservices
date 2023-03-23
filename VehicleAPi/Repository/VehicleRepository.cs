﻿using Microsoft.EntityFrameworkCore;
using VehicleAPi.Data;
using VehicleAPi.Models;
using VehicleAPi.Repository.IRepository;

namespace VehicleAPi.Repository
{
    public class VehicleRepository: IVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicleInDb = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicleInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();

        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }

        public Task UpdateVehicle(int id, Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
