namespace TSDZ2Monitor.Pages.Parameters;

public partial class StartupBoostPage : ContentPage
{
  public bool checkInput = false;

	public StartupBoostPage()
	{
		InitializeComponent();

    if (Preferences.Get("StartupBoostFeature", "true") == "true")
    {
      StartupBoostFeature.IsToggled = true;
      StartupBoostFeature.ThumbColor = Colors.Green;
    }
    else
    {
      StartupBoostFeature.IsToggled = false;
      StartupBoostFeature.ThumbColor = Colors.Red;
    }

    checkInput = false;
    StartupBoostTorqueFactor.Text = Preferences.Get("StartupBoostTorqueFactor", "250");
    StartupBoostCadenceStep.Text = Preferences.Get("StartupBoostCadenceStep", "25");
    checkInput = true;
  }

  //-------Startup Boost Feature------------------------------------------------
  private void StartupBoostFeature_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (StartupBoostFeature.IsToggled)
    {
      Preferences.Set("StartupBoostFeature", "true");
      StartupBoostFeature.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("StartupBoostFeature", "false");
      StartupBoostFeature.ThumbColor = Colors.Red;
    }
  }

  private async void OnStartupBoostFeaturelabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enable/disable “Startup boost”.\r\nThe feature only works in POWER mode. \r\nUses torque and cadence to give additional power at startup.\r\n", "OK");
  }


  //-------Startup Boost Torque Factor------------------------------------------------
  private void StartupBoostTorqueFactor_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    StartupBoostTorqueFactor.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) StartupBoostTorqueFactor.TextColor = Colors.LightGreen;

    //not > 500
    if (StartupBoostTorqueFactor.TextColor != Colors.Red && int.Parse(StartupBoostTorqueFactor.Text) > 500)
    {
      StartupBoostTorqueFactor.TextColor = Colors.Red;
    }

    if (StartupBoostTorqueFactor.TextColor != Colors.Red && StartupBoostTorqueFactor.Text.Length != 0)
    {
      Preferences.Set("StartupBoostTorqueFactor", StartupBoostTorqueFactor.Text);
    }
  }

  private void StartupBoostTorqueFactor_Completed(object sender, EventArgs e)
  {
    if (StartupBoostTorqueFactor.TextColor != Colors.Red && StartupBoostTorqueFactor.Text.Length != 0)
    {
      Preferences.Set("StartupBoostTorqueFactor", StartupBoostTorqueFactor.Text);
    }

    //dismiss keyboard
    StartupBoostTorqueFactor.IsEnabled = false;
    StartupBoostTorqueFactor.IsEnabled = true;
  }

  private async void OnStartupBoostTorqueFactorLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "It is used to increase the starting assistance and at a low cadence.", "OK");
  }


  //-------Startup Boost Cadence Step------------------------------------------------
  private void StartupBoostCadenceStep_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    StartupBoostCadenceStep.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) StartupBoostCadenceStep.TextColor = Colors.LightGreen;

    //not < 10
    if (StartupBoostTorqueFactor.TextColor != Colors.Red && int.Parse(StartupBoostTorqueFactor.Text) < 10)
    {
      StartupBoostTorqueFactor.TextColor = Colors.Red;
    }

    //not > 50
    if (StartupBoostTorqueFactor.TextColor != Colors.Red && int.Parse(StartupBoostTorqueFactor.Text) > 50)
    {
      StartupBoostTorqueFactor.TextColor = Colors.Red;
    }

    if (StartupBoostCadenceStep.TextColor != Colors.Red && StartupBoostCadenceStep.Text.Length != 0)
    {
      Preferences.Set("StartupBoostCadenceStep", StartupBoostCadenceStep.Text);
    }
  }

  private void StartupBoostCadenceStep_Completed(object sender, EventArgs e)
  {
    if (StartupBoostCadenceStep.TextColor != Colors.Red && StartupBoostCadenceStep.Text.Length != 0)
    {
      Preferences.Set("StartupBoostCadenceStep", StartupBoostCadenceStep.Text);
    }

    //dismiss keyboard
    StartupBoostCadenceStep.IsEnabled = false;
    StartupBoostCadenceStep.IsEnabled = true;
  }

  private async void OnStartupBoostCadenceStepLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Set the total capacity in watt-hours less 10% of what your battery has.", "OK");
  }


  //----------Helper functions--------------------------------------
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


}