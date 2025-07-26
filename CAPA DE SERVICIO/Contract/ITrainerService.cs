using System.Collections.Generic;
using System.Threading.Tasks;
using MICRUDGABRIEL.Core;   // Para ServiceResult
using MICRUDGABRIEL.Dtos;   // Para TrainerDto

namespace MICRUDGABRIEL.Contract
{
    public interface ITrainerService
    {
        Task<ServiceResult> CreateAsync(TrainerDto dto);
        Task<List<TrainerDto>> GetAllAsync();
        Task<TrainerDto> GetByIdAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, TrainerDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
