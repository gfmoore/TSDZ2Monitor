namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsBatteryVoltagePage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsBatteryVoltagePage()
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
    checkInput = false;  //stop activating text changed events

    if (Preferences.Get("GraphBatteryVoltageAutoMaxMin", "false") == "true")
    {
      GraphBatteryVoltageAutoMaxMin.IsToggled = true;
      GraphBatteryVoltageAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphBatteryVoltageAutoMaxMin.IsToggled = false;
      GraphBatteryVoltageAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphBatteryVoltageMin.Text = Preferences.Get("GraphBatteryVoltageMin", "0");
    GraphBatteryVoltageMax.Text = Preferences.Get("GraphBatteryVoltageMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphBatteryVoltageThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphBatteryVoltageThresholds", "36")) GraphBatteryVoltageThresholds.SelectedIndex = i;
    }

    GraphBatteryVoltageYellowMaxThreshold.Text = Preferences.Get("GraphBatteryVoltageYellowMaxThreshold", "0");
    GraphBatteryVoltageRedMaxThreshold.Text = Preferences.Get("GraphBatteryVoltageRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphBatteryVoltageAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryVoltageAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphBatteryVoltageAutoMaxMin", "true");
      GraphBatteryVoltageAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphBatteryVoltageAutoMaxMin", "false");
      GraphBatteryVoltageAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphBatteryVoltageAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphBatteryVoltageMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryVoltageMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryVoltageMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryVoltageMin.TextColor != Colors.Red && GraphBatteryVoltageMin.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryVoltageMin", GraphBatteryVoltageMin.Text);
    }
  }

  private void GraphBatteryVoltageMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryVoltageMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatteryVoltageMin", GraphBatteryVoltageMin.Text);

      //dismiss keyboard
      GraphBatteryVoltageMin.IsEnabled = false;
      GraphBatteryVoltageMin.IsEnabled = true;
    }
  }

  private async void GraphBatteryVoltageMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphBatteryVoltageMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryVoltageMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryVoltageMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryVoltageMax.TextColor != Colors.Red && GraphBatteryVoltageMax.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryVoltageMax", GraphBatteryVoltageMax.Text);
    }
  }

  private void GraphBatteryVoltageMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryVoltageMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatteryVoltageMax", GraphBatteryVoltageMax.Text);
      //dismiss keyboard
      GraphBatteryVoltageMax.IsEnabled = false;
      GraphBatteryVoltageMax.IsEnabled = true;
    }
  }

  private async void GraphBatteryVoltageMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphBatteryVoltageThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphBatteryVoltageThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphBatteryVoltageThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphBatteryVoltageYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryVoltageYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryVoltageYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryVoltageYellowMaxThreshold.TextColor != Colors.Yellow && GraphBatteryVoltageYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryVoltageYellowMaxThreshold", GraphBatteryVoltageYellowMaxThreshold.Text);
    }
  }

  private void GraphBatteryVoltageYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryVoltageYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphBatteryVoltageYellowMaxThreshold", GraphBatteryVoltageYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphBatteryVoltageYellowMaxThreshold.IsEnabled = false;
      GraphBatteryVoltageYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphBatteryVoltageYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphBatteryVoltageRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryVoltageRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryVoltageRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryVoltageRedMaxThreshold.TextColor != Colors.Red && GraphBatteryVoltageRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryVoltageRedMaxThreshold", GraphBatteryVoltageRedMaxThreshold.Text);
    }
  }

  private void GraphBatteryVoltageRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryVoltageRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatteryVoltageRedMaxThreshold", GraphBatteryVoltageRedMaxThreshold.Text);

      //dismiss keyboard
      GraphBatteryVoltageRedMaxThreshold.IsEnabled = false;
      GraphBatteryVoltageRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphBatteryVoltageRedMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for red color.", "OK");
  }




  //----------helpers--------------------------------------------------
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

  public static bool CheckDecimal(string t)
  {
    bool validNumber = true;
    if (!Regex.IsMatch(t, @"^[+-]?\d+(\.\d+)?$"))
    {
      validNumber = false;
    }
    return validNumber;
  }
}