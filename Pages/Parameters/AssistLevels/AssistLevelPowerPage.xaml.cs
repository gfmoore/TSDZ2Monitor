namespace TSDZ2Monitor.Pages.Parameters.AssistLevels;

public partial class AssistLevelPowerPage : ContentPage
{
  public bool checkValues = false;
  public AssistLevelPowerPage()
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
    AssistLevelPower1.Text = Preferences.Get("AssistLevelPower1", "0");
    for (int i=2; i<10; i++)
    {
      if (i <= numberLevels)
      {
        if (i == 2)
        {
          AssistLevelPowerLabel2.IsVisible = true;
          AssistLevelPowerBorder2.IsVisible = true;
          AssistLevelPower2.IsVisible = true;
          AssistLevelPower2.Text = Preferences.Get("AssistLevelPower2", "0");
        }
        if (i == 3)
        {
          AssistLevelPowerLabel3.IsVisible = true;
          AssistLevelPowerBorder3.IsVisible = true;
          AssistLevelPower3.IsVisible = true;
          AssistLevelPower3.Text = Preferences.Get("AssistLevelPower3", "0");
        }
        if (i == 4)
        {
          AssistLevelPowerLabel4.IsVisible = true;
          AssistLevelPowerBorder4.IsVisible = true;
          AssistLevelPower4.IsVisible = true;
          AssistLevelPower4.Text = Preferences.Get("AssistLevelPower4", "0");
        }
        if (i == 5)
        {
          AssistLevelPowerLabel5.IsVisible = true;
          AssistLevelPowerBorder5.IsVisible = true;
          AssistLevelPower5.IsVisible = true;
          AssistLevelPower5.Text = Preferences.Get("AssistLevelPower5", "0");
        }
        if (i == 6)
        {
          AssistLevelPowerLabel6.IsVisible = true;
          AssistLevelPowerBorder6.IsVisible = true;
          AssistLevelPower6.IsVisible = true;
          AssistLevelPower6.Text = Preferences.Get("AssistLevelPower6", "0");
        }
        if (i == 7)
        {
          AssistLevelPowerLabel7.IsVisible = true;
          AssistLevelPowerBorder7.IsVisible = true;
          AssistLevelPower7.IsVisible = true;
          AssistLevelPower7.Text = Preferences.Get("AssistLevelPower7", "0");
        }
        if (i == 8)
        {
          AssistLevelPowerLabel8.IsVisible = true;
          AssistLevelPowerBorder8.IsVisible = true;
          AssistLevelPower8.IsVisible = true;
          AssistLevelPower8.Text = Preferences.Get("AssistLevelPower8", "0");
        }
        if (i == 9)
        {
          AssistLevelPowerLabel9.IsVisible = true;
          AssistLevelPowerBorder9.IsVisible = true;
          AssistLevelPower9.IsVisible = true;
          AssistLevelPower9.Text = Preferences.Get("AssistLevelPower9", "0");
        }

      }
      else
      {
        if (i == 2)
        {
          AssistLevelPowerLabel2.IsVisible = false;
          AssistLevelPowerBorder2.IsVisible = false;
          AssistLevelPower2.IsVisible = false;
        }
        if (i == 3)
        {
          AssistLevelPowerLabel3.IsVisible = false;
          AssistLevelPowerBorder3.IsVisible = false;
          AssistLevelPower3.IsVisible = false;
        }
        if (i == 4)
        {
          AssistLevelPowerLabel4.IsVisible = false;
          AssistLevelPowerBorder4.IsVisible = false;
          AssistLevelPower4.IsVisible = false;
        }
        if (i == 5)
        {
          AssistLevelPowerLabel5.IsVisible = false;
          AssistLevelPowerBorder5.IsVisible = false;
          AssistLevelPower5.IsVisible = false;
        }
        if (i == 6)
        {
          AssistLevelPowerLabel6.IsVisible = false;
          AssistLevelPowerBorder6.IsVisible = false;
          AssistLevelPower6.IsVisible = false;
        }
        if (i == 7)
        {
          AssistLevelPowerLabel7.IsVisible = false;
          AssistLevelPowerBorder7.IsVisible = false;
          AssistLevelPower7.IsVisible = false;
        }
        if (i == 8)
        {
          AssistLevelPowerLabel8.IsVisible = false;
          AssistLevelPowerBorder8.IsVisible = false;
          AssistLevelPower8.IsVisible = false;
        }
        if (i == 9)
        {
          AssistLevelPowerLabel9.IsVisible = false;
          AssistLevelPowerBorder9.IsVisible = false;
          AssistLevelPower9.IsVisible = false;
        }

      }

    }

