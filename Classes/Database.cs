namespace TSDZ2Monitor.Classes;

public class Database
{
  private readonly SQLiteAsyncConnection _database;

  public Database(string dbPath)
  {
    _database = new SQLiteAsyncConnection(dbPath);

    CreateTableUsersAsync();
  }

  public Task<int> DropTableUsersAsync()
  {
    _database.DropTableAsync<User>();
    return Task.FromResult(0);
  }

  public Task<int> CreateTableUsersAsync()
  {
    _database.CreateTableAsync<User>();
    return Task.FromResult(0);
  }

  public Task<List<User>> GetUsersAsync()
  {
    return _database.Table<User>().ToListAsync();  
  }

  public Task<int>SaveUserAsync(User user)
  {
    return _database.InsertAsync(user);
  }

  public Task<int>DeleteUserAsync(User user)
  {
    return _database.DeleteAsync(user);
  }

}
