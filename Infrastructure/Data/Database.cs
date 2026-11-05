using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    private static string connectionString = "Host=localhost;Port=5432;Database=booknest;Username=postgres;Password=907708429";
    public static NpgsqlConnection Connection() => new NpgsqlConnection(connectionString);
}
