namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsWattsPerKmPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsWattsPerKmPage()
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

    if (Preferences.Get("GraphWattsPerKmAutoMaxMin", "false") == "true")
    {
      GraphWattsPerKmAutoMaxMin.IsToggled = true;
      GraphWattsPerKmAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphWattsPerKmAutoMaxMin.IsToggled = false;
      GraphWattsPerKmAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphWattsPerKmMin.Text = Preferences.Get("GraphWattsPerKmMin", "0");
    GraphWattsPerKmMax.Text = Preferences.Get("GraphWattsPerKmMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphWattsPerKmThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphWattsPerKmThresholds", "36")) GraphWattsPerKmThresholds.SelectedIndex = i;
    }

    GraphWattsPerKmYellowMaxThreshold.Text = Preferences.Get("GraphWattsPerKmYellowMaxThreshold", "0");
    GraphWattsPerKmRedMaxThreshold.Text = Preferences.Get("GraphWattsPerKmRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphWattsPerKmAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphWattsPerKmAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphWattsPerKmAutoMaxMin", "true");
      GraphWattsPerKmAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphWattsPerKmAutoMaxMin", "false");
      GraphWattsPerKmAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphWattsPerKmAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphWattsPerKmMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphWattsPerKmMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphWattsPerKmMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphWattsPerKmMin.TextColor != Colors.Red && GraphWattsPerKmMin.Text.Length != 0)
    {
      Preferences.Set("GraphWattsPerKmMin", GraphWattsPerKmMin.Text);
    }
  }

  private void GraphWattsPerKmMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphWattsPerKmMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphWattsPerKmMin", GraphWattsPerKmMin.Text);

      //dismiss keyboard
      GraphWattsPerKmMin.IsEnabled = false;
      GraphWattsPerKmMin.IsEnabled = true;
    }
  }

  private async void GraphWattsPerKmMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphWattsPerKmMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphWattsPerKmMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphWattsPerKmMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphWattsPerKmMax.TextColor != Colors.Red && GraphWattsPerKmMax.Text.Length != 0)
    {
      Preferences.Set("GraphWattsPerKmMax", GraphWattsPerKmMax.Text);
    }
  }

  private void GraphWattsPerKmMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphWattsPerKmMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphWattsPerKmMax", GraphWattsPerKmMax.Text);
      //dismiss keyboard
      GraphWattsPerKmMax.IsEnabled = false;
      GraphWattsPerKmMax.IsEnabled = true;
    }
  }

  private async void GraphWattsPerKmMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphWattsPerKmThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphWattsPerKmThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphWattsPerKmThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphWattsPerKmYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphWattsPerKmYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphWattsPerKmYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphWattsPerKmYellowMaxThreshold.TextColor != Colors.Yellow && GraphWattsPerKmYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphWattsPerKmYellowMaxThreshold", GraphWattsPerKmYellowMaxThreshold.Text);
    }
  }

  private void GraphWattsPerKmYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphWattsPerKmYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphWattsPerKmYellowMaxThreshold", GraphWattsPerKmYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphWattsPerKmYellowMaxThreshold.IsEnabled = false;
      GraphWattsPerKmYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphWattsPerKmYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphWattsPerKmRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphWattsPerKmRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphWattsPerKmRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphWattsPerKmRedMaxThreshold.TextColor != Colors.Red && GraphWattsPerKmRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphWattsPerKmRedMaxThreshold", GraphWattsPerKmRedMaxThreshold.Text);
    }
  }

  private void GraphWattsPerKmRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphWattsPerKmRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphWattsPerKmRedMaxThreshold", GraphWattsPerKmRedMaxThreshold.Text);

      //dismiss keyboard
      GraphWattsPerKmRedMaxThreshold.IsEnabled = false;
      GraphWattsPerKmRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphWattsPerKmRedMaxThresholdlabelTapped(object sender, EventArgs e)
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