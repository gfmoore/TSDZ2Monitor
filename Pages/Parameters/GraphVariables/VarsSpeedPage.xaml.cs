namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsSpeedPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsSpeedPage()
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

    if (Preferences.Get("GraphSpeedAutoMaxMin", "false") == "true")
    {
      GraphSpeedAutoMaxMin.IsToggled = true;
      GraphSpeedAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphSpeedAutoMaxMin.IsToggled = false;
      GraphSpeedAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphSpeedMin.Text = Preferences.Get("GraphSpeedMin", "0");
    GraphSpeedMax.Text = Preferences.Get("GraphSpeedMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphSpeedThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphSpeedThresholds", "36")) GraphSpeedThresholds.SelectedIndex = i;
    }

    GraphSpeedYellowMaxThreshold.Text = Preferences.Get("GraphSpeedYellowMaxThreshold", "0");
    GraphSpeedRedMaxThreshold.Text = Preferences.Get("GraphSpeedRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphSpeedAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphSpeedAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphSpeedAutoMaxMin", "true");
      GraphSpeedAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphSpeedAutoMaxMin", "false");
      GraphSpeedAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphSpeedAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphSpeedMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphSpeedMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphSpeedMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphSpeedMin.TextColor != Colors.Red && GraphSpeedMin.Text.Length != 0)
    {
      Preferences.Set("GraphSpeedMin", GraphSpeedMin.Text);
    }
  }

  private void GraphSpeedMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphSpeedMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphSpeedMin", GraphSpeedMin.Text);

      //dismiss keyboard
      GraphSpeedMin.IsEnabled = false;
      GraphSpeedMin.IsEnabled = true;
    }
  }

  private async void GraphSpeedMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphSpeedMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphSpeedMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphSpeedMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphSpeedMax.TextColor != Colors.Red && GraphSpeedMax.Text.Length != 0)
    {
      Preferences.Set("GraphSpeedMax", GraphSpeedMax.Text);
    }
  }

  private void GraphSpeedMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphSpeedMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphSpeedMax", GraphSpeedMax.Text);
      //dismiss keyboard
      GraphSpeedMax.IsEnabled = false;
      GraphSpeedMax.IsEnabled = true;
    }
  }

  private async void GraphSpeedMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphSpeedThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphSpeedThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphSpeedThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphSpeedYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphSpeedYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphSpeedYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphSpeedYellowMaxThreshold.TextColor != Colors.Yellow && GraphSpeedYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphSpeedYellowMaxThreshold", GraphSpeedYellowMaxThreshold.Text);
    }
  }

  private void GraphSpeedYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphSpeedYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphSpeedYellowMaxThreshold", GraphSpeedYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphSpeedYellowMaxThreshold.IsEnabled = false;
      GraphSpeedYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphSpeedYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphSpeedRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphSpeedRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphSpeedRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphSpeedRedMaxThreshold.TextColor != Colors.Red && GraphSpeedRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphSpeedRedMaxThreshold", GraphSpeedRedMaxThreshold.Text);
    }
  }

  private void GraphSpeedRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphSpeedRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphSpeedRedMaxThreshold", GraphSpeedRedMaxThreshold.Text);

      //dismiss keyboard
      GraphSpeedRedMaxThreshold.IsEnabled = false;
      GraphSpeedRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphSpeedRedMaxThresholdlabelTapped(object sender, EventArgs e)
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