namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsCadencePage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsCadencePage()
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

    if (Preferences.Get("GraphCadenceAutoMaxMin", "false") == "true")
    {
      GraphCadenceAutoMaxMin.IsToggled = true;
      GraphCadenceAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphCadenceAutoMaxMin.IsToggled = false;
      GraphCadenceAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphCadenceMin.Text = Preferences.Get("GraphCadenceMin", "0");
    GraphCadenceMax.Text = Preferences.Get("GraphCadenceMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphCadenceThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphCadenceThresholds", "36")) GraphCadenceThresholds.SelectedIndex = i;
    }

    GraphCadenceYellowMaxThreshold.Text = Preferences.Get("GraphCadenceYellowMaxThreshold", "0");
    GraphCadenceRedMaxThreshold.Text = Preferences.Get("GraphCadenceRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphCadenceAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphCadenceAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphCadenceAutoMaxMin", "true");
      GraphCadenceAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphCadenceAutoMaxMin", "false");
      GraphCadenceAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphCadenceAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphCadenceMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphCadenceMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphCadenceMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphCadenceMin.TextColor != Colors.Red && GraphCadenceMin.Text.Length != 0)
    {
      Preferences.Set("GraphCadenceMin", GraphCadenceMin.Text);
    }
  }

  private void GraphCadenceMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphCadenceMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphCadenceMin", GraphCadenceMin.Text);

      //dismiss keyboard
      GraphCadenceMin.IsEnabled = false;
      GraphCadenceMin.IsEnabled = true;
    }
  }

  private async void GraphCadenceMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphCadenceMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphCadenceMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphCadenceMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphCadenceMax.TextColor != Colors.Red && GraphCadenceMax.Text.Length != 0)
    {
      Preferences.Set("GraphCadenceMax", GraphCadenceMax.Text);
    }
  }

  private void GraphCadenceMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphCadenceMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphCadenceMax", GraphCadenceMax.Text);
      //dismiss keyboard
      GraphCadenceMax.IsEnabled = false;
      GraphCadenceMax.IsEnabled = true;
    }
  }

  private async void GraphCadenceMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphCadenceThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphCadenceThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphCadenceThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphCadenceYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphCadenceYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphCadenceYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphCadenceYellowMaxThreshold.TextColor != Colors.Yellow && GraphCadenceYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphCadenceYellowMaxThreshold", GraphCadenceYellowMaxThreshold.Text);
    }
  }

  private void GraphCadenceYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphCadenceYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphCadenceYellowMaxThreshold", GraphCadenceYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphCadenceYellowMaxThreshold.IsEnabled = false;
      GraphCadenceYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphCadenceYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphCadenceRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphCadenceRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphCadenceRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphCadenceRedMaxThreshold.TextColor != Colors.Red && GraphCadenceRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphCadenceRedMaxThreshold", GraphCadenceRedMaxThreshold.Text);
    }
  }

  private void GraphCadenceRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphCadenceRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphCadenceRedMaxThreshold", GraphCadenceRedMaxThreshold.Text);

      //dismiss keyboard
      GraphCadenceRedMaxThreshold.IsEnabled = false;
      GraphCadenceRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphCadenceRedMaxThresholdlabelTapped(object sender, EventArgs e)
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