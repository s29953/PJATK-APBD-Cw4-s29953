using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw4_s29953.Models;

public class ComponentManufacturer
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = null!;

    public DateOnly FoundationDate { get; set; }

    public ICollection<Component> Components { get; set; } = new List<Component>();
}