using System.Collections.Generic;
using System.Threading.Tasks;
using MICRUDGABRIEL.Core;   // para ServiceResult
using MICRUDGABRIEL.Dtos;   // para MemberDto

namespace MICRUDGABRIEL.Contract
{
    public interface IMemberService
    {
        Task<ServiceResult> CreateAsync(MemberDto dto);
        Task<List<MemberDto>> GetAllAsync();
        Task<MemberDto> GetByIdAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, MemberDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
