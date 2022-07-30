namespace TSDZ2Monitor.Pages.Parameters;

public partial class BatteryPage : ContentPage
{
	public BatteryPage()
	{
		InitializeComponent();

		//get defaults stored in preferences
		MaxCurrent.Text = Preferences.Get("BatteryMaxCurrent", "11");
		LowCutOff.Text = Preferences.Get("BatteryLowCutOff", "39");
		Resistance.Text = Preferences.Get("BatteryResistance", "200");	
		VoltageEstimate.Text = Preferences.Get("BatteryVoltageEstimate", "0");	
		ResistanceEstimate.Text = Preferences.Get("BatteryResistanceEstimate", "0");
		PowerLossEstimate.Text = Preferences.Get("PowerLossEstimate", "0");

	}
}