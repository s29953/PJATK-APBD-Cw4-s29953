using PJATK_APBD_Cw4_s29953.DTOs;

namespace PJATK_APBD_Cw4_s29953.Services;

public interface IPCService
{
    Task<IEnumerable<PCResponseDto>> GetAllAsync();

    Task<IEnumerable<PCComponentResponseDto>?> GetComponentsByPcIdAsync(int id);

    Task<PCResponseDto> CreateAsync(PCRequestDto dto);

    Task<bool> UpdateAsync(int id, PCRequestDto dto);

    Task<bool> DeleteAsync(int id);
}