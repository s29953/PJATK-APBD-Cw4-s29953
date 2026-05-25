using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s29953.Data;
using PJATK_APBD_Cw4_s29953.DTOs;
using PJATK_APBD_Cw4_s29953.Models;

namespace PJATK_APBD_Cw4_s29953.Services;

public class PCService : IPCService
{
    private readonly AppDbContext _context;

    public PCService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PCResponseDto>> GetAllAsync()
    {
        return await _context.PCs
            .Select(pc => new PCResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PCComponentResponseDto>?> GetComponentsByPcIdAsync(int id)
    {
        var pcExists = await _context.PCs.AnyAsync(pc => pc.Id == id);

        if (!pcExists)
            return null;

        return await _context.PCComponents
            .Where(pc => pc.PCId == id)
            .Select(pc => new PCComponentResponseDto
            {
                Code = pc.Component.Code,
                Name = pc.Component.Name,
                Description = pc.Component.Description,
                Amount = pc.Amount,
                ComponentType = pc.Component.ComponentType.Name,
                Manufacturer = pc.Component.ComponentManufacturer.FullName
            })
            .ToListAsync();
    }

    public async Task<PCResponseDto> CreateAsync(PCRequestDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return new PCResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, PCRequestDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);

        if (pc == null)
            return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);

        if (pc == null)
            return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();

        return true;
    }
}