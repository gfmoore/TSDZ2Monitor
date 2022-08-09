namespace TSDZ2Monitor.ViewModels;

public partial class Display6PageViewModel : ObservableObject
{
  public Display6PageViewModel()
  {
 
  }

  [RelayCommand]
  public async void PrevPage()
  {
    await Shell.Current.GoToAsync("..");
  }

  //[RelayCommand]
  //public async void NextPage()
  //{
  //  //navigate to next page
  //  var navigationParameter = new Dictionary<string, object>
  //  {
  //      { "TestData", "Test Data" }
  //  };
  //  await Shell.Current.GoToAsync(nameof(Display1Page), true, navigationParameter);
  //}
}