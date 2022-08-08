namespace TSDZ2Monitor.Pages.Parameters.GraphVariables;

public partial class VarsBatterySoCPage : ContentPage
{
  public bool checkInput = false;
  public List<string> thresholds;

  public VarsBatterySoCPage()
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

    if (Preferences.Get("GraphBatterySoCAutoMaxMin", "false") == "true")
    {
      GraphBatterySoCAutoMaxMin.IsToggled = true;
      GraphBatterySoCAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      GraphBatterySoCAutoMaxMin.IsToggled = false;
      GraphBatterySoCAutoMaxMin.ThumbColor = Colors.Red;
    }

    GraphBatterySoCMin.Text = Preferences.Get("GraphBatterySoCMin", "0");
    GraphBatterySoCMax.Text = Preferences.Get("GraphBatterySoCMax", "0");

    thresholds = new() { "Disabled", "Manual", "Automatic" };
    GraphBatterySoCThresholds.ItemsSource = thresholds;
    for (int i = 0; i < thresholds.Count; i++)
    {
      if (thresholds[i] == Preferences.Get("GraphBatterySoCThresholds", "36")) GraphBatterySoCThresholds.SelectedIndex = i;
    }

    GraphBatterySoCYellowMaxThreshold.Text = Preferences.Get("GraphBatterySoCYellowMaxThreshold", "0");
    GraphBatterySoCRedMaxThreshold.Text = Preferences.Get("GraphBatterySoCRedMaxThreshold", "0");


    checkInput = true;
  }


  //-------Graph Battery Current Auto MaxMin------------------------------------------------
  private void GraphBatterySoCAutoMaxMin_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatterySoCAutoMaxMin.IsToggled)
    {
      Preferences.Set("GraphBatterySoCAutoMaxMin", "true");
      GraphBatterySoCAutoMaxMin.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("GraphBatterySoCAutoMaxMin", "false");
      GraphBatterySoCAutoMaxMin.ThumbColor = Colors.Red;
    }
  }

  private async void OnGraphBatterySoCAutoMaxMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Should the graph use automatic values for max and min or use the following manual values.", "OK");
  }


  //-------Graph Battery Current Min------------------------------------------------
  private void GraphBatterySoCMin_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatterySoCMin.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatterySoCMin.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatterySoCMin.TextColor != Colors.Red && GraphBatterySoCMin.Text.Length != 0)
    {
      Preferences.Set("GraphBatterySoCMin", GraphBatterySoCMin.Text);
    }
  }

  private void GraphBatterySoCMin_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatterySoCMin.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatterySoCMin", GraphBatterySoCMin.Text);

      //dismiss keyboard
      GraphBatterySoCMin.IsEnabled = false;
      GraphBatterySoCMin.IsEnabled = true;
    }
  }

  private async void GraphBatterySoCMinlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph max value. Will be set up to when a new value on the graph is lower than this value.", "OK");
  }


  //-------Graph Battery Current Max------------------------------------------------
  private void GraphBatterySoCMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatterySoCMax.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatterySoCMax.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatterySoCMax.TextColor != Colors.Red && GraphBatterySoCMax.Text.Length != 0)
    {
      Preferences.Set("GraphBatterySoCMax", GraphBatterySoCMax.Text);
    }
  }

  private void GraphBatterySoCMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatterySoCMax.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatterySoCMax", GraphBatterySoCMax.Text);
      //dismiss keyboard
      GraphBatterySoCMax.IsEnabled = false;
      GraphBatterySoCMax.IsEnabled = true;
    }
  }

  private async void GraphBatterySoCMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the graph min value. Will be set up to when a new value on the graph is higher than this value.", "OK");
  }


  //------------Graph Battery Current Thresholds----------------------------------------------- 
  private void GraphBatterySoCThresholds_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("GraphBatterySoCThresholds", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnGraphBatterySoCThresholdslabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }


  //-------Graph Battery Current Yellow Max Threshold------------------------------------------------
  private void GraphBatterySoCYellowMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatterySoCYellowMaxThreshold.TextColor = Colors.Yellow;
    if (CheckDecimal(e.NewTextValue)) GraphBatterySoCYellowMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatterySoCYellowMaxThreshold.TextColor != Colors.Yellow && GraphBatterySoCYellowMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphBatterySoCYellowMaxThreshold", GraphBatterySoCYellowMaxThreshold.Text);
    }
  }

  private void GraphBatterySoCYellowMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatterySoCYellowMaxThreshold.TextColor != Colors.Yellow)
    {
      Preferences.Set("GraphBatterySoCYellowMaxThreshold", GraphBatterySoCYellowMaxThreshold.Text);

      //dismiss keyboard
      GraphBatterySoCYellowMaxThreshold.IsEnabled = false;
      GraphBatterySoCYellowMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphBatterySoCYellowMaxThresholdlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the value for manual max threshold, for yellow color.", "OK");
  }



  //-------Graph Battery Current Red Max Threshold------------------------------------------------
  private void GraphBatterySoCRedMaxThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    GraphBatterySoCRedMaxThreshold.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) GraphBatterySoCRedMaxThreshold.TextColor = Colors.LightGreen;

    //write it to preferences
    if (GraphBatterySoCRedMaxThreshold.TextColor != Colors.Red && GraphBatterySoCRedMaxThreshold.Text.Length != 0)
    {
      Preferences.Set("GraphBatterySoCRedMaxThreshold", GraphBatterySoCRedMaxThreshold.Text);
    }
  }

  private void GraphBatterySoCRedMaxThreshold_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (GraphBatterySoCRedMaxThreshold.TextColor != Colors.Red)
    {
      Preferences.Set("GraphBatterySoCRedMaxThreshold", GraphBatterySoCRedMaxThreshold.Text);

      //dismiss keyboard
      GraphBatterySoCRedMaxThreshold.IsEnabled = false;
      GraphBatterySoCRedMaxThreshold.IsEnabled = true;
    }
  }

  private async void GraphBatterySoCRedMaxThresholdlabelTapped(object sender, EventArgs e)
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