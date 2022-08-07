namespace TSDZ2Monitor.Pages.Parameters;

public partial class AssistLevelPage : ContentPage
{
  public bool checkValues = false;
  public List<string> assistLevelsNumberOfAssistLevels;
  public AssistLevelPage()
	{
		InitializeComponent();
	}

  protected override void OnAppearing()
  {
    base.OnAppearing();

    Setup();
  }

  public void Setup()
  {
    checkValues = false;

    assistLevelsNumberOfAssistLevels = new() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    AssistLevelsNumberOfAssistLevels.ItemsSource = assistLevelsNumberOfAssistLevels;
    string numberOfAssistLevels = Preferences.Get("AssistLevelsNumberOfAssistLevels", "3");
    for (int i = 0; i < assistLevelsNumberOfAssistLevels.Count; i++)
    {
      if (assistLevelsNumberOfAssistLevels[i] == numberOfAssistLevels) AssistLevelsNumberOfAssistLevels.SelectedIndex = i;
    }

    checkValues = true;

  }


  //-------------Assist levels Number of Assist Levels-------------------------------
  private void AssistLevelsNumberOfAssistLevels_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("AssistLevelsNumberOfAssistLevels", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnAssistLevelsNumberOfAssistLevelsLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Select the desired number of assist levels from a minimum of 1 to a maximum of 9. If you choose for instance 5, only the first 5 levels will be available.", "OK");
  }

}