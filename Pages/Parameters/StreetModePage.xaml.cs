namespace TSDZ2Monitor.Pages.Parameters;

public partial class StreetModePage : ContentPage
{
  public bool checkInput = false;
  public StreetModePage()
	{
		InitializeComponent();

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

    checkInput = false;  //stop activating text changed events
    StreetModeSpeedLimit.Text = Preferences.Get("StreetModeSpeedLimit", "25");
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

    if (Preferences.Get("StreetModeHotkeyEnable", "false") == "true")
    {
      StreetModeHotkeyEnable.IsToggled = true;
      StreetModeHotkeyEnable.ThumbColor = Colors.Green;
    }
    else
    {
      StreetModeHotkeyEnable.IsToggled = false;
      StreetModeHotkeyEnable.ThumbColor = Colors.Red;
    }

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
      Preferences.Set("StreetModeSpeedLimit", StreetModeSpeedLimit.Text);
    }
  }

  private void StreetModeSpeedLimit_Completed(object sender, EventArgs e)
  {
    if (StreetModeSpeedLimit.TextColor != Colors.Red && StreetModeSpeedLimit.Text.Length != 0)
    {
      Preferences.Set("StreetModeSpeedLimit", StreetModeSpeedLimit.Text);
    }

    //dismiss keyboard
    StreetModeSpeedLimit.IsEnabled = false;
    StreetModeSpeedLimit.IsEnabled = true;
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
    await DisplayAlert("Information", "The power limit in watts when Street Mode is active.", "OK");
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
    await DisplayAlert("Information", "When this feature is disabled, you cannot activate it from the main screen.", "OK");
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
    await DisplayAlert("Information", "When this feature is disabled, you cannot activate it from the main screen.", "OK");
  }



  //-------Street Mode Hotkey Enable------------------------------------------------
  private void StreetModeHotkeyEnable_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (StreetModeHotkeyEnable.IsToggled)
    {
      Preferences.Set("StreetModeHotkeyEnable", "true");
      StreetModeHotkeyEnable.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("StreetModeHotkeyEnable", "false");
      StreetModeHotkeyEnable.ThumbColor = Colors.Red;
    }
  }

  private async void OnStreetModeHotkeyEnablelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "M in 860C display\r\nNo / Yes, enable activation via a combination of buttons, the functions:\r\nStreet mode: on / off\r\nMotor max power: set value Virtual throttle: set and use.\r\n", "OK");
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