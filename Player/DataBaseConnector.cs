using Microsoft.Extensions.Configuration;
using Npgsql;
using System.IO;

namespace Player;

public class DataBaseConnector
{
    string connectionString;
    public DataBaseConnector()
    {
        var builder = new ConfigurationBuilder().
                          SetBasePath(Directory.GetCurrentDirectory()).
                          AddJsonFile("C:\\Users\\Ivar\\Desktop\\Склад\\Programming\\C#\\Player\\Player\\appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configurate = builder.Build();

        connectionString = configurate.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException();
    }
    public bool ConnectionToDataBase()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                return true;
            }
            catch 
            { 
                return false;
            }
        }
    }

}
