namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsMotorPowerPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsMotorPowerPage()
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

    if (Preferences.Get("GraphMotorPowerAutoMaxMin", "false") == "true")
    {
      GraphMotorPowerAutoMaxMin.IsToggled = true;
      GraphMotorPowerAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphMotorPowerAutoMaxMin.IsToggled = false;
      GraphMotorPowerAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphMotorPowerMin.Text = Preferences.Get("GraphMotorPowerMin", "0");
    GraphMotorPowerMax.Text = Preferences.Get("GraphMotorPowerMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphMotorPowerThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphMotorPowerThresholds", "36")) GraphMotorPowerThresholds.SelectedIndex = i;
    }

    GraphMotorPowerYellowMaxThreshold.Text = Preferences.Get("GraphMotorPowerYellowMaxThreshold", "0");
    GraphMotorPowerRedMaxThreshold.Text = Preferences.Get("GraphMotorPowerRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphMotorPowerAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPowerAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphMotorPowerAutoMaxMin", "true");
      GraphMotorPowerAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphMotorPowerAutoMaxMin", "false");
      GraphMotorPowerAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphMotorPowerAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphMotorPowerMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPowerMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPowerMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPowerMin.TextColor != Colors.Red && GraphMotorPowerMin.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPowerMin", GraphMotorPowerMin.Text);
    }
  }

  private void GraphMotorPowerMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPowerMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorPowerMin", GraphMotorPowerMin.Text);

      //dismiss keyboard
      GraphMotorPowerMin.IsEnabled = false;
      GraphMotorPowerMin.IsEnabled = true;
    }
  }

  private async void GraphMotorPowerMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphMotorPowerMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPowerMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPowerMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPowerMax.TextColor != Colors.Red && GraphMotorPowerMax.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPowerMax", GraphMotorPowerMax.Text);
    }
  }

  private void GraphMotorPowerMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPowerMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorPowerMax", GraphMotorPowerMax.Text);
      //dismiss keyboard
      GraphMotorPowerMax.IsEnabled = false;
      GraphMotorPowerMax.IsEnabled = true;
    }
  }

  private async void GraphMotorPowerMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphMotorPowerThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphMotorPowerThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphMotorPowerThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphMotorPowerYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPowerYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPowerYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPowerYellowMaxThreshold.TextColor != Colors.Yellow && GraphMotorPowerYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPowerYellowMaxThreshold", GraphMotorPowerYellowMaxThreshold.Text);
    }
  }

  private void GraphMotorPowerYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPowerYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphMotorPowerYellowMaxThreshold", GraphMotorPowerYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorPowerYellowMaxThreshold.IsEnabled = false;
      GraphMotorPowerYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorPowerYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphMotorPowerRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPowerRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPowerRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPowerRedMaxThreshold.TextColor != Colors.Red && GraphMotorPowerRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPowerRedMaxThreshold", GraphMotorPowerRedMaxThreshold.Text);
    }
  }

  private void GraphMotorPowerRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPowerRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorPowerRedMaxThreshold", GraphMotorPowerRedMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorPowerRedMaxThreshold.IsEnabled = false;
      GraphMotorPowerRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorPowerRedMaxThresholdlabelTapped(object sender, EventArgs e)
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