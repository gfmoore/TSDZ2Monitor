namespace TSDZ2Monitor.Pages;

public partial class ParametersListPage : ContentPage
{
  private Label label;

  public ParametersListPage(ParametersListViewModel viewModel)
	{
		InitializeComponent();
    BindingContext = viewModel;

    label = new() { Text = $"Battery Max Current:  {Preferences.Get("BatteryMaxCurrent", "")}", TextColor = Colors.LightBlue, FontSize = 20};
    Parameters.Add(label);

    label = new() { Text = $"Battery Low Cut Off:  {Preferences.Get("BatteryLowCutOff", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);
    
    label = new() { Text = $"Battery Resistance:  {Preferences.Get("BatteryResistance", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);
    //Current values?
    //label = new() { Text = $"Battery Voltage Estimate:  {Preferences.Get("BatteryVoltageEstimate", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    //Parameters.Add(label);

    //label = new() { Text = $"Battery Resistance Estimate:  {Preferences.Get("BatteryResistanceEstimate", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    //Parameters.Add(label);

    //label = new() { Text = $"Battery Power Loss Estimate:  {Preferences.Get("BatteryPowerLossEstimate", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    //Parameters.Add(label);
    
    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Motor Voltage:  {Preferences.Get("MotorVoltage", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Power Max:  {Preferences.Get("MotorPowerMax", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Acceleration:  {Preferences.Get("MotorAcceleration", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Deceleration:  {Preferences.Get("MotorDeceleration", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Fast Stop:  {Preferences.Get("MotorFastStop", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Field Weakening:  {Preferences.Get("MotorFieldWeakening", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Motor Temperature Feature:  {Preferences.Get("MotorTemperatureFeature", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Temperature Min Limit:  {Preferences.Get("MotorTemperatureMinLimit", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Motor Temperature Max Limit:  {Preferences.Get("MotorTemperatureMaxLimit", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"SoC Display Text:  {Preferences.Get("SoCDisplayText", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"SoC Reset At Voltage:  {Preferences.Get("SoCResetAtVoltage", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"SoC Battery Total WH:  {Preferences.Get("SoCBatteryTotalWH", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"SoCUsedWH:  {Preferences.Get("SoCUsedWH", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"SoC Manual Reset:  {Preferences.Get("SoCManualReset", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"StartupBoostFeature:  {Preferences.Get("StartupBoostFeature", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Startup Boost Torque Factor:  {Preferences.Get("StartupBoostTorqueFactor", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Startup Boost Cadence Step:  {Preferences.Get("StartupBoostCadenceStep", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Street Mode Enable Mode:  {Preferences.Get("StreetModeEnableMode", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Street Mode Enable At Startup:  {Preferences.Get("StreetModeEnableAtStartup", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Street Mode Speed Limit:  {Preferences.Get("StreetModeSpeedLimit", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Street Mode Motor Power Limit:  {Preferences.Get("StreetModeMotorPowerLimit", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Street Mode Throttle Enable:  {Preferences.Get("StreetModeThrottleEnable", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Street Mode Cruise Enable:  {Preferences.Get("StreetModeCruiseEnable", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Street Mode Hotkey Enable:  {Preferences.Get("StreetModeHotkeyEnable", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Various Units:  {Preferences.Get("VariousUnits", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Various Temperature Units:  {Preferences.Get("VariousTemperatureUnits", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Various Lights Configuration:  {Preferences.Get("VariousLightsConfiguration", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Various Assist With Error:  {Preferences.Get("VariousAssistWithError", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Various Virtual Throttle Step:  {Preferences.Get("VariousVirtualThrottleStep", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Torque Sensor Assist WO Pedal:  {Preferences.Get("TorqueSensorAssistWOPedal", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor ADC Threshold:  {Preferences.Get("TorqueSensorADCThreshold", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor Coast Brake:  {Preferences.Get("TorqueSensorCoastBrake", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor Coast Brake ADC:  {Preferences.Get("TorqueSensorCoastBrakeADC", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor Calibration:  {Preferences.Get("TorqueSensorCalibration", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor ADC Step:  {Preferences.Get("TorqueSensorADCStep", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor ADC Offset:  {Preferences.Get("TorqueSensorADCOffset", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor ADC Max:  {Preferences.Get("TorqueSensorADCMax", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor Weight On Pedal:  {Preferences.Get("TorqueSensorWeightOnPedal", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor ADC On Weight:  {Preferences.Get("TorqueSensorADCOnWeight", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Torque Sensor Default Weight:  {Preferences.Get("TorqueSensorDefaultWeight", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Wheel Max Speed:  {Preferences.Get("WheelMaxSpeed", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Wheel Circumference:  {Preferences.Get("WheelCircumference", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"Trip Odometer:  {Preferences.Get("TripMemoriesOdometer", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Trip TripA:  {Preferences.Get("TripMemoriesTripA", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Trip TripB:  {Preferences.Get("TripMemoriesTripB", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Trip TripA Reset:  {Preferences.Get("TripMemoriesTripAAutoReset", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Trip TripA Auto Reset Hours:  {Preferences.Get("TripMemoriesTripAAutoResetHours", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Trip TripB Reset:  {Preferences.Get("TripMemoriesTripBAutoReset", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $"Trip TripB Auto Reset Hours:  {Preferences.Get("TripMemoriesTripBAutoResetHours", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);

    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $"AssistLevelsNumberOfAssistLevels:  {Preferences.Get("AssistLevelsNumberOfAssistLevels", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    label = new() { Text = $":  {Preferences.Get("", "")}", TextColor = Colors.LightBlue, FontSize = 20 };
    Parameters.Add(label);


    //Preferences.Get("AssistLevelPower1", p.AssistLevelPower1);
    //Preferences.Get("AssistLevelPower2", p.AssistLevelPower2);
    //Preferences.Get("AssistLevelPower3", p.AssistLevelPower3);
    //Preferences.Get("AssistLevelPower4", p.AssistLevelPower4);
    //Preferences.Get("AssistLevelPower5", p.AssistLevelPower5);
    //Preferences.Get("AssistLevelPower6", p.AssistLevelPower6);
    //Preferences.Get("AssistLevelPower7", p.AssistLevelPower7);
    //Preferences.Get("AssistLevelPower8", p.AssistLevelPower8);
    //Preferences.Get("AssistLevelPower9", p.AssistLevelPower9);

    //Preferences.Get("AssistLevelTorque1", p.AssistLevelTorque1);
    //Preferences.Get("AssistLevelTorque2", p.AssistLevelTorque2);
    //Preferences.Get("AssistLevelTorque3", p.AssistLevelTorque3);
    //Preferences.Get("AssistLevelTorque4", p.AssistLevelTorque4);
    //Preferences.Get("AssistLevelTorque5", p.AssistLevelTorque5);
    //Preferences.Get("AssistLevelTorque6", p.AssistLevelTorque6);
    //Preferences.Get("AssistLevelTorque7", p.AssistLevelTorque7);
    //Preferences.Get("AssistLevelTorque8", p.AssistLevelTorque8);
    //Preferences.Get("AssistLevelTorque9", p.AssistLevelTorque9);

    //Preferences.Get("AssistLevelCadence1", p.AssistLevelCadence1);
    //Preferences.Get("AssistLevelCadence2", p.AssistLevelCadence2);
    //Preferences.Get("AssistLevelCadence3", p.AssistLevelCadence3);
    //Preferences.Get("AssistLevelCadence4", p.AssistLevelCadence4);
    //Preferences.Get("AssistLevelCadence5", p.AssistLevelCadence5);
    //Preferences.Get("AssistLevelCadence6", p.AssistLevelCadence6);
    //Preferences.Get("AssistLevelCadence7", p.AssistLevelCadence7);
    //Preferences.Get("AssistLevelCadence8", p.AssistLevelCadence8);
    //Preferences.Get("AssistLevelCadence9", p.AssistLevelCadence9);

    //Preferences.Get("AssistLevelEMTB1", p.AssistLevelEMTB1);
    //Preferences.Get("AssistLevelEMTB2", p.AssistLevelEMTB2);
    //Preferences.Get("AssistLevelEMTB3", p.AssistLevelEMTB3);
    //Preferences.Get("AssistLevelEMTB4", p.AssistLevelEMTB4);
    //Preferences.Get("AssistLevelEMTB5", p.AssistLevelEMTB5);
    //Preferences.Get("AssistLevelEMTB6", p.AssistLevelEMTB6);
    //Preferences.Get("AssistLevelEMTB7", p.AssistLevelEMTB7);
    //Preferences.Get("AssistLevelEMTB8", p.AssistLevelEMTB8);
    //Preferences.Get("AssistLevelEMTB9", p.AssistLevelEMTB9);

    //Preferences.Get("AssistLevelWalkFeature", p.AssistLevelWalkFeature);
    //Preferences.Get("AssistLevelWalk1", p.AssistLevelWalk1);
    //Preferences.Get("AssistLevelWalk2", p.AssistLevelWalk2);
    //Preferences.Get("AssistLevelWalk3", p.AssistLevelWalk3);
    //Preferences.Get("AssistLevelWalk4", p.AssistLevelWalk4);
    //Preferences.Get("AssistLevelWalk5", p.AssistLevelWalk5);
    //Preferences.Get("AssistLevelWalk6", p.AssistLevelWalk6);
    //Preferences.Get("AssistLevelWalk7", p.AssistLevelWalk7);
    //Preferences.Get("AssistLevelWalk8", p.AssistLevelWalk8);
    //Preferences.Get("AssistLevelWalk9", p.AssistLevelWalk9);
    //Preferences.Get("AssistLevelWalkCruiseControl", p.AssistLevelWalkCruiseControl);

    //Preferences.Get("GraphBatteryCurrentAutoMaxMin", p.GraphBatteryCurrentAutoMaxMin);
    //Preferences.Get("GraphBatteryCurrentMin", p.GraphBatteryCurrentMin);
    //Preferences.Get("GraphBatteryCurrentMax", p.GraphBatteryCurrentMax);
    //Preferences.Get("GraphBatteryCurrentThresholds", p.GraphBatteryCurrentThresholds);
    //Preferences.Get("GraphBatteryCurrentYellowMaxThreshold", p.GraphBatteryCurrentYellowMaxThreshold);
    //Preferences.Get("GraphBatteryCurrentRedMaxThreshold", p.GraphBatteryCurrentRedMaxThreshold);

    //Preferences.Get("GraphBatteryVoltageAutoMaxMin", p.GraphBatteryVoltageAutoMaxMin);
    //Preferences.Get("GraphBatteryVoltageMin", p.GraphBatteryVoltageMin);
    //Preferences.Get("GraphBatteryVoltageMax", p.GraphBatteryVoltageMax);
    //Preferences.Get("GraphBatteryVoltageThresholds", p.GraphBatteryVoltageThresholds);
    //Preferences.Get("GraphBatteryVoltageYellowMaxThreshold", p.GraphBatteryVoltageYellowMaxThreshold);
    //Preferences.Get("GraphBatteryVoltageRedMaxThreshold", p.GraphBatteryVoltageRedMaxThreshold);

    //Preferences.Get("GraphBatterySoCAutoMaxMin", p.GraphBatterySoCAutoMaxMin);
    //Preferences.Get("GraphBatterySoCMin", p.GraphBatterySoCMin);
    //Preferences.Get("GraphBatterySoCMax", p.GraphBatterySoCMax);
    //Preferences.Get("GraphBatterySoCThresholds", p.GraphBatterySoCThresholds);
    //Preferences.Get("GraphBatterySoCYellowMaxThreshold", p.GraphBatterySoCYellowMaxThreshold);
    //Preferences.Get("GraphBatterySoCRedMaxThreshold", p.GraphBatterySoCRedMaxThreshold);

    //Preferences.Get("GraphMotorCurrentAutoMaxMin", p.GraphMotorCurrentAutoMaxMin);
    //Preferences.Get("GraphMotorCurrentMin", p.GraphMotorCurrentMin);
    //Preferences.Get("GraphMotorCurrentMax", p.GraphMotorCurrentMax);
    //Preferences.Get("GraphMotorCurrentThresholds", p.GraphMotorCurrentThresholds);
    //Preferences.Get("GraphMotorCurrentYellowMaxThreshold", p.GraphMotorCurrentYellowMaxThreshold);
    //Preferences.Get("GraphMotorCurrentRedMaxThreshold", p.GraphMotorCurrentRedMaxThreshold);

    //Preferences.Get("GraphMotorTemperatureAutoMaxMin", p.GraphMotorTemperatureAutoMaxMin);
    //Preferences.Get("GraphMotorTemperatureMin", p.GraphMotorTemperatureMin);
    //Preferences.Get("GraphMotorTemperatureMax", p.GraphMotorTemperatureMax);
    //Preferences.Get("GraphMotorTemperatureThresholds", p.GraphMotorTemperatureThresholds);
    //Preferences.Get("GraphMotorTemperatureYellowMaxThreshold", p.GraphMotorTemperatureYellowMaxThreshold);
    //Preferences.Get("GraphMotorTemperatureRedMaxThreshold", p.GraphMotorTemperatureRedMaxThreshold);

    //Preferences.Get("GraphMotorSpeedAutoMaxMin", p.GraphMotorSpeedAutoMaxMin);
    //Preferences.Get("GraphMotorSpeedMin", p.GraphMotorSpeedMin);
    //Preferences.Get("GraphMotorSpeedMax", p.GraphMotorSpeedMax);
    //Preferences.Get("GraphMotorSpeedThresholds", p.GraphMotorSpeedThresholds);
    //Preferences.Get("GraphMotorSpeedYellowMaxThreshold", p.GraphMotorSpeedYellowMaxThreshold);
    //Preferences.Get("GraphMotorSpeedRedMaxThreshold", p.GraphMotorSpeedRedMaxThreshold);

    //Preferences.Get("GraphMotorPWMAutoMaxMin", p.GraphMotorPWMAutoMaxMin);
    //Preferences.Get("GraphMotorPWMMin", p.GraphMotorPWMMin);
    //Preferences.Get("GraphMotorPWMMax", p.GraphMotorPWMMax);
    //Preferences.Get("GraphMotorPWMThresholds", p.GraphMotorPWMThresholds);
    //Preferences.Get("GraphMotorPWMYellowMaxThreshold", p.GraphMotorPWMYellowMaxThreshold);
    //Preferences.Get("GraphMotorPWMRedMaxThreshold", p.GraphMotorPWMRedMaxThreshold);

    //Preferences.Get("GraphMotorFOCAutoMaxMin", p.GraphMotorFOCAutoMaxMin);
    //Preferences.Get("GraphMotorFOCMin", p.GraphMotorFOCMin);
    //Preferences.Get("GraphMotorFOCMax", p.GraphMotorFOCMax);
    //Preferences.Get("GraphMotorFOCThresholds", p.GraphMotorFOCThresholds);
    //Preferences.Get("GraphMotorFOCYellowMaxThreshold", p.GraphMotorFOCYellowMaxThreshold);
    //Preferences.Get("GraphMotorFOCRedMaxThreshold", p.GraphMotorFOCRedMaxThreshold);

    //Preferences.Get("GraphSpeedAutoMaxMin", p.GraphSpeedAutoMaxMin);
    //Preferences.Get("GraphSpeedMin", p.GraphSpeedMin);
    //Preferences.Get("GraphSpeedMax", p.GraphSpeedMax);
    //Preferences.Get("GraphSpeedThresholds", p.GraphSpeedThresholds);
    //Preferences.Get("GraphSpeedYellowMaxThreshold", p.GraphSpeedYellowMaxThreshold);
    //Preferences.Get("GraphSpeedRedMaxThreshold", p.GraphSpeedRedMaxThreshold);

    //Preferences.Get("GraphTripDistanceAutoMaxMin", p.GraphTripDistanceAutoMaxMin);
    //Preferences.Get("GraphTripDistanceMin", p.GraphTripDistanceMin);
    //Preferences.Get("GraphTripDistanceMax", p.GraphTripDistanceMax);
    //Preferences.Get("GraphTripDistanceThresholds", p.GraphTripDistanceThresholds);
    //Preferences.Get("GraphTripDistanceYellowMaxThreshold", p.GraphTripDistanceYellowMaxThreshold);
    //Preferences.Get("GraphTripDistanceRedMaxThreshold", p.GraphTripDistanceRedMaxThreshold);

    //Preferences.Get("GraphCadenceAutoMaxMin", p.GraphCadenceAutoMaxMin);
    //Preferences.Get("GraphCadenceMin", p.GraphCadenceMin);
    //Preferences.Get("GraphCadenceMax", p.GraphCadenceMax);
    //Preferences.Get("GraphCadenceThresholds", p.GraphCadenceThresholds);
    //Preferences.Get("GraphCadenceYellowMaxThreshold", p.GraphCadenceYellowMaxThreshold);
    //Preferences.Get("GraphCadenceRedMaxThreshold", p.GraphCadenceRedMaxThreshold);

    //Preferences.Get("GraphHumanPowerAutoMaxMin", p.GraphHumanPowerAutoMaxMin);
    //Preferences.Get("GraphHumanPowerMin", p.GraphHumanPowerMin);
    //Preferences.Get("GraphHumanPowerMax", p.GraphHumanPowerMax);
    //Preferences.Get("GraphHumanPowerThresholds", p.GraphHumanPowerThresholds);
    //Preferences.Get("GraphHumanPowerYellowMaxThreshold", p.GraphHumanPowerYellowMaxThreshold);
    //Preferences.Get("GraphHumanPowerRedMaxThreshold", p.GraphHumanPowerRedMaxThreshold);

    //Preferences.Get("GraphMotorPowerAutoMaxMin", p.GraphMotorPowerAutoMaxMin);
    //Preferences.Get("GraphMotorPowerMin", p.GraphMotorPowerMin);
    //Preferences.Get("GraphMotorPowerMax", p.GraphMotorPowerMax);
    //Preferences.Get("GraphMotorPowerThresholds", p.GraphMotorPowerThresholds);
    //Preferences.Get("GraphMotorPowerYellowMaxThreshold", p.GraphMotorPowerYellowMaxThreshold);
    //Preferences.Get("GraphMotorPowerRedMaxThreshold", p.GraphMotorPowerRedMaxThreshold);

    //Preferences.Get("GraphWattsPerKmAutoMaxMin", p.GraphWattsPerKmAutoMaxMin);
    //Preferences.Get("GraphWattsPerKmMin", p.GraphWattsPerKmMin);
    //Preferences.Get("GraphWattsPerKmMax", p.GraphWattsPerKmMax);
    //Preferences.Get("GraphWattsPerKmThresholds", p.GraphWattsPerKmThresholds);
    //Preferences.Get("GraphWattsPerKmYellowMaxThreshold", p.GraphWattsPerKmYellowMaxThreshold);
    //Preferences.Get("GraphWattsPerKmRedMaxThreshold", p.GraphWattsPerKmRedMaxThreshold);

  }
}