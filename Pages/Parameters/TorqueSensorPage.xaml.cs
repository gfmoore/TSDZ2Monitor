namespace TSDZ2Monitor.Pages.Parameters;

public partial class TorqueSensorPage : ContentPage
{
  public bool checkInput = false;

  public string variousUnits;
  public TorqueSensorPage()
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

    if (Preferences.Get("TorqueSensorAssistWOPedal", "false") == "true")
    {
      TorqueSensorAssistWOPedal.IsToggled = true;
      TorqueSensorAssistWOPedal.ThumbColor = Colors.Green;
    }
    else
    {
      TorqueSensorAssistWOPedal.IsToggled = false;
      TorqueSensorAssistWOPedal.ThumbColor = Colors.Red;
    }

    checkInput = false;  //stop activating text changed events
    TorqueSensorADCThreshold.Text = Preferences.Get("TorqueSensorADCThreshold", "10");

    if (Preferences.Get("TorqueSensorCoastBrake", "false") == "true")
    {
      TorqueSensorCoastBrake.IsToggled = true;
      TorqueSensorCoastBrake.ThumbColor = Colors.Green;
    }
    else
    {
      TorqueSensorCoastBrake.IsToggled = false;
      TorqueSensorCoastBrake.ThumbColor = Colors.Red;
    }

    TorqueSensorCoastBrakeADC.Text = Preferences.Get("TorqueSensorCoastBrakeADC", "5");

    if (Preferences.Get("TorqueSensorCalibration", "true") == "true")
    {
      TorqueSensorCalibration.IsToggled = true;
      TorqueSensorCalibration.ThumbColor = Colors.Green;
    }
    else
    {
      TorqueSensorCalibration.IsToggled = false;
      TorqueSensorCalibration.ThumbColor = Colors.Red;
    }

    TorqueSensorADCStep.Text = Preferences.Get("TorqueSensorADCStep", "30");
    TorqueSensorADCOffset.Text = Preferences.Get("TorqueSensorADCOffset", "148");
    TorqueSensorADCMax.Text = Preferences.Get("TorqueSensorADCMax", "306");

    if (variousUnits == "Metric")
    {
      TorqueSensorWeightOnPedal.Text = Preferences.Get("TorqueSensorWeightOnPedal", "20");
    }
    else
    {
      double w = Double.Parse(Preferences.Get("TorqueSensorWeightOnPedal", "20"));
      w = w * 2.20462262185;
      TorqueSensorWeightOnPedal.Text = Math.Round(w).ToString();
    }


    TorqueSensorADCOnWeight.Text = Preferences.Get("TorqueSensorADCOnWeight", "263");

    if (Preferences.Get("TorqueSensorDefaultWeight", "false") == "true")
    {
      TorqueSensorDefaultWeight.IsToggled = true;
      TorqueSensorDefaultWeight.ThumbColor = Colors.Green;
    }
    else
    {
      TorqueSensorDefaultWeight.IsToggled = false;
      TorqueSensorDefaultWeight.ThumbColor = Colors.Red;
    }

