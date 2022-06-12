using System.ComponentModel.DataAnnotations;

namespace Cw4;

public class Animal
{
    public int IdAnimal { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }
    [MinLength(5)]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Category { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Area { get; set; }
}