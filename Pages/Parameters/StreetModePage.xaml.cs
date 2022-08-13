namespace TSDZ2Monitor.Pages.Parameters;

public partial class StreetModePage : ContentPage
{
  public bool checkInput = false;

  public string variousUnits;

  public StreetModePage()
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
    variousUnits = Preferences.Get("VariousUnits", "Metric");

    if (Preferences.Get("StreetModeEnableMode", "true") == "true")
    {
      StreetModeEnableMode.IsToggled = true;
      StreetModeEnableMode.ThumbColor = Colors.Green;
    }
    else
    {
      StreetModeEnableMode.IsToggled = false;
      StreetModeEnableMode.ThumbColor = Colors.Red;
    }

    if (Preferences.Get("StreetModeEnableAtStartup", "false") == "true")
    {
      StreetModeEnableAtStartup.IsToggled = true;
      StreetModeEnableAtStartup.ThumbColor = Colors.Green;
    }
    else
    {
      StreetModeEnableAtStartup.IsToggled = false;
      StreetModeEnableAtStartup.ThumbColor = Colors.Red;
    }


    if (variousUnits == "Metric")
    {
      StreetModeSpeedLimit.Text = Preferences.Get("StreetModeSpeedLimit", "25");
    }
    else
    {
      double s = Double.Parse(Preferences.Get("StreetModeSpeedLimit", "25"));
      s = Math.Round(s / 1.609344);
      StreetModeSpeedLimit.Text = s.ToString();
    }

    StreetModeMotorPowerLimit.Text = Preferences.Get("StreetModeMotorPowerLimit", "250");
    checkInput = true;

    if (Preferences.Get("StreetModeThrottleEnable", "true") == "true")
    {
      StreetModeThrottleEnable.IsToggled = true;
      StreetModeThrottleEnable.ThumbColor = Colors.Green;
    }
    else
    {
      StreetModeThrottleEnable.IsToggled = false;
      StreetModeThrottleEnable.ThumbColor = Colors.Red;
    }

    if (Preferences.Get("StreetModeCruiseEnable", "false") == "true")
    {
      StreetModeCruiseEnable.IsToggled = true;
      StreetModeCruiseEnable.ThumbColor = Colors.Green;
    }
    else
    {
      StreetModeCruiseEnable.IsToggled = false;
      StreetModeCruiseEnable.ThumbColor = Colors.Red;
    }

    checkInput = false;  //stop activating text changed events
  }

  //-------Street Mode Enable Mode------------------------------------------------
  private void StreetModeEnableMode_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (StreetModeEnableMode.IsToggled)
    {
      Preferences.Set("StreetModeEnableMode", "true");
      StreetModeEnableMode.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("StreetModeEnableMode", "false");
      StreetModeEnableMode.ThumbColor = Colors.Red;
    }
  }

  private async void OnStreetModeEnableModelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "When this feature is disabled, you cannot activate it from the main screen.", "OK");
  }


  //-------Street Mode Enable At Startup------------------------------------------------
  private void StreetModeEnableAtStartup_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (StreetModeEnableAtStartup.IsToggled)
    {
      Preferences.Set("StreetModeEnableAtStartup", "true");
      StreetModeEnableAtStartup.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("StreetModeEnableAtStartup", "false");
      StreetModeEnableAtStartup.ThumbColor = Colors.Red;
    }
  }

  private async void OnStreetModeEnableAtStartuplabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Determines whether Street mode should be active on system startup.", "OK");
  }


  //-------Street Mode Speed Limit------------------------------------------------
  private void StreetModeSpeedLimit_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    StreetModeSpeedLimit.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) StreetModeSpeedLimit.TextColor = Colors.LightGreen;

    //not > 200??
    if (StreetModeSpeedLimit.TextColor != Colors.Red && int.Parse(StreetModeSpeedLimit.Text) > 200)
    {
      StreetModeSpeedLimit.TextColor = Colors.Red;
    }

    if (StreetModeSpeedLimit.TextColor != Colors.Red && StreetModeSpeedLimit.Text.Length != 0)
    {
      SaveSpeedLimit();
    }
  }

  private void StreetModeSpeedLimit_Completed(object sender, EventArgs e)
  {
    if (StreetModeSpeedLimit.TextColor != Colors.Red && StreetModeSpeedLimit.Text.Length != 0)
    {
      SaveSpeedLimit();
    }

    //dismiss keyboard
    StreetModeSpeedLimit.IsEnabled = false;
    StreetModeSpeedLimit.IsEnabled = true;
  }

  public void SaveSpeedLimit()
  {
    //save as kph regardless
    if (variousUnits == "Metric")
    {
      Preferences.Set("StreetModeSpeedLimit", StreetModeSpeedLimit.Text);
    }
    else
    {
      double s = Double.Parse(StreetModeSpeedLimit.Text);
      s = Math.Round(s * 1.609344);
      Preferences.Set("StreetModeSpeedLimit", s);
    }

  }

  private async void OnStreetModeSpeedLimitLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the speed limit for when Street Mode is active.\r\nThe motor will fade out power from -0.5 km/h to + 2.0 km/h to prevent over-speeding.\r\n", "OK");
  }


  //-------Street Mode Motor Power Limit------------------------------------------------
  private void StreetModeMotorPowerLimit_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    StreetModeMotorPowerLimit.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) StreetModeMotorPowerLimit.TextColor = Colors.LightGreen;

    //not > 10000!
    if (StreetModeMotorPowerLimit.TextColor != Colors.Red && int.Parse(StreetModeMotorPowerLimit.Text) > 10000)
    {
      StreetModeMotorPowerLimit.TextColor = Colors.Red;
    }

    if (StreetModeMotorPowerLimit.TextColor != Colors.Red && StreetModeMotorPowerLimit.Text.Length != 0)
    {
      Preferences.Set("StreetModeMotorPowerLimit", StreetModeMotorPowerLimit.Text);
    }
  }

  private void StreetModeMotorPowerLimit_Completed(object sender, EventArgs e)
  {
    if (StreetModeMotorPowerLimit.TextColor != Colors.Red && StreetModeMotorPowerLimit.Text.Length != 0)
    {
      Preferences.Set("StreetModeMotorPowerLimit", StreetModeMotorPowerLimit.Text);
    }

    //dismiss keyboard
    StreetModeMotorPowerLimit.IsEnabled = false;
    StreetModeMotorPowerLimit.IsEnabled = true;
  }

  private async void OnStreetModeMotorPowerLimitLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The power limit in Watts when Street Mode is active.", "OK");
  }


  //-------Street Mode Throttle Enable------------------------------------------------
  private void StreetModeThrottleEnable_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (StreetModeThrottleEnable.IsToggled)
    {
      Preferences.Set("StreetModeThrottleEnable", "true");
      StreetModeThrottleEnable.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("StreetModeThrottleEnable", "false");
      StreetModeThrottleEnable.ThumbColor = Colors.Red;
    }
  }

  private async void OnStreetModeThrottleEnablelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Determines if the throttle is enabled in Street Mode.", "OK");
  }



  //-------Street Mode Cruise Enable------------------------------------------------
  private void StreetModeCruiseEnable_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (StreetModeCruiseEnable.IsToggled)
    {
      Preferences.Set("StreetModeCruiseEnable", "true");
      StreetModeCruiseEnable.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("StreetModeCruiseEnable", "false");
      StreetModeCruiseEnable.ThumbColor = Colors.Red;
    }
  }

  private async void OnStreetModeCruiseEnablelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enable/disable the cruise function in \"Street mode\".", "OK");
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

}