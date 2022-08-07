namespace TSDZ2Monitor.Pages.Parameters;

public partial class WheelPage : ContentPage
{
  public bool checkInput = false;
  public WheelPage()
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
    WheelMaxSpeed.Text = Preferences.Get("WheelMaxSpeed", "25");
    WheelCircumference.Text = Preferences.Get("WheelCircumference", "2075");

    //convert to imperial if required
    if (Preferences.Get("VariousUnits", "") == "Imperial")  //i.e. mph, inches instead of km/hr, mm
    {
      double speed = Double.Parse(WheelMaxSpeed.Text);
      speed = speed / 1.609344;
      WheelMaxSpeed.Text = Math.Round(speed).ToString();

      double circ = Double.Parse(WheelCircumference.Text);
      circ = circ / 25.4;
      WheelCircumference.Text = Math.Round(circ).ToString();
    }


    WheelDiameter.Text = "";
    DiameterUnits.IsToggled = true;
    DiameterUnits.ThumbColor = Colors.Green;

    checkInput = true;
  }

  //-------Wheel Max Speed------------------------------------------------
  private void WheelMaxSpeed_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    WheelMaxSpeed.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) WheelMaxSpeed.TextColor = Colors.LightGreen;

    if (WheelMaxSpeed.TextColor != Colors.Red && WheelMaxSpeed.Text.Length != 0)
    {
      if (Preferences.Get("VariousUnits", "") == "Metric")  //i.e. mph, inches instead of km/hr, mm
      {
        Preferences.Set("WheelMaxSpeed", WheelMaxSpeed.Text);
      }
      else  //change to kph for storing
      {
        double speed = Double.Parse(WheelMaxSpeed.Text);
        speed = speed * 1.609344;
        Preferences.Set("WheelMaxSpeed", Math.Round(speed).ToString());
      }
    }
  }

  private void WheelMaxSpeed_Completed(object sender, EventArgs e)
  {
    if (WheelMaxSpeed.TextColor != Colors.Red && WheelMaxSpeed.Text.Length != 0)
    {
      if (Preferences.Get("VariousUnits", "") == "Metric")  //i.e. mph, inches instead of km/hr, mm
      {
        Preferences.Set("WheelMaxSpeed", WheelMaxSpeed.Text);
      }
      else  //change to kph for storing
      {
        double speed = Double.Parse(WheelMaxSpeed.Text);
        speed = speed * 1.609344;
        Preferences.Set("WheelMaxSpeed", Math.Round(speed).ToString());
      }
    }

    //dismiss keyboard
    WheelMaxSpeed.IsEnabled = false;
    WheelMaxSpeed.IsEnabled = true;
  }

  private async void OnWheelMaxSpeedLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enter the speed limit from where the motor will fade out power from.", "OK");
  }


  //-------Wheel Circumference------------------------------------------------
  private void WheelCircumference_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    WheelCircumference.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) WheelCircumference.TextColor = Colors.LightGreen;

    if (WheelCircumference.TextColor != Colors.Red && WheelCircumference.Text.Length != 0)
    {
      if (Preferences.Get("VariousUnits", "") == "Metric")
      {
        Preferences.Set("WheelCircumference", WheelCircumference.Text);
      }
      else
      {
        double circ = Double.Parse(WheelCircumference.Text);
        circ = circ * 25.4;
        Preferences.Set("WheelCircumference", Math.Round(circ).ToString());
      }
    }
  }

  private void WheelCircumference_Completed(object sender, EventArgs e)
  {
    if (WheelCircumference.TextColor != Colors.Red && WheelCircumference.Text.Length != 0)
    {
      if (Preferences.Get("VariousUnits", "") == "Metric")
      {
        Preferences.Set("WheelCircumference", WheelCircumference.Text);
      }
      else
      {
        double circ = Double.Parse(WheelCircumference.Text);
        circ = circ * 25.4;
        Preferences.Set("WheelCircumference", Math.Round(circ).ToString());
      }
    }

    //dismiss keyboard
    WheelCircumference.IsEnabled = false;
    WheelCircumference.IsEnabled = true;
  }

  private async void OnWheelCircumferenceLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enter your wheel circumference so that speed and distance are correctly calculated.", "OK");
  }


  //-------Wheel Diameter------------------------------------------------
  private void WheelDiameter_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    WheelDiameter.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) WheelDiameter.TextColor = Colors.Orange;

    DoCircumferenceCalcAndStore(e.NewTextValue);
  }

  private void WheelDiameter_Completed(object sender, EventArgs e)
  {
    if (WheelDiameter.TextColor != Colors.Red && WheelDiameter.Text.Length != 0)
    {
      DoCircumferenceCalcAndStore(WheelDiameter.Text);
    }

    //dismiss keyboard
    WheelDiameter.IsEnabled = false;
    WheelDiameter.IsEnabled = true;
  }

  public void DoCircumferenceCalcAndStore(string d)
  {
    //calculate the circumference
    if (d == string.Empty) return; //shouldn't get here anyway?

    double c = double.Parse(d) * Math.PI;
    //I need to convert to mm to save in preferences, but display
    //as mm or inches depending on VariousUnits selected

    if (DiameterUnits.IsToggled) //Metric cm
    {
      //to get from cm to mm
    }
    else //imperial
    {
      c = c * 25.4; //to get from inches to mm
    }

    if (WheelDiameter.TextColor != Colors.Red && WheelDiameter.Text.Length != 0)
    {
      //save as mm regardless
      string s = Math.Round(c).ToString();
      WheelCircumference.Text = s;  //but get as whole mm
      Preferences.Set("WheelCircumference", s);

      if (Preferences.Get("VariousUnits", "Metric") == "Imperial")
      {
        c = c / 25.4;
        WheelCircumference.Text = Math.Round(c).ToString();
      }
    }
  }

  private void DiameterUnits_Toggled(object sender, EventArgs e)
  {
    WheelDiameter.Text = "";
    if (DiameterUnits.IsToggled)
    {
      DiameterUnits.ThumbColor = Colors.Green;
    }
    else
    {
      DiameterUnits.ThumbColor = Colors.Red;
    }
  }


  private async void OnWheelDiameterLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enter your wheel diameter to calculate the circumference.\r\nYou will need to select the Radius units. The Circumference display will depend on what system units is selected in Various. (Internally stored as mm)", "OK");
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