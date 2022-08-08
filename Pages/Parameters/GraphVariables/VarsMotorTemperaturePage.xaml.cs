namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsMotorTemperaturePage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsMotorTemperaturePage()
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

    if (Preferences.Get("GraphMotorTemperatureAutoMaxMin", "false") == "true")
    {
      GraphMotorTemperatureAutoMaxMin.IsToggled = true;
      GraphMotorTemperatureAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphMotorTemperatureAutoMaxMin.IsToggled = false;
      GraphMotorTemperatureAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphMotorTemperatureMin.Text = Preferences.Get("GraphMotorTemperatureMin", "0");
    GraphMotorTemperatureMax.Text = Preferences.Get("GraphMotorTemperatureMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphMotorTemperatureThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphMotorTemperatureThresholds", "36")) GraphMotorTemperatureThresholds.SelectedIndex = i;
    }

    GraphMotorTemperatureYellowMaxThreshold.Text = Preferences.Get("GraphMotorTemperatureYellowMaxThreshold", "0");
    GraphMotorTemperatureRedMaxThreshold.Text = Preferences.Get("GraphMotorTemperatureRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphMotorTemperatureAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorTemperatureAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphMotorTemperatureAutoMaxMin", "true");
      GraphMotorTemperatureAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphMotorTemperatureAutoMaxMin", "false");
      GraphMotorTemperatureAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphMotorTemperatureAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphMotorTemperatureMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorTemperatureMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorTemperatureMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorTemperatureMin.TextColor != Colors.Red && GraphMotorTemperatureMin.Text.Length != 0)
    {
      Preferences.Set("GraphMotorTemperatureMin", GraphMotorTemperatureMin.Text);
    }
  }

  private void GraphMotorTemperatureMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorTemperatureMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorTemperatureMin", GraphMotorTemperatureMin.Text);

      //dismiss keyboard
      GraphMotorTemperatureMin.IsEnabled = false;
      GraphMotorTemperatureMin.IsEnabled = true;
    }
  }

  private async void GraphMotorTemperatureMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphMotorTemperatureMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorTemperatureMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorTemperatureMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorTemperatureMax.TextColor != Colors.Red && GraphMotorTemperatureMax.Text.Length != 0)
    {
      Preferences.Set("GraphMotorTemperatureMax", GraphMotorTemperatureMax.Text);
    }
  }

  private void GraphMotorTemperatureMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorTemperatureMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorTemperatureMax", GraphMotorTemperatureMax.Text);
      //dismiss keyboard
      GraphMotorTemperatureMax.IsEnabled = false;
      GraphMotorTemperatureMax.IsEnabled = true;
    }
  }

  private async void GraphMotorTemperatureMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphMotorTemperatureThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphMotorTemperatureThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphMotorTemperatureThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphMotorTemperatureYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorTemperatureYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphMotorTemperatureYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorTemperatureYellowMaxThreshold.TextColor != Colors.Yellow && GraphMotorTemperatureYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorTemperatureYellowMaxThreshold", GraphMotorTemperatureYellowMaxThreshold.Text);
    }
  }

  private void GraphMotorTemperatureYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorTemperatureYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphMotorTemperatureYellowMaxThreshold", GraphMotorTemperatureYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorTemperatureYellowMaxThreshold.IsEnabled = false;
      GraphMotorTemperatureYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorTemperatureYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphMotorTemperatureRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorTemperatureRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorTemperatureRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorTemperatureRedMaxThreshold.TextColor != Colors.Red && GraphMotorTemperatureRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorTemperatureRedMaxThreshold", GraphMotorTemperatureRedMaxThreshold.Text);
    }
  }

  private void GraphMotorTemperatureRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorTemperatureRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorTemperatureRedMaxThreshold", GraphMotorTemperatureRedMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorTemperatureRedMaxThreshold.IsEnabled = false;
      GraphMotorTemperatureRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorTemperatureRedMaxThresholdlabelTapped(object sender, EventArgs e)
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