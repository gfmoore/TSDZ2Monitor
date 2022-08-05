namespace TSDZ2Monitor.Pages.Parameters;

public partial class SoCPage : ContentPage
{
  public List<string> socDisplayText;
  public SoCPage()
	{
		InitializeComponent();

    socDisplayText = new() { "SoC %", "Volts", "Disabled" };
    SoCDisplayText.ItemsSource = socDisplayText;
    for (int i = 0; i < socDisplayText.Count; i++)
    {
      if (socDisplayText[i] == Preferences.Get("SoCDisplayText", "Disabled")) SoCDisplayText.SelectedIndex = i;
    }

    SoCResetAtVoltage.Text = Preferences.Get("SoCResetAtVoltage", "54.0");
    SoCBatteryTotalWattHr.Text = Preferences.Get("SoCBatteryTotalWattHr", "400");
    SoCUsedWattHr.Text = Preferences.Get("SoCUsedWattHr", "0");

    if (Preferences.Get("SoCManualReset", "false") == "true")
    {
      SoCManualReset.IsToggled = true;
      SoCManualReset.ThumbColor = Colors.Green;
    }
    else
    {
      SoCManualReset.IsToggled = false;
      SoCManualReset.ThumbColor = Colors.Red;
    }
  }

  //-------------SoC Display Text-----------------------------------
  private void SoCDisplayText_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("SoCDisplayText", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnSoCDisplayTextLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "What to show on screen", "OK");
  }


  //-------SoC Reset At Voltage------------------------------------------------
  private void SoCResetAtVoltage_TextChanged(object sender, TextChangedEventArgs e)
  {
    SoCResetAtVoltage.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) SoCResetAtVoltage.TextColor = Colors.LightGreen;

    if (SoCResetAtVoltage.TextColor != Colors.Red && SoCResetAtVoltage.Text.Length != 0)
    {
      Preferences.Set("SoCResetAtVoltage", SoCResetAtVoltage.Text);
    }
  }

  private void SoCResetAtVoltage_Completed(object sender, EventArgs e)
  {
    if (SoCResetAtVoltage.TextColor != Colors.Red && SoCResetAtVoltage.Text.Length != 0)
    {
      Preferences.Set("SoCResetAtVoltage", SoCResetAtVoltage.Text);
    }

    //dismiss keyboard
    SoCResetAtVoltage.IsEnabled = false;
    SoCResetAtVoltage.IsEnabled = true;
  }

  private async void OnSoCResetAtVoltageLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Threshold voltage to reset the SoC watt-hour meter.", "OK");
  }


  //-------SoC Battery Total Watt-Hr------------------------------------------------
  private void SoCBatteryTotalWattHr_TextChanged(object sender, TextChangedEventArgs e)
  {
    SoCBatteryTotalWattHr.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) SoCBatteryTotalWattHr.TextColor = Colors.LightGreen;

    if (SoCBatteryTotalWattHr.TextColor != Colors.Red && SoCBatteryTotalWattHr.Text.Length != 0)
    {
      Preferences.Set("SoCBatteryTotalWattHr", SoCBatteryTotalWattHr.Text);
    }
  }

  private void SoCBatteryTotalWattHr_Completed(object sender, EventArgs e)
  {
    if (SoCBatteryTotalWattHr.TextColor != Colors.Red && SoCBatteryTotalWattHr.Text.Length != 0)
    {
      Preferences.Set("SoCBatteryTotalWattHr", SoCBatteryTotalWattHr.Text);
    }

    //dismiss keyboard
    SoCBatteryTotalWattHr.IsEnabled = false;
    SoCBatteryTotalWattHr.IsEnabled = true;
  }

  private async void OnSoCBatteryTotalWattHrLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the total capacity in watt-hours less 10% of what your battery has.", "OK");
  }


  //-------SoC Used Watt-Hr------------------------------------------------
  private void SoCUsedWattHr_TextChanged(object sender, TextChangedEventArgs e)
  {
    SoCUsedWattHr.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) SoCUsedWattHr.TextColor = Colors.LightGreen;

    if (SoCUsedWattHr.TextColor != Colors.Red && SoCUsedWattHr.Text.Length != 0)
    {
      Preferences.Set("SoCUsedWattHr", SoCUsedWattHr.Text);
    }
  }

  private void SoCUsedWattHr_Completed(object sender, EventArgs e)
  {
    if (SoCUsedWattHr.TextColor != Colors.Red && SoCUsedWattHr.Text.Length != 0)
    {
      Preferences.Set("SoCUsedWattHr", SoCUsedWattHr.Text);
    }

    //dismiss keyboard
    SoCUsedWattHr.IsEnabled = false;
    SoCUsedWattHr.IsEnabled = true;
  }

  private async void OnSoCUsedWattHrLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "This value shows the SoC watt-hour meter value. ", "OK");
  }


  //-------SoC Manual Reset units------------------------------------------------
  private void SoCManualReset_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (SoCManualReset.IsToggled)
    {
      Preferences.Set("SoCManualReset", "true");
      SoCManualReset.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("SoCManualReset", "false");
      SoCManualReset.ThumbColor = Colors.Red;
    }
  }

  private async void OnSoCManualResetlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Use when putting on an incompletely charged battery or at the first power on after the flashing. ", "OK");
  }



  //----------Helper functions--------------------------------------
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

