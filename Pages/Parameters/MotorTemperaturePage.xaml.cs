namespace TSDZ2Monitor.Pages.Parameters;

public partial class MotorTemperaturePage : ContentPage
{
  public List<string> motorTemperatureFeature;
  public string temperatureUnit;

  public bool switchEventDisable = true;  //need to stop IsToggled event when first loading preferences
  public bool checkValues = false;          //need to stop text checking when toggling

  public MotorTemperaturePage()
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
    checkValues = false;

    temperatureUnit = Preferences.Get("VariousTemperatureUnits", "Celsius");

    motorTemperatureFeature = new() { "Throttle", "Temperature", "Disabled" };
    MotorTemperatureFeature.ItemsSource = motorTemperatureFeature;
    for (int i = 0; i < motorTemperatureFeature.Count; i++)
    {
      if (motorTemperatureFeature[i] == Preferences.Get("MotorTemperatureFeature", "Throttle")) MotorTemperatureFeature.SelectedIndex = i;
    }

    if (temperatureUnit == "Celsius")
    {
      //no conversion needed as store in Celsius
      MotorTemperatureMinLimit.Text = Preferences.Get("MotorTemperatureMinLimit", "");
      MotorTemperatureMaxLimit.Text = Preferences.Get("MotorTemperatureMaxLimit", "");
    }
    else //Fahrenheit
    {
      MotorTemperatureMinLimit.Text = CelsiusToFahrenheit(Preferences.Get("MotorTemperatureMinLimit", ""));
      MotorTemperatureMaxLimit.Text = CelsiusToFahrenheit(Preferences.Get("MotorTemperatureMaxLimit", ""));
    }

    checkValues = true;
  }

  //-------------Motor Temperature Feature-------------------------------
  private void MotorTemperatureFeature_SelectedIndexChanged(object sender, EventArgs e)
  {
    var picker = (Picker)sender;
    int selectedIndex = picker.SelectedIndex;
    if (selectedIndex != -1) Preferences.Set("MotorTemperatureFeature", (string)picker.ItemsSource[selectedIndex]);
  }

  private async void OnMotorTemperatureFeatureLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "NOTE: THIS SETTING ENABLES THROTTLE. You must also enable throttle in STREET MODE to fully activate. \r\n\"disabled\" means that neither motor temperature limit function nor throttle is enabled. \r\nSet to \"temperature\" to enable the automatic motor temperature control limit or set to \"throttle\" to enable the throttle.\r\nNOTE: Do NOT enable the throttle if you have installed the motor temperature sensor. If you have the temp sensor installed you need to either have the motor temperature limit function enabled or everything disabled.\r\n", "OK");
  }



  //-------Motor Temperature Min Limit------------------------------------------------
  private void MotorTemperatureMinLimit_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    MotorTemperatureMinLimit.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) MotorTemperatureMinLimit.TextColor = Colors.LightGreen;

    if (MotorTemperatureMinLimit.TextColor != Colors.Red && MotorTemperatureMinLimit.Text.Length != 0)
    {
      SaveTemperature();
    }
  }

  private void MotorTemperatureMinLimit_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (MotorTemperatureMinLimit.TextColor != Colors.Red && MotorTemperatureMinLimit.Text.Length != 0)
    {
      SaveTemperature();
    }

    //dismiss keyboard
    MotorTemperatureMinLimit.IsEnabled = false;
    MotorTemperatureMinLimit.IsEnabled = true;
  }

  private async void MotorTemperatureMinLimitLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the minimum motor temperature at which the power will start to be limited.", "OK");
  }


  //-------Motor Temperature max Limit------------------------------------------------
  private void MotorTemperatureMaxLimit_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    MotorTemperatureMaxLimit.TextColor = Colors.Red;
    if (CheckDecimal(e.NewTextValue)) MotorTemperatureMaxLimit.TextColor = Colors.LightGreen;

    if (MotorTemperatureMaxLimit.TextColor != Colors.Red && MotorTemperatureMaxLimit.Text.Length != 0)
    {
      SaveTemperature();
    }
  }

  private void MotorTemperatureMaxLimit_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (MotorTemperatureMaxLimit.TextColor != Colors.Red && MotorTemperatureMaxLimit.Text.Length != 0)
    {
      SaveTemperature();
    }

    //dismiss keyboard
    MotorTemperatureMaxLimit.IsEnabled = false;
    MotorTemperatureMaxLimit.IsEnabled = true;
  }

  private async void MotorTemperatureMaxLimitLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "A maximum value of 450W is recommended", "OK");
  }


  //------Save Motor Temperature text fields in Celsius
  public void SaveTemperature()
  {
    if (!checkValues) return;

    if (temperatureUnit == "Celsius")
    {
      Preferences.Set("MotorTemperatureMinLimit", MotorTemperatureMinLimit.Text);
      Preferences.Set("MotorTemperatureMaxLimit", MotorTemperatureMaxLimit.Text);
    }
    else //Fahrenheit
    {
      Preferences.Set("MotorTemperatureMinLimit", FahrenheitToCelsius(MotorTemperatureMinLimit.Text));
      Preferences.Set("MotorTemperatureMaxLimit", FahrenheitToCelsius(MotorTemperatureMaxLimit.Text));
    }
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

  public static string CelsiusToFahrenheit(String t)
  {
    if (t == string.Empty) return string.Empty;
    double temp = (double.Parse(t) * 1.8) + 32.0;
    temp = Math.Truncate(temp * 100) / 100;
    return String.Format("{0:N0}", temp);
  }

  public static string FahrenheitToCelsius(String t)
  {
    if (t == string.Empty) return string.Empty;
    double temp = (double.Parse(t) - 32.0) / 1.8;
    temp = Math.Truncate(temp * 100) / 100;
    return String.Format("{0:N0}", temp);
  }
}