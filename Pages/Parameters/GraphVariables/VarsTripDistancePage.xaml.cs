namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsTripDistancePage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsTripDistancePage()
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

    if (Preferences.Get("GraphTripDistanceAutoMaxMin", "false") == "true")
    {
      GraphTripDistanceAutoMaxMin.IsToggled = true;
      GraphTripDistanceAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphTripDistanceAutoMaxMin.IsToggled = false;
      GraphTripDistanceAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphTripDistanceMin.Text = Preferences.Get("GraphTripDistanceMin", "0");
    GraphTripDistanceMax.Text = Preferences.Get("GraphTripDistanceMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphTripDistanceThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphTripDistanceThresholds", "36")) GraphTripDistanceThresholds.SelectedIndex = i;
    }

    GraphTripDistanceYellowMaxThreshold.Text = Preferences.Get("GraphTripDistanceYellowMaxThreshold", "0");
    GraphTripDistanceRedMaxThreshold.Text = Preferences.Get("GraphTripDistanceRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphTripDistanceAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphTripDistanceAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphTripDistanceAutoMaxMin", "true");
      GraphTripDistanceAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphTripDistanceAutoMaxMin", "false");
      GraphTripDistanceAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphTripDistanceAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphTripDistanceMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphTripDistanceMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphTripDistanceMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphTripDistanceMin.TextColor != Colors.Red && GraphTripDistanceMin.Text.Length != 0)
    {
      Preferences.Set("GraphTripDistanceMin", GraphTripDistanceMin.Text);
    }
  }

  private void GraphTripDistanceMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphTripDistanceMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphTripDistanceMin", GraphTripDistanceMin.Text);

      //dismiss keyboard
      GraphTripDistanceMin.IsEnabled = false;
      GraphTripDistanceMin.IsEnabled = true;
    }
  }

  private async void GraphTripDistanceMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphTripDistanceMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphTripDistanceMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphTripDistanceMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphTripDistanceMax.TextColor != Colors.Red && GraphTripDistanceMax.Text.Length != 0)
    {
      Preferences.Set("GraphTripDistanceMax", GraphTripDistanceMax.Text);
    }
  }

  private void GraphTripDistanceMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphTripDistanceMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphTripDistanceMax", GraphTripDistanceMax.Text);
      //dismiss keyboard
      GraphTripDistanceMax.IsEnabled = false;
      GraphTripDistanceMax.IsEnabled = true;
    }
  }

  private async void GraphTripDistanceMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphTripDistanceThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphTripDistanceThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphTripDistanceThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphTripDistanceYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphTripDistanceYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphTripDistanceYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphTripDistanceYellowMaxThreshold.TextColor != Colors.Yellow && GraphTripDistanceYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphTripDistanceYellowMaxThreshold", GraphTripDistanceYellowMaxThreshold.Text);
    }
  }

  private void GraphTripDistanceYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphTripDistanceYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphTripDistanceYellowMaxThreshold", GraphTripDistanceYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphTripDistanceYellowMaxThreshold.IsEnabled = false;
      GraphTripDistanceYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphTripDistanceYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphTripDistanceRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphTripDistanceRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphTripDistanceRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphTripDistanceRedMaxThreshold.TextColor != Colors.Red && GraphTripDistanceRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphTripDistanceRedMaxThreshold", GraphTripDistanceRedMaxThreshold.Text);
    }
  }

  private void GraphTripDistanceRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphTripDistanceRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphTripDistanceRedMaxThreshold", GraphTripDistanceRedMaxThreshold.Text);

      //dismiss keyboard
      GraphTripDistanceRedMaxThreshold.IsEnabled = false;
      GraphTripDistanceRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphTripDistanceRedMaxThresholdlabelTapped(object sender, EventArgs e)
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