using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw4_s29953.Models;

public class Component
{
    [Key]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public int ComponentManufacturerId { get; set; }

    public int ComponentTypeId { get; set; }

    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;

    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}