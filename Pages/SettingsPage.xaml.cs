namespace TSDZ2Monitor.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	public static ParametersData p = new();
  readonly string fileName = "TSDZ2ParameterData.json";

  private async void SaveParameters(object sender, EventArgs e)
	{
    bool doit = await DisplayAlert("Danger", "You are about to overwrite the default parameters file. \nAre you sure? \nThere is no going back!!!", "Sure", "Cancel");
    if (!doit) return;
    Debug.WriteLine("Save Parameters");

		p.BatteryMaxCurrent = Preferences.Get("BatteryMaxCurrent", "11");
    p.BatteryLowCutOff = Preferences.Get("BatteryLowCutOff", "39");
    p.BatteryResistance = Preferences.Get("BatteryResistance", "200");
    p.BatteryVoltageEstimate = Preferences.Get("BatteryVoltageEstimate", "0");
    p.BatteryResistanceEstimate = Preferences.Get("BatteryResistanceEstimate", "0");
    p.BatteryPowerLossEstimate = Preferences.Get("PowerLossEstimate", "0");

    string mainDir = FileSystem.Current.AppDataDirectory;
    string targetFile = System.IO.Path.Combine(mainDir, fileName);

    var serializedData = JsonSerializer.Serialize(p);
    File.WriteAllText(targetFile, serializedData);

  }
  private async void LoadParameters(object sender, EventArgs e)
  {
    bool doit = await DisplayAlert("Danger", "You are about to overwrite ALL your settings with previously saved defaults. \nAre you sure? \nThere is no going back!!!", "Sure", "Cancel");
    if (!doit) return;

    Debug.WriteLine("Loading and overriding default parameters");

    string mainDir = FileSystem.Current.AppDataDirectory;
    string targetFile = System.IO.Path.Combine(mainDir, fileName);

    //Check if file exists
    if (!File.Exists(targetFile))
    {
      await DisplayAlert("Alert", "The file TSDZ2ParameterData.json does not exist. Did you save the parameter defaults?", "OK");
      return;
    }

    var rawData = File.ReadAllText(targetFile);
    p = JsonSerializer.Deserialize<ParametersData>(rawData);

    Preferences.Get("BatteryMaxCurrent", p.BatteryMaxCurrent);
    Preferences.Get("BatteryLowCutOff", p.BatteryLowCutOff);
    Preferences.Get("BatteryResistance", p.BatteryResistance);
    Preferences.Get("BatteryVoltageEstimate", p.BatteryVoltageEstimate);
    Preferences.Get("BatteryResistanceEstimate", p.BatteryResistanceEstimate);
    Preferences.Get("PowerLossEstimate", p.BatteryPowerLossEstimate);
  }
}