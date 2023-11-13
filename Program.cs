
using GameStore.Api.Entities;

const string GetGameEndpointGame = "GetGame";

List<Game> games = new()
{
    new Game(){
        Id=1,
        Name="Minecraft",
        Genre="Sandbox",
        Price= 19.99M,
        RealseDate= new DateTime(2011,11,1),
        ImageUri ="https://placehold.co/100"
    },
       new Game(){
        Id=2,
        Name="Counter Strike 2",
        Genre="FPS",
        Price= 9.99M,
        RealseDate= new DateTime(2021,10,1),
        ImageUri ="https://placehold.co/100"
    },
       new Game(){
        Id=3,
        Name="Grand Theft Auto V",
        Genre="Sandbox",
        Price= 39.99M,
        RealseDate= new DateTime(2013,7,10),
        ImageUri ="https://placehold.co/100"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);

    if (game is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
}).WithName(GetGameEndpointGame);

app.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointGame, new { id = game.Id }, game);
});

app.MapPut("/games/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.RealseDate = updatedGame.RealseDate;

    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) =>
{
    Game? existingGame = games.Find(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    games.Remove(existingGame);

    return Results.NoContent();
});

app.Run();
