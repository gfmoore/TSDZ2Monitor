using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TSDZ2Monitor
{
  //public class ShowParametersViewModel : BindableObject
  public class ShowParametersViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    bool showParameters = true;
    public bool ShowParameters
    {
      get { return showParameters; }
      set
      {
        if (value == showParameters) return;
        showParameters = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowParameters"));
      }
    }

    public ICommand ShowParametersCommand => new Command(ChangeShowParameters);

    public void ChangeShowParameters()
    {
      Console.WriteLine($"Before {ShowParameters}");
      ShowParameters = !ShowParameters;
      Console.WriteLine($"After {ShowParameters}");
     }
  }
}
