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
    Preferences.Get("VariousTemperatureUnits", p.VariousUnits);

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

    Preferences.Get("AssistLevelsNumberOfAssistLevels", p.AssistLevelsNumberOfAssistLevels);

    Preferences.Get("AssistLevelPower1", p.AssistLevelPower1);
    Preferences.Get("AssistLevelPower2", p.AssistLevelPower2);
    Preferences.Get("AssistLevelPower3", p.AssistLevelPower3);
    Preferences.Get("AssistLevelPower4", p.AssistLevelPower4);
    Preferences.Get("AssistLevelPower5", p.AssistLevelPower5);
    Preferences.Get("AssistLevelPower6", p.AssistLevelPower6);
    Preferences.Get("AssistLevelPower7", p.AssistLevelPower7);
    Preferences.Get("AssistLevelPower8", p.AssistLevelPower8);
    Preferences.Get("AssistLevelPower9", p.AssistLevelPower9);

    Preferences.Get("AssistLevelTorque1", p.AssistLevelTorque1);
    Preferences.Get("AssistLevelTorque2", p.AssistLevelTorque2);
    Preferences.Get("AssistLevelTorque3", p.AssistLevelTorque3);
    Preferences.Get("AssistLevelTorque4", p.AssistLevelTorque4);
    Preferences.Get("AssistLevelTorque5", p.AssistLevelTorque5);
    Preferences.Get("AssistLevelTorque6", p.AssistLevelTorque6);
    Preferences.Get("AssistLevelTorque7", p.AssistLevelTorque7);
    Preferences.Get("AssistLevelTorque8", p.AssistLevelTorque8);
    Preferences.Get("AssistLevelTorque9", p.AssistLevelTorque9);

    Preferences.Get("AssistLevelCadence1", p.AssistLevelCadence1);
    Preferences.Get("AssistLevelCadence2", p.AssistLevelCadence2);
    Preferences.Get("AssistLevelCadence3", p.AssistLevelCadence3);
    Preferences.Get("AssistLevelCadence4", p.AssistLevelCadence4);
    Preferences.Get("AssistLevelCadence5", p.AssistLevelCadence5);
    Preferences.Get("AssistLevelCadence6", p.AssistLevelCadence6);
    Preferences.Get("AssistLevelCadence7", p.AssistLevelCadence7);
    Preferences.Get("AssistLevelCadence8", p.AssistLevelCadence8);
    Preferences.Get("AssistLevelCadence9", p.AssistLevelCadence9);

    Preferences.Get("AssistLevelEMTB1", p.AssistLevelEMTB1);
    Preferences.Get("AssistLevelEMTB2", p.AssistLevelEMTB2);
    Preferences.Get("AssistLevelEMTB3", p.AssistLevelEMTB3);
    Preferences.Get("AssistLevelEMTB4", p.AssistLevelEMTB4);
    Preferences.Get("AssistLevelEMTB5", p.AssistLevelEMTB5);
    Preferences.Get("AssistLevelEMTB6", p.AssistLevelEMTB6);
    Preferences.Get("AssistLevelEMTB7", p.AssistLevelEMTB7);
    Preferences.Get("AssistLevelEMTB8", p.AssistLevelEMTB8);
    Preferences.Get("AssistLevelEMTB9", p.AssistLevelEMTB9);

    Preferences.Get("AssistLevelWalkFeature", p.AssistLevelWalkFeature);
    Preferences.Get("AssistLevelWalk1", p.AssistLevelWalk1);
    Preferences.Get("AssistLevelWalk2", p.AssistLevelWalk2);
    Preferences.Get("AssistLevelWalk3", p.AssistLevelWalk3);
    Preferences.Get("AssistLevelWalk4", p.AssistLevelWalk4);
    Preferences.Get("AssistLevelWalk5", p.AssistLevelWalk5);
    Preferences.Get("AssistLevelWalk6", p.AssistLevelWalk6);
    Preferences.Get("AssistLevelWalk7", p.AssistLevelWalk7);
    Preferences.Get("AssistLevelWalk8", p.AssistLevelWalk8);
    Preferences.Get("AssistLevelWalk9", p.AssistLevelWalk9);
    Preferences.Get("AssistLevelWalkCruiseControl", p.AssistLevelWalkCruiseControl);
  }
}