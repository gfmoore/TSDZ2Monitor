namespace TSDZ2Monitor.ViewModels;

public partial class Display5PageViewModel : ObservableObject
{
  public Display5PageViewModel()
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
    await Shell.Current.GoToAsync(nameof(Display6Page), true, navigationParameter);
  }
}