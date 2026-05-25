using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw4_s29953.Models;

public class ComponentType
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    public ICollection<Component> Components { get; set; } = new List<Component>();
}