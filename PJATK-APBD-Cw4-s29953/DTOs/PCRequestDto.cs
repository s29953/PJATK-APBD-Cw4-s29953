using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw4_s29953.DTOs;

public class PCRequestDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public float Weight { get; set; }

    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Stock { get; set; }
}