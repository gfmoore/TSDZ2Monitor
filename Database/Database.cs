namespace TSDZ2Monitor.Database;

public class Database
{
  private readonly SQLiteAsyncConnection _database;

  public Database(string dbPath)
  {
    _database = new SQLiteAsyncConnection(dbPath);

    CreateTableBluetoothPeripheralAsync();
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

  public Task<int> SaveBluetoothPeripheralAsync(BluetoothPeripheral bluetoothPeripheral)
  {
    return _database.InsertAsync(bluetoothPeripheral);
  }

  public Task<int> DeleteBluetoothPeripheralAsync(BluetoothPeripheral bluetoothPeripheral)
  {
    return _database.DeleteAsync(bluetoothPeripheral);
  }

}

