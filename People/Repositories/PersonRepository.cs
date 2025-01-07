using Microsoft.UI.Xaml.Hosting;
using People.Interfaces;
using People.Models;
using SQLite;

namespace People;

public class PersonRepository:ICVPersonRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    private SQLiteAsyncConnection velascoConn;
    private async Task Init()
    {
        if (velascoConn != null)
            return;
        velascoConn=new SQLiteAsyncConnection(_dbPath);
        await velascoConn.CreateTableAsync<CVPerson>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    public async Task AddNewPerson(string name)
    {            
        int result = 0;
        try
        {
            await Init();

            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            result = await velascoConn.InsertAsync(new CVPerson { Name=name});

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }

    public async Task<List<CVPerson>> GetAllPeople()
    {
        try
        {
            await Init ();
            return await velascoConn.Table<CVPerson>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<CVPerson>();
    }
}
