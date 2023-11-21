using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required]
    [StringLength(50)]
    public required string Genre { get; set; }

    [Range(1, 1000)]
    public decimal Price { get; set; }

    public DateTime RealseDate { get; set; }

    [Url]
    [StringLength(100)]
    public required string ImageUri { get; set; }
}