namespace TSDZ2Monitor.Pages.Parameters;

public partial class VariousPage : ContentPage
{
  public bool switchEventDisable = true; //need to stop IsToggled event when first loading preferences
  public bool checkInput = false;
  
  public List<string> variousLightsConfiguration;

  public VariousPage()
	{
		InitializeComponent();

    //display Metric(SI) or Imperial
    if (Preferences.Get("VariousUnits", "Metric") == "Metric")
    {
      VariousUnits.ThumbColor = Colors.Blue;
      VariousUnits.IsToggled = true;
    }
    else
    {
      VariousUnits.ThumbColor = Colors.Green;
      VariousUnits.IsToggled = false;
    }

    variousLightsConfiguration = new() 
    { 
      "0 - on", 
      "1 - flashing", 
      "2 - on and fast flashing when braking",
      "3 - flashing and on when braking",
      "4 - flashing and fast flashing when braking",
      "5 - on and on during braking also with light control OFF",
      "6 - on and fast flashing when braking even with the light control OFF",
      "7 - flashing and switched on when braking even with the light control OFF",
      "8 - flashing and fast flashing when braking even with the light control OFF",
    };
    VariousLightsConfiguration.ItemsSource = variousLightsConfiguration;
    for (int i = 0; i < variousLightsConfiguration.Count; i++)
    {
      if (variousLightsConfiguration[i] == Preferences.Get("VariousLightsConfiguration", "0 - on")) VariousLightsConfiguration.SelectedIndex = i;
    }

    if (Preferences.Get("VariousAssistWithError", "false") == "true")
    {
      VariousAssistWithError.IsToggled = true;
      VariousAssistWithError.ThumbColor = Colors.Green;
    }
    else
    {
      VariousAssistWithError.IsToggled = false;
      VariousAssistWithError.ThumbColor = Colors.Red;
    }

    checkInput = false;  //stop activating text changed events
    VariousVirtualThrottleStep.Text = Preferences.Get("VariousVirtualThrottleStep", "20");
    checkInput = true;



    switchEventDisable = false;
  }



  //-------Various Units------------------------------------------------
  private void VariousUnits_Toggled(object sender, EventArgs e)
  {
    if (switchEventDisable) return; //on first set up of page

    if (VariousUnits.IsToggled)  //Metric
    {
      Preferences.Set("VariousUnits", "Metric");
      VariousUnits.ThumbColor = Colors.Blue;
    }
    else  //Imperial
    {
      Preferences.Set("VariousUnits", "Imperial");
      VariousUnits.ThumbColor = Colors.Green;
    }
  }

  private async void VariousUnitsLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The system units are stored internally as Metric (SI), but will be displayed in Imperial by fliiping the switch.", "OK");
  }


  //-------------Various Lights Configuration-------------------------------
  private void VariousLightsConfiguration_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("VariousLightsConfiguration", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnVariousLightsConfigurationLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Choose your preferred mode from the 9 available. The braking modes are only available with the brake sensors installed.", "OK");
  }


  //-------Various Assist With Error------------------------------------------------
  private void VariousAssistWithError_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (VariousAssistWithError.IsToggled)
    {
      Preferences.Set("VariousAssistWithError", "true");
      VariousAssistWithError.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("VariousAssistWithError", "false");
      VariousAssistWithError.ThumbColor = Colors.Red;
    }
  }

  private async void OnVariousAssistWithErrorlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The presence of an error\r\ndisables assistance in all modes.\r\nIt is however possible to force assistance even with an error if this is caused by a problem with a sensor. Torque, cadence or speed sensor.\r\nYou will have to choose the assistance mode that does not involve the use of the faulty sensor.\r\nUse only in case of need, with this function enabled there are limitations in assistance. See error codes below.\r\n", "OK");
  }


  //-------Virtual Throttle Step------------------------------------------------
  private void VariousVirtualThrottleStep_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    VariousVirtualThrottleStep.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) VariousVirtualThrottleStep.TextColor = Colors.LightGreen;

    //not > 200??
    if (VariousVirtualThrottleStep.TextColor != Colors.Red && int.Parse(VariousVirtualThrottleStep.Text) > 200)
    {
      VariousVirtualThrottleStep.TextColor = Colors.Red;
    }

    if (VariousVirtualThrottleStep.TextColor != Colors.Red && VariousVirtualThrottleStep.Text.Length != 0)
    {
      Preferences.Set("VariousVirtualThrottleStep", VariousVirtualThrottleStep.Text);
    }
  }

  private void VariousVirtualThrottleStep_Completed(object sender, EventArgs e)
  {
    if (VariousVirtualThrottleStep.TextColor != Colors.Red && VariousVirtualThrottleStep.Text.Length != 0)
    {
      Preferences.Set("VariousVirtualThrottleStep", VariousVirtualThrottleStep.Text);
    }

    //dismiss keyboard
    VariousVirtualThrottleStep.IsEnabled = false;
    VariousVirtualThrottleStep.IsEnabled = true;
  }

  private async void OnVariousVirtualThrottleStepLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Amount steps for each increase and decrease of\r\nVirtual throttle. (0 to 100 for throttle)\r\n", "OK");
  }


  //----------Helper functions--------------------------------------
  public static bool CheckNumeric(string t)
  {
    bool validNumber = true;
    if (!Regex.IsMatch(t, @"^\d+$"))
    {
      validNumber = false;
    }
    //no leading 0
    if (t.Length > 1 && t[0] == '0')
    {
      validNumber = false;
    }
    return validNumber;
  }
}