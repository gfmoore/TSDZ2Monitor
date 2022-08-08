namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsMotorCurrentPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsMotorCurrentPage()
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

    if (Preferences.Get("GraphMotorCurrentAutoMaxMin", "false") == "true")
    {
      GraphMotorCurrentAutoMaxMin.IsToggled = true;
      GraphMotorCurrentAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphMotorCurrentAutoMaxMin.IsToggled = false;
      GraphMotorCurrentAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphMotorCurrentMin.Text = Preferences.Get("GraphMotorCurrentMin", "0");
    GraphMotorCurrentMax.Text = Preferences.Get("GraphMotorCurrentMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphMotorCurrentThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphMotorCurrentThresholds", "36")) GraphMotorCurrentThresholds.SelectedIndex = i;
    }

    GraphMotorCurrentYellowMaxThreshold.Text = Preferences.Get("GraphMotorCurrentYellowMaxThreshold", "0");
    GraphMotorCurrentRedMaxThreshold.Text = Preferences.Get("GraphMotorCurrentRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphMotorCurrentAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorCurrentAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphMotorCurrentAutoMaxMin", "true");
      GraphMotorCurrentAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphMotorCurrentAutoMaxMin", "false");
      GraphMotorCurrentAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphMotorCurrentAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphMotorCurrentMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorCurrentMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorCurrentMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorCurrentMin.TextColor != Colors.Red && GraphMotorCurrentMin.Text.Length != 0)
    {
      Preferences.Set("GraphMotorCurrentMin", GraphMotorCurrentMin.Text);
    }
  }

  private void GraphMotorCurrentMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorCurrentMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorCurrentMin", GraphMotorCurrentMin.Text);

      //dismiss keyboard
      GraphMotorCurrentMin.IsEnabled = false;
      GraphMotorCurrentMin.IsEnabled = true;
    }
  }

  private async void GraphMotorCurrentMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphMotorCurrentMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorCurrentMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorCurrentMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorCurrentMax.TextColor != Colors.Red && GraphMotorCurrentMax.Text.Length != 0)
    {
      Preferences.Set("GraphMotorCurrentMax", GraphMotorCurrentMax.Text);
    }
  }

  private void GraphMotorCurrentMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorCurrentMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorCurrentMax", GraphMotorCurrentMax.Text);
      //dismiss keyboard
      GraphMotorCurrentMax.IsEnabled = false;
      GraphMotorCurrentMax.IsEnabled = true;
    }
  }

  private async void GraphMotorCurrentMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphMotorCurrentThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphMotorCurrentThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphMotorCurrentThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphMotorCurrentYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorCurrentYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphMotorCurrentYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorCurrentYellowMaxThreshold.TextColor != Colors.Yellow && GraphMotorCurrentYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorCurrentYellowMaxThreshold", GraphMotorCurrentYellowMaxThreshold.Text);
    }
  }

  private void GraphMotorCurrentYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorCurrentYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphMotorCurrentYellowMaxThreshold", GraphMotorCurrentYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorCurrentYellowMaxThreshold.IsEnabled = false;
      GraphMotorCurrentYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorCurrentYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphMotorCurrentRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorCurrentRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorCurrentRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorCurrentRedMaxThreshold.TextColor != Colors.Red && GraphMotorCurrentRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorCurrentRedMaxThreshold", GraphMotorCurrentRedMaxThreshold.Text);
    }
  }

  private void GraphMotorCurrentRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorCurrentRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorCurrentRedMaxThreshold", GraphMotorCurrentRedMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorCurrentRedMaxThreshold.IsEnabled = false;
      GraphMotorCurrentRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorCurrentRedMaxThresholdlabelTapped(object sender, EventArgs e)
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