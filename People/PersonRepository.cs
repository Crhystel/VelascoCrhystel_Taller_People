using People.Models;
using SQLite;

namespace People;

public class PersonRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection
    private SQLiteConnection velascoConn;
    private void Init()
    {
        if (velascoConn != null)
            return;
        velascoConn=new SQLiteConnection(_dbPath);
        velascoConn.CreateTable<CVPerson>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    public void AddNewPerson(string name)
    {            
        int result = 0;
        try
        {
            Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            // TODO: Insert the new person into the database
            result = velascoConn.Insert(new CVPerson { Name=name});

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }

    public List<CVPerson> GetAllPeople()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            Init ();
            return velascoConn.Table<CVPerson>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<CVPerson>();
    }
}
