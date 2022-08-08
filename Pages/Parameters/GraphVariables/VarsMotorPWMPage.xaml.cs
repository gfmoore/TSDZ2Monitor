namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsMotorPWMPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsMotorPWMPage()
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

    if (Preferences.Get("GraphMotorPWMAutoMaxMin", "false") == "true")
    {
      GraphMotorPWMAutoMaxMin.IsToggled = true;
      GraphMotorPWMAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphMotorPWMAutoMaxMin.IsToggled = false;
      GraphMotorPWMAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphMotorPWMMin.Text = Preferences.Get("GraphMotorPWMMin", "0");
    GraphMotorPWMMax.Text = Preferences.Get("GraphMotorPWMMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphMotorPWMThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphMotorPWMThresholds", "36")) GraphMotorPWMThresholds.SelectedIndex = i;
    }

    GraphMotorPWMYellowMaxThreshold.Text = Preferences.Get("GraphMotorPWMYellowMaxThreshold", "0");
    GraphMotorPWMRedMaxThreshold.Text = Preferences.Get("GraphMotorPWMRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphMotorPWMAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPWMAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphMotorPWMAutoMaxMin", "true");
      GraphMotorPWMAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphMotorPWMAutoMaxMin", "false");
      GraphMotorPWMAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphMotorPWMAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphMotorPWMMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPWMMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPWMMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPWMMin.TextColor != Colors.Red && GraphMotorPWMMin.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPWMMin", GraphMotorPWMMin.Text);
    }
  }

  private void GraphMotorPWMMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPWMMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorPWMMin", GraphMotorPWMMin.Text);

      //dismiss keyboard
      GraphMotorPWMMin.IsEnabled = false;
      GraphMotorPWMMin.IsEnabled = true;
    }
  }

  private async void GraphMotorPWMMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphMotorPWMMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPWMMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPWMMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPWMMax.TextColor != Colors.Red && GraphMotorPWMMax.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPWMMax", GraphMotorPWMMax.Text);
    }
  }

  private void GraphMotorPWMMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPWMMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorPWMMax", GraphMotorPWMMax.Text);
      //dismiss keyboard
      GraphMotorPWMMax.IsEnabled = false;
      GraphMotorPWMMax.IsEnabled = true;
    }
  }

  private async void GraphMotorPWMMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphMotorPWMThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphMotorPWMThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphMotorPWMThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphMotorPWMYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPWMYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPWMYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPWMYellowMaxThreshold.TextColor != Colors.Yellow && GraphMotorPWMYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPWMYellowMaxThreshold", GraphMotorPWMYellowMaxThreshold.Text);
    }
  }

  private void GraphMotorPWMYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPWMYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphMotorPWMYellowMaxThreshold", GraphMotorPWMYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorPWMYellowMaxThreshold.IsEnabled = false;
      GraphMotorPWMYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorPWMYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphMotorPWMRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorPWMRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorPWMRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorPWMRedMaxThreshold.TextColor != Colors.Red && GraphMotorPWMRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorPWMRedMaxThreshold", GraphMotorPWMRedMaxThreshold.Text);
    }
  }

  private void GraphMotorPWMRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorPWMRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorPWMRedMaxThreshold", GraphMotorPWMRedMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorPWMRedMaxThreshold.IsEnabled = false;
      GraphMotorPWMRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorPWMRedMaxThresholdlabelTapped(object sender, EventArgs e)
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