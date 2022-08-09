namespace TSDZ2Monitor.ViewModels;

public partial class Display3PageViewModel : ObservableObject
{
  public Display3PageViewModel()
  {
 
  }


  [RelayCommand]
  public async void PrevPage()
  {
    await Shell.Current.GoToAsync("..");
  }

  [RelayCommand]
  public async void NextPage()
  {
    //navigate to next page
    var navigationParameter = new Dictionary<string, object>
    {
        { "TestData", "Test Data" }
    };
    await Shell.Current.GoToAsync(nameof(Display4Page), true, navigationParameter);
  }
}