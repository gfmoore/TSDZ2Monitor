namespace TSDZ2Monitor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    Application.Current.UserAppTheme = AppTheme.Dark;

  }

  //public void ForcePageLayout()
  //{
  //  (MainPage as IView).InvalidateArrange();
  //}
}
