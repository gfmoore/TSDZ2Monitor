namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsBatteryCurrentPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsBatteryCurrentPage()
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

    if (Preferences.Get("GraphBatteryCurrentAutoMaxMin", "false") == "true")
    {
      GraphBatteryCurrentAutoMaxMin.IsToggled = true;
      GraphBatteryCurrentAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphBatteryCurrentAutoMaxMin.IsToggled = false;
      GraphBatteryCurrentAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphBatteryCurrentMin.Text = Preferences.Get("GraphBatteryCurrentMin", "0");
    GraphBatteryCurrentMax.Text = Preferences.Get("GraphBatteryCurrentMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphBatteryCurrentThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphBatteryCurrentThresholds", "36")) GraphBatteryCurrentThresholds.SelectedIndex = i;
    }

    GraphBatteryCurrentYellowMaxThreshold.Text = Preferences.Get("GraphBatteryCurrentYellowMaxThreshold", "0");
    GraphBatteryCurrentRedMaxThreshold.Text = Preferences.Get("GraphBatteryCurrentRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphBatteryCurrentAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryCurrentAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphBatteryCurrentAutoMaxMin", "true");
      GraphBatteryCurrentAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphBatteryCurrentAutoMaxMin", "false");
      GraphBatteryCurrentAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphBatteryCurrentAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphBatteryCurrentMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryCurrentMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryCurrentMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryCurrentMin.TextColor != Colors.Red && GraphBatteryCurrentMin.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryCurrentMin", GraphBatteryCurrentMin.Text);
    }
  }

  private void GraphBatteryCurrentMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryCurrentMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatteryCurrentMin", GraphBatteryCurrentMin.Text);

      //dismiss keyboard
      GraphBatteryCurrentMin.IsEnabled = false;
      GraphBatteryCurrentMin.IsEnabled = true;
    }
  }

  private async void GraphBatteryCurrentMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphBatteryCurrentMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryCurrentMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryCurrentMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryCurrentMax.TextColor != Colors.Red && GraphBatteryCurrentMax.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryCurrentMax", GraphBatteryCurrentMax.Text);
    }
  }

  private void GraphBatteryCurrentMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryCurrentMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatteryCurrentMax", GraphBatteryCurrentMax.Text);
      //dismiss keyboard
      GraphBatteryCurrentMax.IsEnabled = false;
      GraphBatteryCurrentMax.IsEnabled = true;
    }
  }

  private async void GraphBatteryCurrentMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphBatteryCurrentThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphBatteryCurrentThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphBatteryCurrentThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphBatteryCurrentYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryCurrentYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryCurrentYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryCurrentYellowMaxThreshold.TextColor != Colors.Yellow && GraphBatteryCurrentYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryCurrentYellowMaxThreshold", GraphBatteryCurrentYellowMaxThreshold.Text);
    }
  }

  private void GraphBatteryCurrentYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryCurrentYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphBatteryCurrentYellowMaxThreshold", GraphBatteryCurrentYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphBatteryCurrentYellowMaxThreshold.IsEnabled = false;
      GraphBatteryCurrentYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphBatteryCurrentYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphBatteryCurrentRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatteryCurrentRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatteryCurrentRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatteryCurrentRedMaxThreshold.TextColor != Colors.Red && GraphBatteryCurrentRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphBatteryCurrentRedMaxThreshold", GraphBatteryCurrentRedMaxThreshold.Text);
    }
  }

  private void GraphBatteryCurrentRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatteryCurrentRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatteryCurrentRedMaxThreshold", GraphBatteryCurrentRedMaxThreshold.Text);

      //dismiss keyboard
      GraphBatteryCurrentRedMaxThreshold.IsEnabled = false;
      GraphBatteryCurrentRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphBatteryCurrentRedMaxThresholdlabelTapped(object sender, EventArgs e)
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