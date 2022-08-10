namespace TSDZ2Monitor.ViewModels;

public partial class Display1PageViewModel : ObservableObject
{
  public Display1PageViewModel()
  {

  }

  [RelayCommand]
  public void DoIt()
  {
    Debug.WriteLine("heyupski");

  }


  //[RelayCommand]
  //public async void PrevPage()
  //{
  //  //await Shell.Current.GoToAsync("..");
  //  //navigate to next page
  //  var navigationParameter = new Dictionary<string, object>
  //  {
  //      { "TestData", "Test Data" }
  //  };
  //  await Shell.Current.GoToAsync(nameof(Display6Page), true, navigationParameter);

  //}

  [RelayCommand]
  public async static void NextPage()  //not sure this is wise
  {
    //navigate to next page
    var navigationParameter = new Dictionary<string, object>
    {
        { "TestData", "Test Data" }
    };
    await Shell.Current.GoToAsync(nameof(Display2Page), true, navigationParameter);

  }
}