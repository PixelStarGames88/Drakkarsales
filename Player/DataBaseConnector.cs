using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IO;

namespace Player;

public class DataBaseConnector
{
    string supabaseURl;
    string supabaseKey;

    Supabase.Client supabase;

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

        supabaseURl = configurate.GetConnectionString("UrlConnection") ?? throw new NullReferenceException();
        supabaseKey = configurate.GetConnectionString("KeyConnection") ?? throw new NullReferenceException();

        supabase = new Supabase.Client(supabaseURl, supabaseKey);
    }
    private async void GetConnection()
    {
        await supabase.InitializeAsync();
    }
    public async Task<bool> DataIsCorrect(string login, string password)
    {
        try
        {
            GetConnection();

            login = login.ToUpper();

            var request = await supabase
                                .From<ProgramUser>()
                                .Where(s => s.Password == password && s.Login == login)
                                .Get();

            foreach (var currentUser in request.Models)
            {
                if (currentUser.Password == password && currentUser.Login == login)
                {
                    string firstName = currentUser.Name.Split(' ')[0] ?? throw new NullReferenceException();
                    string lastName = currentUser.Name.Split(' ')[1] ?? throw new NullReferenceException();
                    user = new UserObject(currentUser.Login, currentUser.Password, firstName, lastName);
                    return true;
                }
            }

            return false;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> CreateNewAccount(string login, string password, string firstName, string lastName)
    {
        try
        {
            GetConnection();

            var programUser = new ProgramUser { Login = login.ToUpper(), Password = password, Name = (firstName + " " + lastName).ToUpper() };

            await supabase.From<ProgramUser>().Insert(programUser);
            user = new UserObject(login.ToUpper(), password, firstName.ToUpper(), lastName.ToUpper());

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAccount(string login)
    {
        try
        {
            GetConnection();

            await supabase.From<ProgramUser>().Where(s => s.Login == login).Delete();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAccount(string login, string password, string firstName, string lastName)
    {
        try
        {
            GetConnection();

            await supabase
                .From<ProgramUser>()
                .Where(s => s.Login == user.Login)
                .Set(s => s.Login, login.ToUpper())
                .Set(s => s.Password, password)
                .Set(s => s.Name, (firstName + " " + lastName).ToUpper())
                .Update();

            user = new UserObject(login.ToUpper(), password, firstName.ToUpper(), lastName.ToUpper());

            return true;

        }
        catch
        {
            return false;
        }
    }
    public void ClearCurrentAccount()
    {
        user = new UserObject("", "", "", "");
    }
}
