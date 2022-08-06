namespace TSDZ2Monitor.Models;

public class ParametersData
{
  //Battery
  public string BatteryMaxCurrent { get; set; }
  public string BatteryLowCutOff { get; set; }
  public string BatteryResistance { get; set; }
  public string BatteryVoltageEstimate { get; set; }
  public string BatteryResistanceEstimate { get; set; }
  public string BatteryPowerLossEstimate { get; set; }


  //Motor
  public string MotorVoltage { get; set; }
  public string MotorPowerMax { get; set; }
  public string MotorAcceleration { get; set; }
  public string MotorDeceleration { get; set; }
  public string MotorFastStop { get; set; }
  public string MotorFieldWeakening { get; set; }


  //Motor Temperature
  public string MotorTemperatureFeature { get; set; }
  public string MotorTemperatureMinLimit { get; set; }
  public string MotorTemperatureMaxLimit { get; set; }
  public string MotorTemperatureUnits { get; set; }


  //SoC
  public string SoCDisplayText { get; set; }
  public string SoCResetAtVoltage { get; set; }
  public string SoCBatteryTotalWH { get; set; }
  public string SoCUsedWH { get; set; }
  public string SoCManualReset { get; set; }


  //StartupBoost
  public string StartupBoostFeature { get; set; }
  public string StartupBoostTorqueFactor { get; set; }
  public string StartupBoostCadenceStep { get; set; }


  //Street Mode
  public string StreetModeEnableMode { get; set; }
  public string StreetModeEnableAtStartup { get; set; }
  public string StreetModeSpeedLimit { get; set; }
  public string StreetModeMotorPowerLimit { get; set; }
  public string StreetModeThrottleEnable { get; set; }
  public string StreetModeCruiseEnable { get; set; }
  public string StreetModeHotkeyEnable { get; set; }


  //Various
  public string VariousUnits { get; set; }
  public string VariousLightsConfiguration { get; set; }
  public string VariousAssistWithError { get; set; }
  public string VariousVirtualThrottleStep { get; set; }


  //Technical
  public string TechnicalADCBatteryCurrent { get; set; }
  public string TechnicalADCThrottleSensor { get; set; }
  public string TechnicalThrottleSensor { get; set; }
  public string TechnicalADCTorqueSensor { get; set; }
  public string TechnicalADCTorqueDelta { get; set; }
  public string TechnicalADCTorqueBoost { get; set; }
  public string TechnicalADCTorqueStepCalc { get; set; }
  public string TechnicalPedalCadence { get; set; }
  public string TechnicalPWMDutyCycle { get; set; }
  public string TechnicalMotorSpeed { get; set; }
  public string TechnicalMotorFOC { get; set; }
  public string TechnicalHallSensors { get; set; }


  //Torque Sensor
  public string TorqueSensorAssistWOPedal { get; set; }
  public string TorqueSensorADCThreshold { get; set; }
  public string TorqueSensorCoastBrake { get; set; }
  public string TorqueSensorCoastBrakeADC { get; set; }
  public string TorqueSensorCalibration { get; set; }
  public string TorqueSensorADCStep { get; set; }
  public string TorqueSensorADCOffset { get; set; }
  public string TorqueSensorADCMax { get; set; }
  public string TorqueSensorWeightOnPedal { get; set; }
  public string TorqueSensorADCOnWeight{ get; set; }
  public string TorqueSensorDefaultWeight { get; set; }

  public string WheelMaxSpeed { get; set; }
  public string WheelCircumference { get; set; }
  
  public string TripMemoriesOdometer { get; set; }
  public string TripMemoriesTripA { get; set; }
  public string TripMemoriesTripB { get; set; }
  public string TripMemoriesTripAAutoReset { get; set; }
  public string TripMemoriesTripAAutoResetHours { get; set; }
  public string TripMemoriesTripBAutoReset { get; set; }
  public string TripMemoriesTripBAutoResetHours { get; set; }


}