    checkValues = true;
  }


  //-------Assist Level Power 1------------------------------------------------
  private void AssistLevelPower1_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower1.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower1.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower1.TextColor != Colors.Red && int.Parse(AssistLevelPower1.Text) > 254)
    {
      AssistLevelPower1.TextColor = Colors.Red;
    }

    if (AssistLevelPower1.TextColor != Colors.Red && AssistLevelPower1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower1", AssistLevelPower1.Text);
    }
  }

  private void AssistLevelPower1_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower1.TextColor != Colors.Red && AssistLevelPower1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower1", AssistLevelPower1.Text);
    }

    //dismiss keyboard
    AssistLevelPower1.IsEnabled = false;
    AssistLevelPower1.IsEnabled = true;
  }


  //-------Assist Level Power 2------------------------------------------------
  private void AssistLevelPower2_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower2.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower2.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower2.TextColor != Colors.Red && int.Parse(AssistLevelPower2.Text) > 254)
    {
      AssistLevelPower2.TextColor = Colors.Red;
    }

    if (AssistLevelPower2.TextColor != Colors.Red && AssistLevelPower2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower2", AssistLevelPower2.Text);
    }
  }

  private void AssistLevelPower2_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower2.TextColor != Colors.Red && AssistLevelPower2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower2", AssistLevelPower2.Text);
    }

    //dismiss keyboard
    AssistLevelPower2.IsEnabled = false;
    AssistLevelPower2.IsEnabled = true;
  }



  //-------Assist Level Power 3------------------------------------------------
  private void AssistLevelPower3_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower3.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower3.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower3.TextColor != Colors.Red && int.Parse(AssistLevelPower3.Text) > 254)
    {
      AssistLevelPower3.TextColor = Colors.Red;
    }

    if (AssistLevelPower3.TextColor != Colors.Red && AssistLevelPower3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower3", AssistLevelPower3.Text);
    }
  }

  private void AssistLevelPower3_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower3.TextColor != Colors.Red && AssistLevelPower3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower3", AssistLevelPower3.Text);
    }

    //dismiss keyboard
    AssistLevelPower3.IsEnabled = false;
    AssistLevelPower3.IsEnabled = true;
  }


  //-------Assist Level Power 4------------------------------------------------
  private void AssistLevelPower4_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower4.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower4.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower4.TextColor != Colors.Red && int.Parse(AssistLevelPower4.Text) > 254)
    {
      AssistLevelPower4.TextColor = Colors.Red;
    }

    if (AssistLevelPower4.TextColor != Colors.Red && AssistLevelPower4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower4", AssistLevelPower4.Text);
    }
  }

  private void AssistLevelPower4_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower4.TextColor != Colors.Red && AssistLevelPower4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower4", AssistLevelPower4.Text);
    }

    //dismiss keyboard
    AssistLevelPower4.IsEnabled = false;
    AssistLevelPower4.IsEnabled = true;
  }



  //-------Assist Level Power 5------------------------------------------------
  private void AssistLevelPower5_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower5.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower5.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower5.TextColor != Colors.Red && int.Parse(AssistLevelPower5.Text) > 254)
    {
      AssistLevelPower5.TextColor = Colors.Red;
    }

    if (AssistLevelPower5.TextColor != Colors.Red && AssistLevelPower5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower5", AssistLevelPower5.Text);
    }
  }

  private void AssistLevelPower5_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower5.TextColor != Colors.Red && AssistLevelPower5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower5", AssistLevelPower5.Text);
    }

    //dismiss keyboard
    AssistLevelPower5.IsEnabled = false;
    AssistLevelPower5.IsEnabled = true;
  }



  //-------Assist Level Power 6------------------------------------------------
  private void AssistLevelPower6_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower6.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower6.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower6.TextColor != Colors.Red && int.Parse(AssistLevelPower6.Text) > 254)
    {
      AssistLevelPower6.TextColor = Colors.Red;
    }

    if (AssistLevelPower6.TextColor != Colors.Red && AssistLevelPower6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower6", AssistLevelPower6.Text);
    }
  }

  private void AssistLevelPower6_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower6.TextColor != Colors.Red && AssistLevelPower6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower6", AssistLevelPower6.Text);
    }

    //dismiss keyboard
    AssistLevelPower6.IsEnabled = false;
    AssistLevelPower6.IsEnabled = true;
  }



  //-------Assist Level Power 7------------------------------------------------
  private void AssistLevelPower7_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower7.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower7.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower7.TextColor != Colors.Red && int.Parse(AssistLevelPower7.Text) > 254)
    {
      AssistLevelPower7.TextColor = Colors.Red;
    }

    if (AssistLevelPower7.TextColor != Colors.Red && AssistLevelPower7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower7", AssistLevelPower7.Text);
    }
  }

  private void AssistLevelPower7_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower7.TextColor != Colors.Red && AssistLevelPower7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower7", AssistLevelPower7.Text);
    }

    //dismiss keyboard
    AssistLevelPower7.IsEnabled = false;
    AssistLevelPower7.IsEnabled = true;
  }


  //-------Assist Level Power 8------------------------------------------------
  private void AssistLevelPower8_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower8.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower8.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower8.TextColor != Colors.Red && int.Parse(AssistLevelPower8.Text) > 254)
    {
      AssistLevelPower8.TextColor = Colors.Red;
    }

    if (AssistLevelPower8.TextColor != Colors.Red && AssistLevelPower8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower8", AssistLevelPower8.Text);
    }
  }

  private void AssistLevelPower8_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower8.TextColor != Colors.Red && AssistLevelPower8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower8", AssistLevelPower8.Text);
    }

    //dismiss keyboard
    AssistLevelPower8.IsEnabled = false;
    AssistLevelPower8.IsEnabled = true;
  }



  //-------Assist Level Power 9------------------------------------------------
  private void AssistLevelPower9_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelPower9.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelPower9.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelPower9.TextColor != Colors.Red && int.Parse(AssistLevelPower9.Text) > 254)
    {
      AssistLevelPower9.TextColor = Colors.Red;
    }

    if (AssistLevelPower9.TextColor != Colors.Red && AssistLevelPower9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower9", AssistLevelPower9.Text);
    }
  }

  private void AssistLevelPower9_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelPower9.TextColor != Colors.Red && AssistLevelPower9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelPower9", AssistLevelPower9.Text);
    }

    //dismiss keyboard
    AssistLevelPower9.IsEnabled = false;
    AssistLevelPower9.IsEnabled = true;
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