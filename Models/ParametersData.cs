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

  public string VariousTemperatureUnits { get; set; }
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


  //Wheel
  public string WheelMaxSpeed { get; set; }
  public string WheelCircumference { get; set; }
  

  //Trip Memories
  public string TripMemoriesOdometer { get; set; }
  public string TripMemoriesTripA { get; set; }
  public string TripMemoriesTripB { get; set; }
  public string TripMemoriesTripAAutoReset { get; set; }
  public string TripMemoriesTripAAutoResetHours { get; set; }
  public string TripMemoriesTripBAutoReset { get; set; }
  public string TripMemoriesTripBAutoResetHours { get; set; }


  //Assist
  public string AssistLevelsNumberOfAssistLevels { get; set; }

  public string AssistLevelPower1 { get; set; }
  public string AssistLevelPower2 { get; set; }
  public string AssistLevelPower3 { get; set; }
  public string AssistLevelPower4 { get; set; }
  public string AssistLevelPower5 { get; set; }
  public string AssistLevelPower6 { get; set; }
  public string AssistLevelPower7 { get; set; }
  public string AssistLevelPower8 { get; set; }
  public string AssistLevelPower9 { get; set; }


  public string AssistLevelTorque1 { get; set; }
  public string AssistLevelTorque2 { get; set; }
  public string AssistLevelTorque3 { get; set; }
  public string AssistLevelTorque4 { get; set; }
  public string AssistLevelTorque5 { get; set; }
  public string AssistLevelTorque6 { get; set; }
  public string AssistLevelTorque7 { get; set; }
  public string AssistLevelTorque8 { get; set; }
  public string AssistLevelTorque9 { get; set; }


  public string AssistLevelCadence1 { get; set; }
  public string AssistLevelCadence2 { get; set; }
  public string AssistLevelCadence3 { get; set; }
  public string AssistLevelCadence4 { get; set; }
  public string AssistLevelCadence5 { get; set; }
  public string AssistLevelCadence6 { get; set; }
  public string AssistLevelCadence7 { get; set; }
  public string AssistLevelCadence8 { get; set; }
  public string AssistLevelCadence9 { get; set; }


  public string AssistLevelEMTB1 { get; set; }
  public string AssistLevelEMTB2 { get; set; }
  public string AssistLevelEMTB3 { get; set; }
  public string AssistLevelEMTB4 { get; set; }
  public string AssistLevelEMTB5 { get; set; }
  public string AssistLevelEMTB6 { get; set; }
  public string AssistLevelEMTB7 { get; set; }
  public string AssistLevelEMTB8 { get; set; }
  public string AssistLevelEMTB9 { get; set; }

  public string AssistLevelWalkFeature { get; set; }
  public string AssistLevelWalk1 { get; set; }
  public string AssistLevelWalk2 { get; set; }
  public string AssistLevelWalk3 { get; set; }
  public string AssistLevelWalk4 { get; set; }
  public string AssistLevelWalk5 { get; set; }
  public string AssistLevelWalk6 { get; set; }
  public string AssistLevelWalk7 { get; set; }
  public string AssistLevelWalk8 { get; set; }
  public string AssistLevelWalk9 { get; set; }
  public string AssistLevelWalkCruiseControl { get; set; }
}
