using MICRUDGABRIEL.Contract;
using MICRUDGABRIEL.Core;
using MICRUDGABRIEL.Data;
using MICRUDGABRIEL.Dtos;
using MICRUDGABRIEL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MICRUDGABRIEL.Service
{
    public class TrainerService : ITrainerService
    {
        private readonly AppDbContext _context;

        public TrainerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateAsync(TrainerDto dto)
        {
            var trainer = new Trainer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HireDate = DateTime.Now
            };

            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            return ServiceResult.SuccessResult("Entrenador creado correctamente");
        }

        public async Task<List<TrainerDto>> GetAllAsync()
        {
            return await _context.Trainers
                .Select(t => new TrainerDto
                {
                    FullName = t.FullName,
                    Email = t.Email,
                    PhoneNumber = t.PhoneNumber
                }).ToListAsync();
        }

        public async Task<TrainerDto> GetByIdAsync(int id)
        {
            var t = await _context.Trainers.FindAsync(id);
            if (t == null)
            {
                return new TrainerDto
                {
                    FullName = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty
                };
            }

            return new TrainerDto
            {
                FullName = t.FullName,
                Email = t.Email,
                PhoneNumber = t.PhoneNumber
            };
        }

        public async Task<ServiceResult> UpdateAsync(int id, TrainerDto dto)
        {
            var t = await _context.Trainers.FindAsync(id);
            if (t == null) return ServiceResult.Failure("Entrenador no encontrado");

            t.FullName = dto.FullName;
            t.Email = dto.Email;
            t.PhoneNumber = dto.PhoneNumber;

            await _context.SaveChangesAsync();

            return ServiceResult.SuccessResult("Entrenador actualizado correctamente");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var t = await _context.Trainers.FindAsync(id);
            if (t == null) return ServiceResult.Failure("Entrenador no encontrado");

            _context.Trainers.Remove(t);
            await _context.SaveChangesAsync();

            return ServiceResult.SuccessResult("Entrenador eliminado correctamente");
        }
    }
}
