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

  public ICommand ShowMainMenuCommand => new Command(ShowMainMenuControl);
  public void ShowMainMenuControl()
  {
    ShowMainMenu = false;
    ShowParameters = false;
    ShowAssistLevels = false;
    ShowGraphParameters = true;
  }

  public ICommand ShowParametersCommand => new Command(ShowParametersControl);
  public void ShowParametersControl()
  {
    ShowMainMenu = !ShowMainMenu;
    ShowParameters = !ShowParameters;
    ShowAssistLevels = false;
    ShowGraphParameters = false;
  }

  public ICommand ShowAssistLevelsCommand => new Command(ShowAssistLevelControl);
  public void ShowAssistLevelControl()
  {
    ShowMainMenu = false;
    ShowParameters = !ShowParameters;
    ShowAssistLevels = !ShowAssistLevels;
    ShowGraphParameters = false;
  }
  public ICommand ShowGraphVariablesCommand => new Command(ShowGraphLevelsControl);
  public void ShowGraphLevelsControl()
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