namespace TSDZ2Monitor.ViewModels;

public partial class DisplayPageViewModel : ObservableObject
{
  public DisplayPageViewModel()
  {

  }

  [RelayCommand]
  public async static void NextPage()
  {
    Debug.WriteLine("Hello");

    //navigate to next page
    var navigationParameter = new Dictionary<string, object>
    {
        { "TestData", "Test Data" }
    };
    await Shell.Current.GoToAsync(nameof(Display2Page), true, navigationParameter);

  }
}