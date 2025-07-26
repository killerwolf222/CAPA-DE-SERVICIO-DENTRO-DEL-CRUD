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
    public class MemberService : IMemberService
    {
        private readonly AppDbContext _context;

        public MemberService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateAsync(MemberDto dto)
        {
            var member = new Member
            {
                Name = dto.Name ?? string.Empty,
                Phone = dto.Phone,
                RegistrationDate = DateTime.Now
            };

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return ServiceResult.SuccessResult("Miembro creado correctamente");
        }

        public async Task<List<MemberDto>> GetAllAsync()
        {
            return await _context.Members
                .Select(m => new MemberDto
                {
                    Name = m.Name,
                    Phone = m.Phone ?? string.Empty
                }).ToListAsync();
        }

        public async Task<MemberDto> GetByIdAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null) return null;

            return new MemberDto
            {
                Name = member.Name,
                Phone = member.Phone ?? string.Empty
            };
        }

        public async Task<ServiceResult> UpdateAsync(int id, MemberDto dto)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null) return ServiceResult.Failure("Miembro no encontrado");

            member.Name = dto.Name ?? string.Empty;
            member.Phone = dto.Phone;

            _context.Members.Update(member);
            await _context.SaveChangesAsync();

            return ServiceResult.SuccessResult("Miembro actualizado correctamente");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null) return ServiceResult.Failure("Miembro no encontrado");

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return ServiceResult.SuccessResult("Miembro eliminado correctamente");
        }
    }
}
