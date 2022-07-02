namespace TSDZ2Monitor;

public partial class ControlMenuViewModel : ObservableObject
{
  [ObservableProperty]
  bool showMainMenu = true;

  [ObservableProperty]
  bool showParameters = false;

  [ObservableProperty]
  bool showAssistLevels = false;

  [ObservableProperty]
  bool showGraphParameters = false;

  [RelayCommand]
  public void DisplayMainMenu()
  {
    ShowMainMenu = false;
    ShowParameters = false;
    ShowAssistLevels = false;
    ShowGraphParameters = true;
  }

  [RelayCommand]
  public void DisplayParameters()
  {
    ShowMainMenu = !ShowMainMenu;
    ShowParameters = !ShowParameters;
    ShowAssistLevels = false;
    ShowGraphParameters = false;
  }

  [RelayCommand]
  public void DisplayAssistLevels()
  {
    ShowMainMenu = false;
    ShowParameters = !ShowParameters;
    ShowAssistLevels = !ShowAssistLevels;
    ShowGraphParameters = false;
  }

  [RelayCommand]
  public void DisplayGraphVariables()
  {
    ShowMainMenu = false;
    ShowParameters = !ShowParameters;
    ShowAssistLevels = false;
    ShowGraphParameters = !ShowGraphParameters;
    //AppShell.Current.CurrentItem = null;
    //AppShell.Current
  }


  private void DisplayMenuVars()
  {
    Console.WriteLine($"{ShowMainMenu} {ShowParameters} {ShowAssistLevels} {ShowGraphParameters}");
  }
}