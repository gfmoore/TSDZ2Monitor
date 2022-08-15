namespace TSDZ2Monitor.ViewModels;

public partial class Display1ViewModel : ObservableObject
{
  public int assistLevels;
  public Display1ViewModel()
  {
    assistLevels = int.Parse( Preferences.Get("AssistLevelsNumberOfAssistLe", "9"));

  }

  //[ObservableProperty]
  //private string assistLevel;

  //[RelayCommand]
  //public void AssistDown()
  //{
  //  if (int.Parse(AssistLevel) > 0) AssistLevel = (int.Parse(AssistLevel) - 1).ToString();
  //}

  //[RelayCommand]
  //public void AssistUp()
  //{
  //  if (int.Parse(AssistLevel) < assistLevels ) AssistLevel = (int.Parse(AssistLevel) + 1).ToString();
  //}

  [RelayCommand]
  public void DoIt()
  {
    //Debug.WriteLine("heyupski");

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