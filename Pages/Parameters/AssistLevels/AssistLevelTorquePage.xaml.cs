namespace TSDZ2Monitor.Pages.Parameters.AssistLevels;

public partial class AssistLevelTorquePage : ContentPage
{
  public bool checkValues = false;
  public AssistLevelTorquePage()
  {
    InitializeComponent();
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    Setup();
  }

  public void Setup()
  {
    checkValues = false;

    int numberLevels = int.Parse(Preferences.Get("AssistLevelsNumberOfAssistLevels", "9"));

    //display however many levels need to be displayed, Level 1 always displayed
    AssistLevelTorque1.Text = Preferences.Get("AssistLevelTorque1", "0");
    for (int i = 2; i < 10; i++)
    {
      if (i <= numberLevels)
      {
        if (i == 2)
        {
          AssistLevelTorqueLabel2.IsVisible = true;
          AssistLevelTorqueBorder2.IsVisible = true;
          AssistLevelTorque2.IsVisible = true;
          AssistLevelTorque2.Text = Preferences.Get("AssistLevelTorque2", "0");
        }
        if (i == 3)
        {
          AssistLevelTorqueLabel3.IsVisible = true;
          AssistLevelTorqueBorder3.IsVisible = true;
          AssistLevelTorque3.IsVisible = true;
          AssistLevelTorque3.Text = Preferences.Get("AssistLevelTorque3", "0");
        }
        if (i == 4)
        {
          AssistLevelTorqueLabel4.IsVisible = true;
          AssistLevelTorqueBorder4.IsVisible = true;
          AssistLevelTorque4.IsVisible = true;
          AssistLevelTorque4.Text = Preferences.Get("AssistLevelTorque4", "0");
        }
        if (i == 5)
        {
          AssistLevelTorqueLabel5.IsVisible = true;
          AssistLevelTorqueBorder5.IsVisible = true;
          AssistLevelTorque5.IsVisible = true;
          AssistLevelTorque5.Text = Preferences.Get("AssistLevelTorque5", "0");
        }
        if (i == 6)
        {
          AssistLevelTorqueLabel6.IsVisible = true;
          AssistLevelTorqueBorder6.IsVisible = true;
          AssistLevelTorque6.IsVisible = true;
          AssistLevelTorque6.Text = Preferences.Get("AssistLevelTorque6", "0");
        }
        if (i == 7)
        {
          AssistLevelTorqueLabel7.IsVisible = true;
          AssistLevelTorqueBorder7.IsVisible = true;
          AssistLevelTorque7.IsVisible = true;
          AssistLevelTorque7.Text = Preferences.Get("AssistLevelTorque7", "0");
        }
        if (i == 8)
        {
          AssistLevelTorqueLabel8.IsVisible = true;
          AssistLevelTorqueBorder8.IsVisible = true;
          AssistLevelTorque8.IsVisible = true;
          AssistLevelTorque8.Text = Preferences.Get("AssistLevelTorque8", "0");
        }
        if (i == 9)
        {
          AssistLevelTorqueLabel9.IsVisible = true;
          AssistLevelTorqueBorder9.IsVisible = true;
          AssistLevelTorque9.IsVisible = true;
          AssistLevelTorque9.Text = Preferences.Get("AssistLevelTorque9", "0");
        }

      }
      else
      {
        if (i == 2)
        {
          AssistLevelTorqueLabel2.IsVisible = false;
          AssistLevelTorqueBorder2.IsVisible = false;
          AssistLevelTorque2.IsVisible = false;
        }
        if (i == 3)
        {
          AssistLevelTorqueLabel3.IsVisible = false;
          AssistLevelTorqueBorder3.IsVisible = false;
          AssistLevelTorque3.IsVisible = false;
        }
        if (i == 4)
        {
          AssistLevelTorqueLabel4.IsVisible = false;
          AssistLevelTorqueBorder4.IsVisible = false;
          AssistLevelTorque4.IsVisible = false;
        }
        if (i == 5)
        {
          AssistLevelTorqueLabel5.IsVisible = false;
          AssistLevelTorqueBorder5.IsVisible = false;
          AssistLevelTorque5.IsVisible = false;
        }
        if (i == 6)
        {
          AssistLevelTorqueLabel6.IsVisible = false;
          AssistLevelTorqueBorder6.IsVisible = false;
          AssistLevelTorque6.IsVisible = false;
        }
        if (i == 7)
        {
          AssistLevelTorqueLabel7.IsVisible = false;
          AssistLevelTorqueBorder7.IsVisible = false;
          AssistLevelTorque7.IsVisible = false;
        }
        if (i == 8)
        {
          AssistLevelTorqueLabel8.IsVisible = false;
          AssistLevelTorqueBorder8.IsVisible = false;
          AssistLevelTorque8.IsVisible = false;
        }
        if (i == 9)
        {
          AssistLevelTorqueLabel9.IsVisible = false;
          AssistLevelTorqueBorder9.IsVisible = false;
          AssistLevelTorque9.IsVisible = false;
        }

      }

    }

    checkValues = true;
  }


