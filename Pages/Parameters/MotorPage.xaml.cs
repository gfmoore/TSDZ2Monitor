namespace TSDZ2Monitor.Pages.Parameters;

public partial class MotorPage : ContentPage
{

  public List<string> allowableVoltages;

	public MotorPage()
	{
		InitializeComponent();

    allowableVoltages = new() { "18", "36", "48", "56", "72", "90" };
    MotorVoltage.ItemsSource = allowableVoltages;
    for (int i=0; i < allowableVoltages.Count; i++)
    {
      if (allowableVoltages[i] == Preferences.Get("MotorVoltage", "36")) MotorVoltage.SelectedIndex = i;
    }
    
    MotorPowerMax.Text = Preferences.Get("MotorPowerMax", "450");
    MotorAcceleration.Text = Preferences.Get("MotorAcceleration", "5");
    MotorDeceleration.Text = Preferences.Get("MotorDeceleration", "0");

    if (Preferences.Get("MotorFastStop", "false") == "true")
    {
      MotorFastStop.IsToggled = true;
      MotorFastStop.ThumbColor = Colors.Green;
    }
    else
    {
      MotorFastStop.IsToggled = false;
      MotorFastStop.ThumbColor = Colors.Red;
    }

    if (Preferences.Get("MotorFieldWeakening", "true") == "true")
    {
      MotorFieldWeakening.IsToggled = true;
      MotorFieldWeakening.ThumbColor = Colors.Green;
    }
    else
    {
      MotorFieldWeakening.IsToggled = false;
      MotorFieldWeakening.ThumbColor = Colors.Red;
    }
  }

  //------------Motor Voltage----------------------------------------------- 
  private void MotorVoltage_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("MotorVoltage", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnMotorVoltagelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The voltage of the battery does not matter, this value should always be set depending on the type of motor", "OK");
  }

  //-------PowerMax------------------------------------------------
  private void MotorPowerMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    MotorPowerMax.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) MotorPowerMax.TextColor = Colors.LightGreen;

    //not > 450
    if (MotorPowerMax.TextColor != Colors.Red && int.Parse(MotorPowerMax.Text) > 450)
    {
      MotorPowerMax.TextColor = Colors.Orange;
    }

    //not > 1000
    if (MotorPowerMax.TextColor != Colors.Red && int.Parse(MotorPowerMax.Text) > 1000)
    {
      MotorPowerMax.TextColor = Colors.Red;
    }

    //write it to preferences
    if (MotorPowerMax.TextColor != Colors.Red && MotorPowerMax.Text.Length != 0)
    {
      Preferences.Set("MotorPowerMax", MotorPowerMax.Text);
    }
  }

  private void MotorPowerMax_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (MotorPowerMax.TextColor != Colors.Red)
    {
      Preferences.Set("MotorPowerMax", MotorPowerMax.Text);
      //dismiss keyboard
      MotorPowerMax.IsEnabled = false;
      MotorPowerMax.IsEnabled = true;
    }
  }

  private async void MotorPowerMaxlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "A maximum value of 450W is recommended", "OK");
  }

  //-------Acceleration------------------------------------------------
  private void MotorAcceleration_TextChanged(object sender, TextChangedEventArgs e)
  {
    MotorAcceleration.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) MotorAcceleration.TextColor = Colors.LightGreen;

    //write it to preferences
    if (MotorAcceleration.TextColor != Colors.Red && MotorAcceleration.Text.Length != 0)
    {
      Preferences.Set("MotorAcceleration", MotorAcceleration.Text);
    }
  }

  private void MotorAcceleration_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (MotorAcceleration.TextColor != Colors.Red)
    {
      Preferences.Set("MotorAcceleration", MotorAcceleration.Text);
      //dismiss keyboard
      MotorAcceleration.IsEnabled = false;
      MotorAcceleration.IsEnabled = true;
    }
  }

  private async void OnMotorAccelerationlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "36 Volt motor, 36 volt battery = 35\r\n36 Volt motor, 48 volt battery = 5\r\n36 Volt motor, 52 volt battery = 0\r\n48 Volt motor, 36 volt battery = 45\r\n48 Volt motor, 48 volt battery = 35\r\n48 Volt motor, 52 volt battery = 30\r\n", "OK");
  }


  //-------Deceleration------------------------------------------------
  private void MotorDeceleration_TextChanged(object sender, TextChangedEventArgs e)
  {
    MotorDeceleration.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) MotorDeceleration.TextColor = Colors.LightGreen;

    //<100%
    if (MotorDeceleration.TextColor != Colors.Red && int.Parse(MotorDeceleration.Text) > 100)
    {
      MotorDeceleration.TextColor = Colors.Red;
    }

    //write it to preferences
    if (MotorDeceleration.TextColor != Colors.Red && MotorDeceleration.Text.Length != 0)
    {
      Preferences.Set("MotorDeceleration", MotorDeceleration.Text);
    }
  }

  private void MotorDeceleration_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (MotorDeceleration.TextColor != Colors.Red)
    {
      Preferences.Set("MotorDeceleration", MotorDeceleration.Text);
      //dismiss keyboard
      MotorDeceleration.IsEnabled = false;
      MotorDeceleration.IsEnabled = true;
    }
  }


  private async void OnMotorDecelerationlabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "If set to zero, the default deceleration ramp is active, \r\n\r\nIf set to 100% the minimum deceleration ramp (faster stop).\r\n\r\nThe feature is deactivated when  “Motor fast stop” is enabled.\r\n", "OK");
  }


  //-------FastStop------------------------------------------------
  private void MotorFastStop_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (MotorFastStop.IsToggled)
    {
      Preferences.Set("MotorFastStop", "true");
      MotorFastStop.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("MotorFastStop", "false");
      MotorFastStop.ThumbColor = Colors.Red;
    }
  }

  private async void OnMotorFastStoplabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enabling the motor to stop immediately when you stop pedaling. If the motor stops too abruptly then disable and use the deceleration ramp", "OK");
  }


  //-------FieldWeakening------------------------------------------------
  private void MotorFieldWeakening_Toggled(object sender, EventArgs e)
  {
    //write it to preferences
    if (MotorFieldWeakening.IsToggled)
    {
      Preferences.Set("MotorFieldWeakening", "true");
      MotorFieldWeakening.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("MotorFieldWeakening", "false");
      MotorFieldWeakening.ThumbColor = Colors.Red;
    }

  }

  private async void OnMotorFieldWeakeninglabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Field weakening function that allows you to pedal at   \r\n  high cadence. The field weakening function   \r\n  increases the motor cadence (up to 120 RPM when \r\n  possible) but there is also a loss of efficiency.\r\nIf enabled, field weakening is automatically activated when the PWM value is greater than 100%.\r\n", "OK");
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


}