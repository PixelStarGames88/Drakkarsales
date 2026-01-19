using ASP_Connection.Models;

namespace ASP_Connection.Services;

public class DataBaseConnector
{
    Supabase.Client supabase;

    public DataBaseConnector(IConfiguration configuration)
    {
        var supabaseURl = configuration.GetConnectionString("UrlConnection") ?? throw new NullReferenceException();
        var supabaseKey = configuration.GetConnectionString("KeyConnection") ?? throw new NullReferenceException();

        supabase = new Supabase.Client(supabaseURl, supabaseKey);
    }
    private async void GetConnection()
    {
        await supabase.InitializeAsync();
    }
    public async Task<ProgramUser?> DataIsCorrect(string login, string password)
    {
        try
        {
            GetConnection();

            login = login.ToUpper();

            var request = await supabase
                                .From<ProgramUser>()
                                .Where(s => s.Password == password && s.Login == login)
                                .Get();

            return request.Models.FirstOrDefault();
        }
        catch
        {
            return null;
        }
    }
    public async Task<ProgramUser?> CreateNewAccount(string login, string password, string firstName, string lastName)
    {
        try
        {
            GetConnection();

            var programUser = new ProgramUser { Login = login.ToUpper(), Password = password, Name = (firstName + " " + lastName).ToUpper() };

            await supabase.From<ProgramUser>().Insert(programUser);

            return programUser;
        }
        catch
        {
            return null;
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

    public async Task<ProgramUser?> UpdateAccount(string currentLogin, string login, string password, string firstName, string lastName)
    {
        try
        {
            GetConnection();

            var request = await supabase
                .From<ProgramUser>()
                .Where(s => s.Login == currentLogin)
                .Set(s => s.Login, login.ToUpper())
                .Set(s => s.Password, password)
                .Set(s => s.Name, (firstName + " " + lastName).ToUpper())
                .Update();

            return request.Models.FirstOrDefault();

        }
        catch
        {
            return null;
        }
    }
}