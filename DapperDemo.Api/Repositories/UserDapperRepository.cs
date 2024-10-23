using Dapper;
using DapperDemo.Api.Models;

namespace DapperDemo.Api.Repositories;

public class UserDapperRepository(SqlConnectionFactory sqlConnectionFactory) : IPlayerRepository
{
    public async Task<IEnumerable<Player>> GetPlayersAsync()
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Players;";
        return await connection.QueryAsync<Player>(sql);
    }

    public async Task<Player?> GetPlayerAsync(int id)
    {
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
                SELECT * FROM Players
                WHERE Id = @Id;
            """;

        return await connection.QuerySingleOrDefaultAsync<Player>(sql, new { Id = id });
    }

    public async Task CreatePlayerAsync(PlayerUpdateModel player)
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        const string sql = """
            INSERT INTO Players (Firstname, Lastname, Age)
            VALUES (@Firstname, @Lastname, @Age);
        """;
        await connection.ExecuteAsync(sql, player);
    }

    public async Task UpdatePlayerAsync(int id, PlayerUpdateModel player)
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        const string sql = """
            UPDATE Players
            SET Firstname = @Firstname,
                Lastname = @Lastname,
                Age = @Age
            WHERE Id = @Id;
        """;
        await connection.ExecuteAsync(sql, new { Id = id, player.Firstname, player.Lastname, player.Age });
    }

    public async Task DeletePlayerAsync(int id)
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        const string sql = """
            DELETE FROM Players
            WHERE Id = @Id;
        """;
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}