    checkInput = true;

  }

  //-------TorqueSensor Assist WO Pedal------------------------------------------------
  private void TorqueSensorAssistWOPedal_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (TorqueSensorAssistWOPedal.IsToggled)
    {
      Preferences.Set("TorqueSensorAssistWOPedal", "true");
      TorqueSensorAssistWOPedal.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("TorqueSensorAssistWOPedal", "false");
      TorqueSensorAssistWOPedal.ThumbColor = Colors.Red;
    }
  }

  private async void OnTorqueSensorAssistWOPedalLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enable to get motor assistance once you press the\r\npedals even without rotating them. \r\n\r\nIt is recommended to  keep disabled if you do not have brake sensors  installed.\r\n", "OK");
  }


  //-------Torque Sensor ADC Threshold------------------------------------------------
  private void TorqueSensorADCThreshold_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorADCThreshold.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorADCThreshold.TextColor = Colors.LightGreen;

    if (TorqueSensorADCThreshold.TextColor != Colors.Red && TorqueSensorADCThreshold.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCThreshold", TorqueSensorADCThreshold.Text);
    }
  }

  private void TorqueSensorADCThreshold_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorADCThreshold.TextColor != Colors.Red && TorqueSensorADCThreshold.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCThreshold", TorqueSensorADCThreshold.Text);
    }

    //dismiss keyboard
    TorqueSensorADCThreshold.IsEnabled = false;
    TorqueSensorADCThreshold.IsEnabled = true;
  }

  private async void OnTorqueSensorADCThresholdLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Works in addition to the initial assistance with just the\r\npush on the pedals - without rotation - for an immediate start. \r\n\r\nNow, this function is also activated with the bike in motion, when you resume pedaling after a break.\r\n\r\nCAUTION: By enabling the BOOST function at the same time, the effect increases! This can cause greater transmission stress.\r\n", "OK");
  }


  //-------TorqueSensor Coast Brake------------------------------------------------
  private void TorqueSensorCoastBrake_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (TorqueSensorCoastBrake.IsToggled)
    {
      Preferences.Set("TorqueSensorCoastBrake", "true");
      TorqueSensorCoastBrake.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("TorqueSensorCoastBrake", "false");
      TorqueSensorCoastBrake.ThumbColor = Colors.Red;
    }
  }

  private async void OnTorqueSensorCoastBrakeLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Needs to be enabled if you have a TSDZ2 coast brake version.", "OK");
  }


  //-------Torque Sensor Coast Brake ADC------------------------------------------------
  private void TorqueSensorCoastBrakeADC_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorCoastBrakeADC.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorCoastBrakeADC.TextColor = Colors.LightGreen;

    //not > 40
    if (TorqueSensorCoastBrakeADC.TextColor != Colors.Red && int.Parse(TorqueSensorCoastBrakeADC.Text) > 40)
    {
      TorqueSensorCoastBrakeADC.TextColor = Colors.Red;
    }

    //not < 5
    if (TorqueSensorCoastBrakeADC.TextColor != Colors.Red && int.Parse(TorqueSensorCoastBrakeADC.Text) < 50)
    {
      TorqueSensorCoastBrakeADC.TextColor = Colors.Red;
    }

    if (TorqueSensorCoastBrakeADC.TextColor != Colors.Red && TorqueSensorCoastBrakeADC.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorCoastBrakeADC", TorqueSensorCoastBrakeADC.Text);
    }
  }

  private void TorqueSensorCoastBrakeADC_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorCoastBrakeADC.TextColor != Colors.Red && TorqueSensorCoastBrakeADC.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorCoastBrakeADC", TorqueSensorCoastBrakeADC.Text);
    }

    //dismiss keyboard
    TorqueSensorCoastBrakeADC.IsEnabled = false;
    TorqueSensorCoastBrakeADC.IsEnabled = true;
  }

  private async void OnTorqueSensorCoastBrakeADCLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The sensitivity of the coaster brake in ADC steps when pushing pedals backward.\r\nLow value takes less strength, high value takes more strength. Decide for yourself the optimal value.\r\nLimits from 5 to 40\r\n", "OK");
  }


  //-------Torque Sensor Calibration------------------------------------------------
  private void TorqueSensorCalibration_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (TorqueSensorCalibration.IsToggled)
    {
      Preferences.Set("TorqueSensorCalibration", "true");
      TorqueSensorCalibration.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("TorqueSensorCalibration", "false");
      TorqueSensorCalibration.ThumbColor = Colors.Red;
    }
  }

  private async void OnTorqueSensorCalibrationLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enable only after having entered the actual values of “Pedal torque ADC offset” and “Pedal torque ADC max”, obtained from the calibration procedure: \r\nEnabling without having entered the correct values can lead to unpredictable operations.\r\n", "OK");
  }



  //-------Torque Sensor ADC Step------------------------------------------------
  private void TorqueSensorADCStep_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorADCStep.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorADCStep.TextColor = Colors.LightGreen;

    if (TorqueSensorADCStep.TextColor != Colors.Red && TorqueSensorADCStep.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCStep", TorqueSensorADCStep.Text);
    }
  }

  private void TorqueSensorADCStep_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorADCStep.TextColor != Colors.Red && TorqueSensorADCStep.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCStep", TorqueSensorADCStep.Text);
    }

    //dismiss keyboard
    TorqueSensorADCStep.IsEnabled = false;
    TorqueSensorADCStep.IsEnabled = true;
  }

  private async void OnTorqueSensorADCStepLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "A conversion factor of the torque applied to the pedal.\r\nIt is used to calculate the correct ratio between the assistance factor and the human power (only in “Power assist” mode). The actual value obtained from the calibration (above) should be entered as found in the Configurations>Technical section.\r\nThis parameter is not used for the calculation of the human power shown on the display.\r\n", "OK");
  }


  //-------Torque Sensor ADC Offset------------------------------------------------
  private void TorqueSensorADCOffset_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorADCOffset.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorADCOffset.TextColor = Colors.LightGreen;

    if (TorqueSensorADCOffset.TextColor != Colors.Red && TorqueSensorADCOffset.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCOffset", TorqueSensorADCOffset.Text);
    }
  }

  private void TorqueSensorADCOffset_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorADCOffset.TextColor != Colors.Red && TorqueSensorADCOffset.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCOffset", TorqueSensorADCOffset.Text);
    }

    //dismiss keyboard
    TorqueSensorADCOffset.IsEnabled = false;
    TorqueSensorADCOffset.IsEnabled = true;
  }

  private async void OnTorqueSensorADCOffsetLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "ADC value of the torque sensor without any push on the pedals.\r\nIt is obtained from the calibration procedure to be carried out on the display.\r\nWhen you need to increase the sensitivity at the start, for example with an arm-bike, subtract a number from 1 to 10 from the value obtained. If the power assist wants to go before you do add a number to the value.\r\nCaution: Decreasing the offset value too much can cause an unwanted start and/or a delayed motor stop.\r\n", "OK");
  }


  //-------Torque Sensor ADC Max------------------------------------------------
  private void TorqueSensorADCMax_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorADCMax.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorADCMax.TextColor = Colors.LightGreen;

    if (TorqueSensorADCMax.TextColor != Colors.Red && TorqueSensorADCMax.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCMax", TorqueSensorADCMax.Text);
    }
  }

  private void TorqueSensorADCMax_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorADCMax.TextColor != Colors.Red && TorqueSensorADCMax.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCMax", TorqueSensorADCMax.Text);
    }

    //dismiss keyboard
    TorqueSensorADCMax.IsEnabled = false;
    TorqueSensorADCMax.IsEnabled = true;
  }

  private async void OnTorqueSensorADCMaxLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "ADC value of the torque sensor with the maximum thrust applied to the pedal (cyclist standing, on the right pedal in horizontal position).\r\nIt is obtained from the calibration procedure described above.\r\nThis parameter is used to amplify the range of usage of the torque sensor when it is too limited.\r\nCheck that the assistance is well distributed overall levels and in all modes, if necessary correct the value obtained in plus or minus. Lower value = higher amplification. ", "OK");
  }


  //-------Torque Sensor Weight On Pedal------------------------------------------------
  private void TorqueSensorWeightOnPedal_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorWeightOnPedal.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorWeightOnPedal.TextColor = Colors.LightGreen;

    if (TorqueSensorWeightOnPedal.TextColor != Colors.Red && TorqueSensorWeightOnPedal.Text.Length != 0)
    {
      SaveWeight();
    }
  }

  private void TorqueSensorWeightOnPedal_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorWeightOnPedal.TextColor != Colors.Red && TorqueSensorWeightOnPedal.Text.Length != 0)
    {
      SaveWeight();
    }

    //dismiss keyboard
    TorqueSensorWeightOnPedal.IsEnabled = false;
    TorqueSensorWeightOnPedal.IsEnabled = true;
  }

  public void SaveWeight()
  {
    if (variousUnits == "Metric")
    {
      Preferences.Set("TorqueSensorWeightOnPedal", TorqueSensorWeightOnPedal.Text);
    }
    else
    {
      double w = Double.Parse(TorqueSensorWeightOnPedal.Text);
      w = w / 2.20462262185;
      Preferences.Set("TorqueSensorWeightOnPedal", Math.Round(w).ToString());
    }
  }
  private async void OnTorqueSensorWeightOnPedalLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Weight to be applied to the pedal for the calibration of the ADC value of the torque sensor used for the calculation of the human power to be shown on the display. Use a weight of for example 25 Kg or 55 lb.\r\nIt is not essential, it does not affect the operation of the motor, it only serves for a correct display of human power.\r\n", "OK");
  }

  
  //-------Torque Sensor ADC On Weight------------------------------------------------
  private void TorqueSensorADCOnWeight_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TorqueSensorADCOnWeight.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TorqueSensorADCOnWeight.TextColor = Colors.LightGreen;

    if (TorqueSensorADCOnWeight.TextColor != Colors.Red && TorqueSensorADCOnWeight.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCOnWeight", TorqueSensorADCOnWeight.Text);
    }
  }

  private void TorqueSensorADCOnWeight_Completed(object sender, EventArgs e)
  {
    if (TorqueSensorADCOnWeight.TextColor != Colors.Red && TorqueSensorADCOnWeight.Text.Length != 0)
    {
      Preferences.Set("TorqueSensorADCOnWeight", TorqueSensorADCOnWeight.Text);
    }

    //dismiss keyboard
    TorqueSensorADCOnWeight.IsEnabled = false;
    TorqueSensorADCOnWeight.IsEnabled = true;
  }

  private async void OnTorqueSensorADCOnWeightLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "ADC value of the torque sensor for the calculation of human power to be shown on the display, it is not used for the calculation of the assistance factor.\r\nIt is obtained from the calibration procedure with a weight as defined above. i.e. put 25kg on the right pedal in a horizontal position and brakes applied, or use the “Default weight” option below.\r\n", "OK");
  }


  //-------Torque Sensor Default Weight------------------------------------------------
  private void TorqueSensorDefaultWeight_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (TorqueSensorDefaultWeight.IsToggled)
    {
      Preferences.Set("TorqueSensorDefaultWeight", "true");
      TorqueSensorDefaultWeight.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("TorqueSensorDefaultWeight", "false");
      TorqueSensorDefaultWeight.ThumbColor = Colors.Red;
    }
  }

  private async void OnTorqueSensorDefaultWeightLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "After having entered the calibration values in \"Torque ADC offset\" and \"Torque ADC max\", with this function it is possible to calculate an estimated value of \"Torque ADC on weight\" for a weight of 25Kg. The value is less accurate than that obtained with real calibration, but it is adequate for the purpose.", "OK");
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