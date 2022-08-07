namespace TSDZ2Monitor.Pages.Parameters;

public partial class BatteryPage : ContentPage
{
	public BatteryPage()
	{
		InitializeComponent();

		//get defaults stored in preferences
		MaxCurrent.Text = Preferences.Get("BatteryMaxCurrent", "11");
		LowCutOff.Text = Preferences.Get("BatteryLowCutOff", "39");
		Resistance.Text = Preferences.Get("BatteryResistance", "200");	
		VoltageEstimate.Text = Preferences.Get("BatteryVoltageEstimate", "-");	
		ResistanceEstimate.Text = Preferences.Get("BatteryResistanceEstimate", "-");
		PowerLossEstimate.Text = Preferences.Get("PowerLossEstimate", "-");
	}

  //-------Max Current------------------------------------------------
	private void MaxCurrent_TextChanged(object sender, TextChangedEventArgs e)
	{
    MaxCurrent.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) MaxCurrent.TextColor = Colors.LightGreen;

    //not > 18
    if (MaxCurrent.TextColor != Colors.Red && int.Parse(MaxCurrent.Text) > 18)
    {
      MaxCurrent.TextColor = Colors.Red;
    }

    //write it to preferences
    if (MaxCurrent.TextColor != Colors.Red && MaxCurrent.Text.Length != 0)
    {
      Preferences.Set("BatteryMaxCurrent", MaxCurrent.Text);
    }
  }

	private void MaxCurrent_Completed(object sender, EventArgs e)
	{
		//Write to preferences
    if (MaxCurrent.TextColor != Colors.Red)
		{
      Preferences.Set("BatteryMaxCurrent", MaxCurrent.Text);
			//dismiss keyboard
      MaxCurrent.IsEnabled = false;
      MaxCurrent.IsEnabled = true;
    }
  }

	private async void OnMaxCurrentlabelTapped(object sender, EventArgs e)
	{
    await DisplayAlert("Information", "Set the maximum allowable current to be pulled from the\r\nbattery - this value is a technical characteristic of your battery, you need to find it on your battery user manual or ask the manufacturer. \r\nAlso, the TSDZ2 has its own limit of the max current it can pull from the battery that is 18 amps so the TSDZ2 firmware limits this value (there is no point for you to set a higher value than 18).\r\n\r\nMaximum recommended values: \r\n36V battery: 15 Amps, \r\n48V battery: 12 Amps,\r\n52V battery: 10 Amps.\r\n\r\nIf you set it above these values, do not run the motor above 450 watts for more than a few minutes without installing the temperature sensor..\r\n", "OK");
  }


  //-------LowCutOff------------------------------------------------
  private void LowCutOff_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (CheckNumeric(e.NewTextValue)) MaxCurrent.TextColor = Colors.LightGreen;
    else MaxCurrent.TextColor = Colors.Red;

    //write it to preferences
    if (LowCutOff.TextColor != Colors.Red && LowCutOff.Text.Length != 0)
    {
      Preferences.Set("BatteryLowCutOff", LowCutOff.Text);
    }
  }

  private void LowCutOff_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (LowCutOff.TextColor != Colors.Red)
    {
      Preferences.Set("BatteryLowCutOff", LowCutOff.Text);
      //dismiss keyboard
      LowCutOff.IsEnabled = false;
      LowCutOff.IsEnabled = true;
    }
  }

  private async void LowCutOfflabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Calculate the Low cut-off limit by multiplying the number of cells in series with the safe cut-off-voltage per cell, which is usually between 2.8 - 3.0 volts.\r\nCalculate the Low cut-off limit by multiplying the number of cells in series with the safe cut-off-voltage per cell, which is usually between 2.8 - 3.0 volts.\r\nExample:\r\n30.0 volts: 10 cells in series * 3.0 volts = 30.0 volts.\r\n39.0 volts: 13 cells in series * 3.0 volts = 39.0 volts.\r\n42.0 volts: 14 cells in series * 3.0 volts = 42.0 volts.\r\n\r\nNote that by setting a high Low cut-off limit you will make less deep discharging cycles of your battery meaning the battery life will be increased AND you will then have less power available to use and so less range.\r\n", "OK");
  }


  //-------Resistance------------------------------------------------
  private void Resistance_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (CheckNumeric(e.NewTextValue)) MaxCurrent.TextColor = Colors.LightGreen;
    else MaxCurrent.TextColor = Colors.Red;

    //write it to preferences
    if (Resistance.TextColor != Colors.Red && Resistance.Text.Length != 0)
    {
      Preferences.Set("BatteryResistance", Resistance.Text);
    }
  }

  private void Resistance_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (Resistance.TextColor != Colors.Red)
    {
      Preferences.Set("BatteryResistance", Resistance.Text);
      //dismiss keyboard
      Resistance.IsEnabled = false;
      Resistance.IsEnabled = true;
    }
  }

  private async void ResistancelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The battery SoC (State of Charge) indicator uses the\r\nbattery resistance to consider the power loss inside the battery resistance and also the resistance on the cables. \r\n\r\nSee Resistance set field instructions to know  how you can get this value.\r\nSee Resistance auto estimate to enter as this number.\r\n", "OK");
  }

  //The following three values are generated by motor, so allow -?  //Should they be saved?

  //-------VoltageEstimate------------------------------------------------
  private void VoltageEstimate_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (CheckNumeric(e.NewTextValue)) VoltageEstimate.TextColor = Colors.LightGreen;
    else VoltageEstimate.TextColor = Colors.Red;

    //now see if just one char then if a - ok
    if (CheckDash(e.NewTextValue)) VoltageEstimate.TextColor = Colors.LightGreen;

    //write it to preferences if valid and not blank
    if (VoltageEstimate.TextColor != Colors.Red && VoltageEstimate.Text.Length != 0)
    {
      Preferences.Set("BatteryVoltageEstimate", VoltageEstimate.Text);
    }
  }

  private void VoltageEstimate_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (VoltageEstimate.TextColor != Colors.Red)
    {
      Preferences.Set("BatteryVoltageEstimate", VoltageEstimate.Text);
      //dismiss keyboard
      VoltageEstimate.IsEnabled = false;
      VoltageEstimate.IsEnabled = true;
    }
  }

  private async void VoltageEstimatelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Real-time battery voltage value that is filtered using\r\nthe battery pack resistance. If the battery resistance value is correct, this voltage should almost not change when the motor is not running or when the motor is running and pulling a high current from the battery.\r\n", "OK");
  }


  //-------ResistanceEstimate------------------------------------------------
  private void ResistanceEstimate_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (CheckNumeric(e.NewTextValue)) ResistanceEstimate.TextColor = Colors.LightGreen;
    else ResistanceEstimate.TextColor = Colors.Red;
    //now see if just one char is a -
    if (CheckDash(e.NewTextValue)) ResistanceEstimate.TextColor = Colors.LightGreen;

    //write it to preferences
    if (ResistanceEstimate.TextColor != Colors.Red && ResistanceEstimate.Text.Length != 0)
    {
      Preferences.Set("BatteryResistanceEstimate", ResistanceEstimate.Text);
    }
  }

  private void ResistanceEstimate_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (ResistanceEstimate.TextColor != Colors.Red)
    {
      Preferences.Set("BatteryResistanceEstimate", ResistanceEstimate.Text);
      //dismiss keyboard
      ResistanceEstimate.IsEnabled = false;
      ResistanceEstimate.IsEnabled = true;
    }
  }

  private async void ResistanceEstimatelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Battery resistance estimated value that is\r\nautomatically calculated so you can assess this value and then configure the Resistance field.\r\n\r\nHow to start the automatic battery pack resistance estimation:\r\n\r\n表tStart with the battery already discharged, with any value between 75% and 25%\r\n\r\n表tStart pedaling for 10 consecutive seconds, making the motor pull high current value from the battery like 10 amps (use a high assist level). After 10 seconds you should see a value on the field. \r\n\r\n表tFor battery pack of 14S3P 3500 mAh cells, I get a value near 200 milliohms.\r\n\r\n表tRepeat the previous step a few times to make sure you always get a similar value\r\n\r\n表tSet the measured value Resistance field (I always round up the value)\r\n", "OK");
  }


  //-------PowerLossEstimate------------------------------------------------
  private void PowerLossEstimate_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (CheckNumeric(e.NewTextValue)) PowerLossEstimate.TextColor = Colors.LightGreen;
    else PowerLossEstimate.TextColor = Colors.Red;
    //now see if just one char is a -
    if (CheckDash(e.NewTextValue)) PowerLossEstimate.TextColor = Colors.LightGreen;

    //write it to preferences
    if (PowerLossEstimate.TextColor != Colors.Red && PowerLossEstimate.Text.Length != 0)
    {
      Preferences.Set("BatteryPowerLossEstimate", PowerLossEstimate.Text);
    }
  }

  private void PowerLossEstimate_Completed(object sender, EventArgs e)
  {
    //Write to preferences
    if (PowerLossEstimate.TextColor != Colors.Red)
    {
      Preferences.Set("BatteryPowerLossEstimate", PowerLossEstimate.Text);
      //dismiss keyboard
      PowerLossEstimate.IsEnabled = false;
      PowerLossEstimate.IsEnabled = true;
    }
  }

  private async void PowerLossEstimatelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Power loss estimated value that happens inside the battery pack due to battery and cables resistance.", "OK");
  }


  //helpers
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

  public bool CheckDash(string s)
  {
    bool validNumber = false;

    if (s.Length == 1 && s[0] == '-')
    {
      validNumber = true;
    }
    return validNumber;
  }

}