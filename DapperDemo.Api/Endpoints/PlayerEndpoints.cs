using DapperDemo.Api.Models;
using DapperDemo.Api.Repositories;

namespace DapperDemo.Api.Endpoints;

public static class PlayerEndpoints
{
    public static void MapPlayerEndpoints(this IEndpointRouteBuilder builder)
    {
        var playersGroup = builder.MapGroup("players");

        playersGroup.MapGet("", async (IPlayerRepository playerRepository) =>
        {
            var players = await playerRepository.GetPlayersAsync();
            return Results.Ok(players);
        });

        playersGroup.MapGet("{id}", async (int id, IPlayerRepository playerRepository) =>
        {
            var player = await playerRepository.GetPlayerAsync(id);

            return player is not null
                ? Results.Ok(player)
                : Results.NotFound();
        });

        playersGroup.MapPost("", async (PlayerUpdateModel player, IPlayerRepository playerRepository) =>
        {
            var id = await playerRepository.CreatePlayerAsync(player);
            return Results.Ok(id);
        });

        playersGroup.MapPut("{id}", async (int id, PlayerUpdateModel player, IPlayerRepository playerRepository) =>
        {
            await playerRepository.UpdatePlayerAsync(id, player);
            return Results.NoContent();
        });

        playersGroup.MapDelete("{id}", async (int id, IPlayerRepository playerRepository) =>
        {
            await playerRepository.DeletePlayerAsync(id);
            return Results.NoContent();
        });
    }
}
