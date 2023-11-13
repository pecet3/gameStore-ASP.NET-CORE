namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required string Genre { get; set; }
    public decimal Price { get; set; }

    public DateTime RealseDate { get; set; }

    public required string ImageUri { get; set; }
}