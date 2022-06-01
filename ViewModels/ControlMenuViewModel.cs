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

  public ICommand ShowParametersCommand => new Command(ChangeMenuControl);
  public void ChangeMenuControl()
  {
    Console.WriteLine($"Before {ShowMainMenu} {ShowParameters} {ShowAssistLevels} {ShowGraphParameters}");
    ShowMainMenu = !ShowMainMenu;
    ShowParameters = !ShowParameters;
    Console.WriteLine($"After  {ShowMainMenu} {ShowParameters}  {ShowAssistLevels} {ShowGraphParameters}");
  }
}
