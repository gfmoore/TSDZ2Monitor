namespace TSDZ2Monitor;

public partial class App : Application
{
	public App()
	{
	  InitializeComponent();
	  //initialise database before use
      var database = Database;
	  
	  MainPage = new AppShell();
      Application.Current.UserAppTheme = AppTheme.Dark;

  }

  //setup database
  private static Database.Database database;
  private readonly static string filename = "TSDZ2.db3";
  public static Database.Database Database
  {
    get
    {
      if (database == null)
      {
        database = new Database.Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename));
      }
      return database;
    }
  }
}
