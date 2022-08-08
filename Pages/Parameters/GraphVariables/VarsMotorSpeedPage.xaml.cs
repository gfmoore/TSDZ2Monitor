namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsMotorSpeedPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsMotorSpeedPage()
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

    if (Preferences.Get("GraphMotorSpeedAutoMaxMin", "false") == "true")
    {
      GraphMotorSpeedAutoMaxMin.IsToggled = true;
      GraphMotorSpeedAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphMotorSpeedAutoMaxMin.IsToggled = false;
      GraphMotorSpeedAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphMotorSpeedMin.Text = Preferences.Get("GraphMotorSpeedMin", "0");
    GraphMotorSpeedMax.Text = Preferences.Get("GraphMotorSpeedMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphMotorSpeedThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphMotorSpeedThresholds", "36")) GraphMotorSpeedThresholds.SelectedIndex = i;
    }

    GraphMotorSpeedYellowMaxThreshold.Text = Preferences.Get("GraphMotorSpeedYellowMaxThreshold", "0");
    GraphMotorSpeedRedMaxThreshold.Text = Preferences.Get("GraphMotorSpeedRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphMotorSpeedAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorSpeedAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphMotorSpeedAutoMaxMin", "true");
      GraphMotorSpeedAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphMotorSpeedAutoMaxMin", "false");
      GraphMotorSpeedAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphMotorSpeedAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphMotorSpeedMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorSpeedMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorSpeedMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorSpeedMin.TextColor != Colors.Red && GraphMotorSpeedMin.Text.Length != 0)
    {
      Preferences.Set("GraphMotorSpeedMin", GraphMotorSpeedMin.Text);
    }
  }

  private void GraphMotorSpeedMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorSpeedMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorSpeedMin", GraphMotorSpeedMin.Text);

      //dismiss keyboard
      GraphMotorSpeedMin.IsEnabled = false;
      GraphMotorSpeedMin.IsEnabled = true;
    }
  }

  private async void GraphMotorSpeedMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphMotorSpeedMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorSpeedMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorSpeedMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorSpeedMax.TextColor != Colors.Red && GraphMotorSpeedMax.Text.Length != 0)
    {
      Preferences.Set("GraphMotorSpeedMax", GraphMotorSpeedMax.Text);
    }
  }

  private void GraphMotorSpeedMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorSpeedMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorSpeedMax", GraphMotorSpeedMax.Text);
      //dismiss keyboard
      GraphMotorSpeedMax.IsEnabled = false;
      GraphMotorSpeedMax.IsEnabled = true;
    }
  }

  private async void GraphMotorSpeedMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphMotorSpeedThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphMotorSpeedThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphMotorSpeedThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphMotorSpeedYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorSpeedYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphMotorSpeedYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorSpeedYellowMaxThreshold.TextColor != Colors.Yellow && GraphMotorSpeedYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorSpeedYellowMaxThreshold", GraphMotorSpeedYellowMaxThreshold.Text);
    }
  }

  private void GraphMotorSpeedYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorSpeedYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphMotorSpeedYellowMaxThreshold", GraphMotorSpeedYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorSpeedYellowMaxThreshold.IsEnabled = false;
      GraphMotorSpeedYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorSpeedYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphMotorSpeedRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorSpeedRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorSpeedRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorSpeedRedMaxThreshold.TextColor != Colors.Red && GraphMotorSpeedRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorSpeedRedMaxThreshold", GraphMotorSpeedRedMaxThreshold.Text);
    }
  }

  private void GraphMotorSpeedRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorSpeedRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorSpeedRedMaxThreshold", GraphMotorSpeedRedMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorSpeedRedMaxThreshold.IsEnabled = false;
      GraphMotorSpeedRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorSpeedRedMaxThresholdlabelTapped(object sender, EventArgs e)
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