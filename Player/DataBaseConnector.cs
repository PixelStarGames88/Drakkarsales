using Microsoft.Extensions.Configuration;
using Npgsql;
using System.IO;

namespace Player;

public class DataBaseConnector
{
    string connectionString;
    UserObject user;
    public UserObject User
    {
        get 
        { 
           return user;
        } 
    }
    public DataBaseConnector()
    {
        user = new UserObject("", "", "", "");
        var builder = new ConfigurationBuilder().
                          SetBasePath(Directory.GetCurrentDirectory()).
                          AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        IConfiguration configurate = builder.Build();

        connectionString = configurate.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException();
    }
    private NpgsqlConnection GetConnection()
    {
        var conn = new NpgsqlConnection(connectionString);

        conn.Open();
        return conn;
    }
    public bool DataIsCorrect(string login, string password)
    {
        try
        {
            using (var conn = GetConnection())
            {
                string request = "SELECT * FROM program_user WHERE user_login = @login AND user_password = @password";
                using(var cmd = new NpgsqlCommand(request, conn))
                {
                    cmd.Parameters.AddWithValue("login", login.ToUpper());
                    cmd.Parameters.AddWithValue("password", password);

                    using var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = new UserObject(reader.GetString(0), reader.GetString(2), reader.GetString(1).Split(' ')[0], reader.GetString(1).Split(' ')[1]);
                        return true;
                    }
                    return false;
                }
            }
        }
        catch 
        { 
           return false;
        }
    }
    public bool CreateNewAccount(string login, string password, string firstName, string lastName)
    {
        try
        {
            using(var conn = GetConnection())
            {
                string request = @"INSERT INTO Program_User(user_name, user_login, user_password)
                                   VALUES(@name, @login, @password);";

                using var cmdInsert = new NpgsqlCommand(request, conn);

                cmdInsert.Parameters.AddWithValue("@name", (firstName + " " + lastName).ToUpper());
                cmdInsert.Parameters.AddWithValue("@password", password);
                cmdInsert.Parameters.AddWithValue("@login", login.ToUpper());

                cmdInsert.ExecuteNonQuery();
                user = new UserObject(login, password, firstName, lastName);

                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}
