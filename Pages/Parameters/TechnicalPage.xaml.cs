namespace TSDZ2Monitor.Pages.Parameters;

public partial class TechnicalPage : ContentPage
{
	public TechnicalPage()
	{
		InitializeComponent();
		//TODO Need to mkae sure gets updated when values change
    TechnicalADCBatteryCurrent.Text = Preferences.Get("TechnicalADCBatteryCurrent", "-");
    TechnicalADCThrottleSensor.Text = Preferences.Get("TechnicalADCThrottleSensor", "-");
    TechnicalThrottleSensor.Text = Preferences.Get("TechnicalADCBatteryCurrent", "-");
    TechnicalADCTorqueSensor.Text = Preferences.Get("TechnicalADCTorqueSensor", "-");
    TechnicalADCTorqueDelta.Text = Preferences.Get("TechnicalADCTorqueDelta", "-");
    TechnicalADCTorqueBoost.Text = Preferences.Get("TechnicalADCTorqueBoost", "-");
    TechnicalADCTorqueStepCalc.Text = Preferences.Get("TechnicalADCTorqueStepCalc", "-");
    TechnicalPedalCadence.Text = Preferences.Get("TechnicalPedalCadence", "-");
    TechnicalPWMDutyCycle.Text = Preferences.Get("TechnicalPWMDutyCycle", "-");
    TechnicalMotorSpeed.Text = Preferences.Get("TechnicalADCBatteryCurrent", "-");
    TechnicalMotorFOC.Text = Preferences.Get("TechnicalADCBatteryCurrent", "-");
    TechnicalHallSensors.Text = Preferences.Get("TechnicalADCBatteryCurrent", "-");

  }

  //-------Technical ADC Battery Current------------------------------------------------
  private async void OnTechnicalADCBatteryCurrentLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "How much current is being drawn from the battery?", "OK");
  }


  //-------Technical ADC Throttle Sensor------------------------------------------------
  private async void OnTechnicalADCThrottleSensorLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The current value of the input signal from the throttle, from 0 to 255.", "OK");
  }


  //-------Technical Throttle Sensor------------------------------------------------
  private async void OnTechnicalThrottleSensorLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The current value of the input signal from the throttle,\r\nwithout offset, from 0 to 255.\r\n", "OK");
  }


  //-------Technical ADC Torque Sensor------------------------------------------------
  private async void OnTechnicalADCTorqueSensorLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The current value of the input signal from the torque sensor, from 0 to 1023.", "OK");
  }


  //-------Technical ADC Torque Delta------------------------------------------------
  private async void OnTechnicalADCTorqueDeltaLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "", "OK");
  }


  //-------Technical ADC Torque Boost------------------------------------------------
  private async void OnTechnicalADCTorqueBoostLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "ADC value of the torque sensor without offset.", "OK");
  }


  //-------Technical ADC Torque Step Calc------------------------------------------------
  private async void OnTechnicalADCTorqueStepCalcLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The conversion factor of the torque applied to the pedal\r\nobtained from the weight calibration.\r\n\r\nUsed for the calculation of the human power shown on the display.\r\n\r\nThis value can be entered in the \"ADC torque step\" parameter for a correct ratio in the assistance calculation (only in \"Power assist\").\r\n", "OK");
  }


  //-------Technical Pedal Cadence------------------------------------------------
  private async void OnTechnicalPedalCadenceLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The instantaneous value of the pedal cadence", "OK");
  }


  //-------Technical PWM Duty Cycle------------------------------------------------
  private async void OnTechnicalPWMDutyCycleLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "These values can fluctuate between 0 and 100 max.\r\n\r\nWhere 0 means 0 battery voltage applied to motor coils while 100 means max battery voltage applied. \r\n\r\nWhen this value hits the max of 100, means that the max motor power possible is being applied.\r\n", "OK");
  }


  //-------Technical Motor Speed------------------------------------------------
  private async void OnTechnicalMotorSpeedLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "In ERPS (electrical rotations per second) units. \r\n\r\nThe motor has 8 pairs of magnets inside, meaning each 1 ERPs equal to one 8 RPS (rotation per second).\r\n\r\nNo 1 ERPS = 8xRPS \r\n", "OK");
  }


  //-------Technical Motor FOC------------------------------------------------
  private async void OnTechnicalMotorFOCLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Angle calculated by FOC algorithm, between 0 and 30.\r\n\r\nHigher motor phase current and/or higher motor speed makes this value increase.\r\n", "OK");
  }


  //-------Technical Hall Sensors------------------------------------------------
  private async void OnTechnicalHallSensorsLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The current value of the motor hall sensor. You can rotate very slowly the bicycle wheel back backward to see this value changing and it must always follow the next same sequence and values must be only the next ones: 4, 6, 2, 3, 1, 5.", "OK");
  }
}