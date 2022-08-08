namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsMotorFOCPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsMotorFOCPage()
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

    if (Preferences.Get("GraphMotorFOCAutoMaxMin", "false") == "true")
    {
      GraphMotorFOCAutoMaxMin.IsToggled = true;
      GraphMotorFOCAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphMotorFOCAutoMaxMin.IsToggled = false;
      GraphMotorFOCAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphMotorFOCMin.Text = Preferences.Get("GraphMotorFOCMin", "0");
    GraphMotorFOCMax.Text = Preferences.Get("GraphMotorFOCMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphMotorFOCThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphMotorFOCThresholds", "36")) GraphMotorFOCThresholds.SelectedIndex = i;
    }

    GraphMotorFOCYellowMaxThreshold.Text = Preferences.Get("GraphMotorFOCYellowMaxThreshold", "0");
    GraphMotorFOCRedMaxThreshold.Text = Preferences.Get("GraphMotorFOCRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphMotorFOCAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorFOCAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphMotorFOCAutoMaxMin", "true");
      GraphMotorFOCAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphMotorFOCAutoMaxMin", "false");
      GraphMotorFOCAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphMotorFOCAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphMotorFOCMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorFOCMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorFOCMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorFOCMin.TextColor != Colors.Red && GraphMotorFOCMin.Text.Length != 0)
    {
      Preferences.Set("GraphMotorFOCMin", GraphMotorFOCMin.Text);
    }
  }

  private void GraphMotorFOCMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorFOCMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorFOCMin", GraphMotorFOCMin.Text);

      //dismiss keyboard
      GraphMotorFOCMin.IsEnabled = false;
      GraphMotorFOCMin.IsEnabled = true;
    }
  }

  private async void GraphMotorFOCMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphMotorFOCMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorFOCMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorFOCMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorFOCMax.TextColor != Colors.Red && GraphMotorFOCMax.Text.Length != 0)
    {
      Preferences.Set("GraphMotorFOCMax", GraphMotorFOCMax.Text);
    }
  }

  private void GraphMotorFOCMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorFOCMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorFOCMax", GraphMotorFOCMax.Text);
      //dismiss keyboard
      GraphMotorFOCMax.IsEnabled = false;
      GraphMotorFOCMax.IsEnabled = true;
    }
  }

  private async void GraphMotorFOCMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphMotorFOCThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphMotorFOCThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphMotorFOCThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphMotorFOCYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorFOCYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphMotorFOCYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorFOCYellowMaxThreshold.TextColor != Colors.Yellow && GraphMotorFOCYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorFOCYellowMaxThreshold", GraphMotorFOCYellowMaxThreshold.Text);
    }
  }

  private void GraphMotorFOCYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorFOCYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphMotorFOCYellowMaxThreshold", GraphMotorFOCYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorFOCYellowMaxThreshold.IsEnabled = false;
      GraphMotorFOCYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorFOCYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphMotorFOCRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphMotorFOCRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphMotorFOCRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphMotorFOCRedMaxThreshold.TextColor != Colors.Red && GraphMotorFOCRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphMotorFOCRedMaxThreshold", GraphMotorFOCRedMaxThreshold.Text);
    }
  }

  private void GraphMotorFOCRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphMotorFOCRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphMotorFOCRedMaxThreshold", GraphMotorFOCRedMaxThreshold.Text);

      //dismiss keyboard
      GraphMotorFOCRedMaxThreshold.IsEnabled = false;
      GraphMotorFOCRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphMotorFOCRedMaxThresholdlabelTapped(object sender, EventArgs e)
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