
using GameStore.Api.Entities;

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

app.Run();
