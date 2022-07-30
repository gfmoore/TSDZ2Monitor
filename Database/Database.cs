namespace TSDZ2Monitor.Database;

public class Database
{
  private readonly SQLiteAsyncConnection _database;

  public Database(string dbPath)
  {
    _database = new SQLiteAsyncConnection(dbPath);

    CreateTableBluetoothPeripheralAsync();
    CreateTableTrackAsync();
  }

  public Task<int> DropTableBluetoothPeripheralAsync()
  {
    _database.DropTableAsync<BluetoothPeripheral>();
    return Task.FromResult(0);
  }

  public Task<int> CreateTableBluetoothPeripheralAsync()
  {
    _database.CreateTableAsync<BluetoothPeripheral>();
    return Task.FromResult(0);
  }

  public Task<List<BluetoothPeripheral>> GetBluetoothPeripheralsAsync()
  {
    return _database.Table<BluetoothPeripheral>().ToListAsync();
  }

  public Task<int> InsertBluetoothPeripheralAsync(BluetoothPeripheral bluetoothPeripheral)
  {
    return _database.InsertAsync(bluetoothPeripheral);
  }

  public Task<int> DeleteBluetoothPeripheralAsync(BluetoothPeripheral bluetoothPeripheral)
  {
    return _database.DeleteAsync(bluetoothPeripheral);
  }

  public Task<int> DeleteAllBluetoothPeripheralsAsync() => _database.DeleteAllAsync<BluetoothPeripheral>();

  public Task<List<BluetoothPeripheral>> Query(string query)
  {
    return null;
  }



  //Track table
  public Task<int> CreateTableTrackAsync()
  {
    _database.CreateTableAsync<Track>();
    return Task.FromResult(0);
  }

  public Task<List<Track>> GetTracksAsync()
  {
    return _database.Table<Track>().ToListAsync();
  }
   
  public Task<int> InsertTrackAsync(Track track)
  {
    return _database.InsertAsync(track);
  }

  public Task<int> DeleteTrackAsync(Track track)
  {
    return _database.DeleteAsync(track);
  }

  public Task<int> DeleteAllTrackAsync() => _database.DeleteAllAsync<Track>();

}

