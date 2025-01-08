
using People.Interfaces;
using People.Models;
using SQLite;
using System;

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

    public async Task<bool> AgregarPersonAsync(CVPerson cvPerson)
    {            
        int result = 0;
        try
        {
            await Init();
            if (cvPerson == null || string.IsNullOrWhiteSpace(cvPerson.Name))
                throw new Exception("Valid name required");

            await velascoConn.InsertAsync(cvPerson);
            return true;

        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", ex.Message);
            return false;   
        }

    }

    public async Task<List<CVPerson>> GetAllPersonAsync()
    {
        try
        {
            await Init ();
            return await velascoConn.Table<CVPerson>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<CVPerson>();
    }
}
