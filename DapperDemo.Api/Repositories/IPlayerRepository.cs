using DapperDemo.Api.Models;

namespace DapperDemo.Api.Repositories;

public interface IPlayerRepository
{
    Task CreatePlayerAsync(PlayerUpdateModel player);
    Task DeletePlayerAsync(int id);
    Task<Player?> GetPlayerAsync(int id);
    Task<IEnumerable<Player>> GetPlayersAsync();
    Task UpdatePlayerAsync(int id, PlayerUpdateModel player);
}