  //-------Assist Level Torque 1------------------------------------------------
  private void AssistLevelTorque1_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque1.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque1.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque1.TextColor != Colors.Red && int.Parse(AssistLevelTorque1.Text) > 254)
    {
      AssistLevelTorque1.TextColor = Colors.Red;
    }

    if (AssistLevelTorque1.TextColor != Colors.Red && AssistLevelTorque1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque1", AssistLevelTorque1.Text);
    }
  }

  private void AssistLevelTorque1_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque1.TextColor != Colors.Red && AssistLevelTorque1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque1", AssistLevelTorque1.Text);
    }

    //dismiss keyboard
    AssistLevelTorque1.IsEnabled = false;
    AssistLevelTorque1.IsEnabled = true;
  }


  //-------Assist Level Torque 2------------------------------------------------
  private void AssistLevelTorque2_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque2.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque2.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque2.TextColor != Colors.Red && int.Parse(AssistLevelTorque2.Text) > 254)
    {
      AssistLevelTorque2.TextColor = Colors.Red;
    }

    if (AssistLevelTorque2.TextColor != Colors.Red && AssistLevelTorque2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque2", AssistLevelTorque2.Text);
    }
  }

  private void AssistLevelTorque2_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque2.TextColor != Colors.Red && AssistLevelTorque2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque2", AssistLevelTorque2.Text);
    }

    //dismiss keyboard
    AssistLevelTorque2.IsEnabled = false;
    AssistLevelTorque2.IsEnabled = true;
  }



  //-------Assist Level Torque 3------------------------------------------------
  private void AssistLevelTorque3_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque3.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque3.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque3.TextColor != Colors.Red && int.Parse(AssistLevelTorque3.Text) > 254)
    {
      AssistLevelTorque3.TextColor = Colors.Red;
    }

    if (AssistLevelTorque3.TextColor != Colors.Red && AssistLevelTorque3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque3", AssistLevelTorque3.Text);
    }
  }

  private void AssistLevelTorque3_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque3.TextColor != Colors.Red && AssistLevelTorque3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque3", AssistLevelTorque3.Text);
    }

    //dismiss keyboard
    AssistLevelTorque3.IsEnabled = false;
    AssistLevelTorque3.IsEnabled = true;
  }


  //-------Assist Level Torque 4------------------------------------------------
  private void AssistLevelTorque4_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque4.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque4.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque4.TextColor != Colors.Red && int.Parse(AssistLevelTorque4.Text) > 254)
    {
      AssistLevelTorque4.TextColor = Colors.Red;
    }

    if (AssistLevelTorque4.TextColor != Colors.Red && AssistLevelTorque4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque4", AssistLevelTorque4.Text);
    }
  }

  private void AssistLevelTorque4_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque4.TextColor != Colors.Red && AssistLevelTorque4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque4", AssistLevelTorque4.Text);
    }

    //dismiss keyboard
    AssistLevelTorque4.IsEnabled = false;
    AssistLevelTorque4.IsEnabled = true;
  }



  //-------Assist Level Torque 5------------------------------------------------
  private void AssistLevelTorque5_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque5.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque5.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque5.TextColor != Colors.Red && int.Parse(AssistLevelTorque5.Text) > 254)
    {
      AssistLevelTorque5.TextColor = Colors.Red;
    }

    if (AssistLevelTorque5.TextColor != Colors.Red && AssistLevelTorque5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque5", AssistLevelTorque5.Text);
    }
  }

  private void AssistLevelTorque5_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque5.TextColor != Colors.Red && AssistLevelTorque5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque5", AssistLevelTorque5.Text);
    }

    //dismiss keyboard
    AssistLevelTorque5.IsEnabled = false;
    AssistLevelTorque5.IsEnabled = true;
  }



  //-------Assist Level Torque 6------------------------------------------------
  private void AssistLevelTorque6_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque6.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque6.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque6.TextColor != Colors.Red && int.Parse(AssistLevelTorque6.Text) > 254)
    {
      AssistLevelTorque6.TextColor = Colors.Red;
    }

    if (AssistLevelTorque6.TextColor != Colors.Red && AssistLevelTorque6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque6", AssistLevelTorque6.Text);
    }
  }

  private void AssistLevelTorque6_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque6.TextColor != Colors.Red && AssistLevelTorque6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque6", AssistLevelTorque6.Text);
    }

    //dismiss keyboard
    AssistLevelTorque6.IsEnabled = false;
    AssistLevelTorque6.IsEnabled = true;
  }



  //-------Assist Level Torque 7------------------------------------------------
  private void AssistLevelTorque7_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque7.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque7.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque7.TextColor != Colors.Red && int.Parse(AssistLevelTorque7.Text) > 254)
    {
      AssistLevelTorque7.TextColor = Colors.Red;
    }

    if (AssistLevelTorque7.TextColor != Colors.Red && AssistLevelTorque7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque7", AssistLevelTorque7.Text);
    }
  }

  private void AssistLevelTorque7_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque7.TextColor != Colors.Red && AssistLevelTorque7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque7", AssistLevelTorque7.Text);
    }

    //dismiss keyboard
    AssistLevelTorque7.IsEnabled = false;
    AssistLevelTorque7.IsEnabled = true;
  }


  //-------Assist Level Torque 8------------------------------------------------
  private void AssistLevelTorque8_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque8.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque8.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque8.TextColor != Colors.Red && int.Parse(AssistLevelTorque8.Text) > 254)
    {
      AssistLevelTorque8.TextColor = Colors.Red;
    }

    if (AssistLevelTorque8.TextColor != Colors.Red && AssistLevelTorque8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque8", AssistLevelTorque8.Text);
    }
  }

  private void AssistLevelTorque8_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque8.TextColor != Colors.Red && AssistLevelTorque8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque8", AssistLevelTorque8.Text);
    }

    //dismiss keyboard
    AssistLevelTorque8.IsEnabled = false;
    AssistLevelTorque8.IsEnabled = true;
  }



  //-------Assist Level Torque 9------------------------------------------------
  private void AssistLevelTorque9_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelTorque9.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelTorque9.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelTorque9.TextColor != Colors.Red && int.Parse(AssistLevelTorque9.Text) > 254)
    {
      AssistLevelTorque9.TextColor = Colors.Red;
    }

    if (AssistLevelTorque9.TextColor != Colors.Red && AssistLevelTorque9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque9", AssistLevelTorque9.Text);
    }
  }

  private void AssistLevelTorque9_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelTorque9.TextColor != Colors.Red && AssistLevelTorque9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelTorque9", AssistLevelTorque9.Text);
    }

    //dismiss keyboard
    AssistLevelTorque9.IsEnabled = false;
    AssistLevelTorque9.IsEnabled = true;
  }




  //----------helpers--------------------------------------------------
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