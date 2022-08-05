namespace TSDZ2Monitor.Pages.Parameters;

public partial class VariousPage : ContentPage
{
  public bool switchEventDisable = true;  //need to stop IsToggled event when first loading preferences

  public VariousPage()
	{
		InitializeComponent();

    //display Metric(SI) or Imperial
    if (Preferences.Get("VariousUnits", "Metric") == "Metric")
    {
      VariousUnits.ThumbColor = Colors.Blue;
      VariousUnits.IsToggled = true;
    }
    else
    {
      VariousUnits.ThumbColor = Colors.Green;
      VariousUnits.IsToggled = false;
    }

    switchEventDisable = false;
  }



  //-------Various Units------------------------------------------------
  private void VariousUnits_Toggled(object sender, EventArgs e)
  {
    if (switchEventDisable) return; //on first set up of page

    if (VariousUnits.IsToggled)  //Metric
    {
      Preferences.Set("VariousUnits", "Metric");
      VariousUnits.ThumbColor = Colors.Blue;
    }
    else  //Imperial
    {
      Preferences.Set("VariousUnits", "Imperial");
      VariousUnits.ThumbColor = Colors.Green;
    }
  }

  private async void VariousUnitsLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The system units are stored internally as Metric (SI), but will be displayed in Imperial by fliiping the switch.", "OK");
  }

}