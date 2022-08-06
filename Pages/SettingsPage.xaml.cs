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
    
    Preferences.Get("MotorVoltage", p.MotorVoltage);
    Preferences.Get("MotorPowerMax", p.MotorPowerMax);
    Preferences.Get("MotorAcceleration", p.MotorAcceleration);
    Preferences.Get("MotorDeceleration", p.MotorDeceleration);
    Preferences.Get("MotorFastStop", p.MotorFastStop);
    Preferences.Get("MotorFieldWeakening", p.MotorFieldWeakening);

    Preferences.Get("MotorTemperatureFeature", p.MotorTemperatureFeature);
    Preferences.Get("MotorTemperatureMinLimit", p.MotorTemperatureMinLimit);
    Preferences.Get("MotorTemperatureMaxLimit", p.MotorTemperatureMaxLimit);
    Preferences.Get("MotorTemperatureTemperatureUnits", p.MotorTemperatureUnits);

    Preferences.Get("SoCDisplayText", p.SoCDisplayText);
    Preferences.Get("SoCResetAtVoltage", p.SoCResetAtVoltage);
    Preferences.Get("SoCBatteryTotalWH", p.SoCBatteryTotalWH);
    Preferences.Get("SoCUsedWH", p.SoCUsedWH);
    Preferences.Get("SoCManualReset", p.SoCManualReset);

    Preferences.Get("StartupBoostFeature", p.StartupBoostFeature);
    Preferences.Get("StartupBoostTorqueFactor", p.StartupBoostTorqueFactor);
    Preferences.Get("StartupBoostCadenceStep", p.StartupBoostCadenceStep);

    Preferences.Get("StreetModeEnableMode", p.StreetModeEnableMode);
    Preferences.Get("StreetModeEnableAtStartup", p.StreetModeEnableAtStartup);
    Preferences.Get("StreetModeSpeedLimit", p.StreetModeSpeedLimit);
    Preferences.Get("StreetModeMotorPowerLimit", p.StreetModeMotorPowerLimit);
    Preferences.Get("StreetModeThrottleEnable", p.StreetModeThrottleEnable);
    Preferences.Get("StreetModeCruiseEnable", p.StreetModeCruiseEnable);
    Preferences.Get("StreetModeHotkeyEnable", p.StreetModeHotkeyEnable);

    Preferences.Get("VariousUnits", p.VariousUnits);
    Preferences.Get("VariousLightsConfiguration", p.VariousLightsConfiguration);
    Preferences.Get("VariousAssistWithError", p.VariousAssistWithError);
    Preferences.Get("VariousVirtualThrottleStep", p.VariousVirtualThrottleStep);

    Preferences.Get("TechnicalADCBatteryCurrent", p.TechnicalADCBatteryCurrent);
    Preferences.Get("TechnicalADVThrottleSensor", p.TechnicalADCThrottleSensor);
    Preferences.Get("TechnicalThrottleSensor", p.TechnicalThrottleSensor);
    Preferences.Get("TechnicalADCTorqueSensor", p.TechnicalADCTorqueSensor);
    Preferences.Get("TechnicalADCTorqueDelta", p.TechnicalADCTorqueDelta);
    Preferences.Get("TechnicalADCTorqueBoost", p.TechnicalADCTorqueBoost);
    Preferences.Get("TechnicalADCTorqueStepCalc", p.TechnicalADCTorqueStepCalc);
    Preferences.Get("TechnicalPedalCadence", p.TechnicalPedalCadence);
    Preferences.Get("TechnicalPWMDutyCycle", p.TechnicalPWMDutyCycle);
    Preferences.Get("TechnicalMotorSpeed", p.TechnicalMotorSpeed);
    Preferences.Get("TechnicalMotorFOC", p.TechnicalMotorFOC);
    Preferences.Get("TechnicalHallSensors", p.TechnicalHallSensors);

    Preferences.Get("TorqueSensorAssistWOPedal", p.TorqueSensorAssistWOPedal);
    Preferences.Get("TorqueSensorADCThreshold", p.TorqueSensorADCThreshold);
    Preferences.Get("TorqueSensorCoastBrake", p.TorqueSensorCoastBrake);
    Preferences.Get("TorqueSensorCoastBrakeADC", p.TorqueSensorCoastBrakeADC);
    Preferences.Get("TorqueSensorCalibration", p.TorqueSensorCalibration);
    Preferences.Get("TorqueSensorADCStep", p.TorqueSensorADCStep);
    Preferences.Get("TorqueSensorADCOffset", p.TorqueSensorADCOffset);
    Preferences.Get("TorqueSensorADCMax", p.TorqueSensorADCMax);
    Preferences.Get("TorqueSensorWeightOnPedal", p.TorqueSensorWeightOnPedal);
    Preferences.Get("TorqueSensorADCOnWeight", p.TorqueSensorADCOnWeight);
    Preferences.Get("TorqueSensorDefaultWeight", p.TorqueSensorDefaultWeight);

    Preferences.Get("WheelMaxSpeed", p.WheelMaxSpeed);
    Preferences.Get("WheelCircumference", p.WheelCircumference);

    Preferences.Get("TripMemoriesOdometer", p.TripMemoriesOdometer);
    Preferences.Get("TripMemoriesTripA", p.TripMemoriesTripA);
    Preferences.Get("TripMemoriesTripB", p.TripMemoriesTripB);
    Preferences.Get("TripMemoriesTripAReset", p.TripMemoriesTripAAutoReset);
    Preferences.Get("TripMemoriesTripAAutoResetHours", p.TripMemoriesTripAAutoResetHours);
    Preferences.Get("TripMemoriesTripBReset", p.TripMemoriesTripBAutoReset);
    Preferences.Get("TripMemoriesTripBResetHours", p.TripMemoriesTripBAutoResetHours);
  }
}