namespace PJATK_APBD_Cw4_s29953.DTOs;

public class PCComponentResponseDto
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Amount { get; set; }

    public string ComponentType { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;
}