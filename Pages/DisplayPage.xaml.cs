namespace TSDZ2Monitor.Pages;

public partial class DisplayPage : ContentPage
{
	public DisplayPage()
	{
		InitializeComponent();
    this.BindingContext = AppShell.Current.BindingContext;
  }
}