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
}
