namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsHumanPowerPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsHumanPowerPage()
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

    if (Preferences.Get("GraphHumanPowerAutoMaxMin", "false") == "true")
    {
      GraphHumanPowerAutoMaxMin.IsToggled = true;
      GraphHumanPowerAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphHumanPowerAutoMaxMin.IsToggled = false;
      GraphHumanPowerAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphHumanPowerMin.Text = Preferences.Get("GraphHumanPowerMin", "0");
    GraphHumanPowerMax.Text = Preferences.Get("GraphHumanPowerMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphHumanPowerThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphHumanPowerThresholds", "36")) GraphHumanPowerThresholds.SelectedIndex = i;
    }

    GraphHumanPowerYellowMaxThreshold.Text = Preferences.Get("GraphHumanPowerYellowMaxThreshold", "0");
    GraphHumanPowerRedMaxThreshold.Text = Preferences.Get("GraphHumanPowerRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphHumanPowerAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphHumanPowerAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphHumanPowerAutoMaxMin", "true");
      GraphHumanPowerAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphHumanPowerAutoMaxMin", "false");
      GraphHumanPowerAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphHumanPowerAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphHumanPowerMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphHumanPowerMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphHumanPowerMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphHumanPowerMin.TextColor != Colors.Red && GraphHumanPowerMin.Text.Length != 0)
    {
      Preferences.Set("GraphHumanPowerMin", GraphHumanPowerMin.Text);
    }
  }

  private void GraphHumanPowerMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphHumanPowerMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphHumanPowerMin", GraphHumanPowerMin.Text);

      //dismiss keyboard
      GraphHumanPowerMin.IsEnabled = false;
      GraphHumanPowerMin.IsEnabled = true;
    }
  }

  private async void GraphHumanPowerMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphHumanPowerMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphHumanPowerMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphHumanPowerMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphHumanPowerMax.TextColor != Colors.Red && GraphHumanPowerMax.Text.Length != 0)
    {
      Preferences.Set("GraphHumanPowerMax", GraphHumanPowerMax.Text);
    }
  }

  private void GraphHumanPowerMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphHumanPowerMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphHumanPowerMax", GraphHumanPowerMax.Text);
      //dismiss keyboard
      GraphHumanPowerMax.IsEnabled = false;
      GraphHumanPowerMax.IsEnabled = true;
    }
  }

  private async void GraphHumanPowerMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphHumanPowerThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphHumanPowerThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphHumanPowerThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphHumanPowerYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphHumanPowerYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphHumanPowerYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphHumanPowerYellowMaxThreshold.TextColor != Colors.Yellow && GraphHumanPowerYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphHumanPowerYellowMaxThreshold", GraphHumanPowerYellowMaxThreshold.Text);
    }
  }

  private void GraphHumanPowerYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphHumanPowerYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphHumanPowerYellowMaxThreshold", GraphHumanPowerYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphHumanPowerYellowMaxThreshold.IsEnabled = false;
      GraphHumanPowerYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphHumanPowerYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphHumanPowerRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphHumanPowerRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphHumanPowerRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphHumanPowerRedMaxThreshold.TextColor != Colors.Red && GraphHumanPowerRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphHumanPowerRedMaxThreshold", GraphHumanPowerRedMaxThreshold.Text);
    }
  }

  private void GraphHumanPowerRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphHumanPowerRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphHumanPowerRedMaxThreshold", GraphHumanPowerRedMaxThreshold.Text);

      //dismiss keyboard
      GraphHumanPowerRedMaxThreshold.IsEnabled = false;
      GraphHumanPowerRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphHumanPowerRedMaxThresholdlabelTapped(object sender, EventArgs e)
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