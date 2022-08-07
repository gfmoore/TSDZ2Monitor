namespace TSDZ2Monitor.Pages.Parameters.AssistLevels;

public partial class AssistLevelCadencePage : ContentPage
{
  public bool checkValues = false;
  public AssistLevelCadencePage()
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
    AssistLevelCadence1.Text = Preferences.Get("AssistLevelCadence1", "0");
    for (int i = 2; i < 10; i++)
    {
      if (i <= numberLevels)
      {
        if (i == 2)
        {
          AssistLevelCadenceLabel2.IsVisible = true;
          AssistLevelCadenceBorder2.IsVisible = true;
          AssistLevelCadence2.IsVisible = true;
          AssistLevelCadence2.Text = Preferences.Get("AssistLevelCadence2", "0");
        }
        if (i == 3)
        {
          AssistLevelCadenceLabel3.IsVisible = true;
          AssistLevelCadenceBorder3.IsVisible = true;
          AssistLevelCadence3.IsVisible = true;
          AssistLevelCadence3.Text = Preferences.Get("AssistLevelCadence3", "0");
        }
        if (i == 4)
        {
          AssistLevelCadenceLabel4.IsVisible = true;
          AssistLevelCadenceBorder4.IsVisible = true;
          AssistLevelCadence4.IsVisible = true;
          AssistLevelCadence4.Text = Preferences.Get("AssistLevelCadence4", "0");
        }
        if (i == 5)
        {
          AssistLevelCadenceLabel5.IsVisible = true;
          AssistLevelCadenceBorder5.IsVisible = true;
          AssistLevelCadence5.IsVisible = true;
          AssistLevelCadence5.Text = Preferences.Get("AssistLevelCadence5", "0");
        }
        if (i == 6)
        {
          AssistLevelCadenceLabel6.IsVisible = true;
          AssistLevelCadenceBorder6.IsVisible = true;
          AssistLevelCadence6.IsVisible = true;
          AssistLevelCadence6.Text = Preferences.Get("AssistLevelCadence6", "0");
        }
        if (i == 7)
        {
          AssistLevelCadenceLabel7.IsVisible = true;
          AssistLevelCadenceBorder7.IsVisible = true;
          AssistLevelCadence7.IsVisible = true;
          AssistLevelCadence7.Text = Preferences.Get("AssistLevelCadence7", "0");
        }
        if (i == 8)
        {
          AssistLevelCadenceLabel8.IsVisible = true;
          AssistLevelCadenceBorder8.IsVisible = true;
          AssistLevelCadence8.IsVisible = true;
          AssistLevelCadence8.Text = Preferences.Get("AssistLevelCadence8", "0");
        }
        if (i == 9)
        {
          AssistLevelCadenceLabel9.IsVisible = true;
          AssistLevelCadenceBorder9.IsVisible = true;
          AssistLevelCadence9.IsVisible = true;
          AssistLevelCadence9.Text = Preferences.Get("AssistLevelCadence9", "0");
        }

      }
      else
      {
        if (i == 2)
        {
          AssistLevelCadenceLabel2.IsVisible = false;
          AssistLevelCadenceBorder2.IsVisible = false;
          AssistLevelCadence2.IsVisible = false;
        }
        if (i == 3)
        {
          AssistLevelCadenceLabel3.IsVisible = false;
          AssistLevelCadenceBorder3.IsVisible = false;
          AssistLevelCadence3.IsVisible = false;
        }
        if (i == 4)
        {
          AssistLevelCadenceLabel4.IsVisible = false;
          AssistLevelCadenceBorder4.IsVisible = false;
          AssistLevelCadence4.IsVisible = false;
        }
        if (i == 5)
        {
          AssistLevelCadenceLabel5.IsVisible = false;
          AssistLevelCadenceBorder5.IsVisible = false;
          AssistLevelCadence5.IsVisible = false;
        }
        if (i == 6)
        {
          AssistLevelCadenceLabel6.IsVisible = false;
          AssistLevelCadenceBorder6.IsVisible = false;
          AssistLevelCadence6.IsVisible = false;
        }
        if (i == 7)
        {
          AssistLevelCadenceLabel7.IsVisible = false;
          AssistLevelCadenceBorder7.IsVisible = false;
          AssistLevelCadence7.IsVisible = false;
        }
        if (i == 8)
        {
          AssistLevelCadenceLabel8.IsVisible = false;
          AssistLevelCadenceBorder8.IsVisible = false;
          AssistLevelCadence8.IsVisible = false;
        }
        if (i == 9)
        {
          AssistLevelCadenceLabel9.IsVisible = false;
          AssistLevelCadenceBorder9.IsVisible = false;
          AssistLevelCadence9.IsVisible = false;
        }

      }

    }

    checkValues = true;
  }


  //-------Assist Level Cadence 1------------------------------------------------
  private void AssistLevelCadence1_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence1.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence1.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence1.TextColor != Colors.Red && int.Parse(AssistLevelCadence1.Text) > 254)
    {
      AssistLevelCadence1.TextColor = Colors.Red;
    }

    if (AssistLevelCadence1.TextColor != Colors.Red && AssistLevelCadence1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence1", AssistLevelCadence1.Text);
    }
  }

  private void AssistLevelCadence1_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence1.TextColor != Colors.Red && AssistLevelCadence1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence1", AssistLevelCadence1.Text);
    }

    //dismiss keyboard
    AssistLevelCadence1.IsEnabled = false;
    AssistLevelCadence1.IsEnabled = true;
  }


  //-------Assist Level Cadence 2------------------------------------------------
  private void AssistLevelCadence2_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence2.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence2.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence2.TextColor != Colors.Red && int.Parse(AssistLevelCadence2.Text) > 254)
    {
      AssistLevelCadence2.TextColor = Colors.Red;
    }

    if (AssistLevelCadence2.TextColor != Colors.Red && AssistLevelCadence2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence2", AssistLevelCadence2.Text);
    }
  }

  private void AssistLevelCadence2_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence2.TextColor != Colors.Red && AssistLevelCadence2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence2", AssistLevelCadence2.Text);
    }

    //dismiss keyboard
    AssistLevelCadence2.IsEnabled = false;
    AssistLevelCadence2.IsEnabled = true;
  }



  //-------Assist Level Cadence 3------------------------------------------------
  private void AssistLevelCadence3_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence3.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence3.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence3.TextColor != Colors.Red && int.Parse(AssistLevelCadence3.Text) > 254)
    {
      AssistLevelCadence3.TextColor = Colors.Red;
    }

    if (AssistLevelCadence3.TextColor != Colors.Red && AssistLevelCadence3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence3", AssistLevelCadence3.Text);
    }
  }

  private void AssistLevelCadence3_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence3.TextColor != Colors.Red && AssistLevelCadence3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence3", AssistLevelCadence3.Text);
    }

    //dismiss keyboard
    AssistLevelCadence3.IsEnabled = false;
    AssistLevelCadence3.IsEnabled = true;
  }


  //-------Assist Level Cadence 4------------------------------------------------
  private void AssistLevelCadence4_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence4.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence4.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence4.TextColor != Colors.Red && int.Parse(AssistLevelCadence4.Text) > 254)
    {
      AssistLevelCadence4.TextColor = Colors.Red;
    }

    if (AssistLevelCadence4.TextColor != Colors.Red && AssistLevelCadence4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence4", AssistLevelCadence4.Text);
    }
  }

  private void AssistLevelCadence4_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence4.TextColor != Colors.Red && AssistLevelCadence4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence4", AssistLevelCadence4.Text);
    }

    //dismiss keyboard
    AssistLevelCadence4.IsEnabled = false;
    AssistLevelCadence4.IsEnabled = true;
  }



  //-------Assist Level Cadence 5------------------------------------------------
  private void AssistLevelCadence5_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence5.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence5.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence5.TextColor != Colors.Red && int.Parse(AssistLevelCadence5.Text) > 254)
    {
      AssistLevelCadence5.TextColor = Colors.Red;
    }

    if (AssistLevelCadence5.TextColor != Colors.Red && AssistLevelCadence5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence5", AssistLevelCadence5.Text);
    }
  }

  private void AssistLevelCadence5_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence5.TextColor != Colors.Red && AssistLevelCadence5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence5", AssistLevelCadence5.Text);
    }

    //dismiss keyboard
    AssistLevelCadence5.IsEnabled = false;
    AssistLevelCadence5.IsEnabled = true;
  }



  //-------Assist Level Cadence 6------------------------------------------------
  private void AssistLevelCadence6_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence6.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence6.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence6.TextColor != Colors.Red && int.Parse(AssistLevelCadence6.Text) > 254)
    {
      AssistLevelCadence6.TextColor = Colors.Red;
    }

    if (AssistLevelCadence6.TextColor != Colors.Red && AssistLevelCadence6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence6", AssistLevelCadence6.Text);
    }
  }

  private void AssistLevelCadence6_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence6.TextColor != Colors.Red && AssistLevelCadence6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence6", AssistLevelCadence6.Text);
    }

    //dismiss keyboard
    AssistLevelCadence6.IsEnabled = false;
    AssistLevelCadence6.IsEnabled = true;
  }



  //-------Assist Level Cadence 7------------------------------------------------
  private void AssistLevelCadence7_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence7.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence7.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence7.TextColor != Colors.Red && int.Parse(AssistLevelCadence7.Text) > 254)
    {
      AssistLevelCadence7.TextColor = Colors.Red;
    }

    if (AssistLevelCadence7.TextColor != Colors.Red && AssistLevelCadence7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence7", AssistLevelCadence7.Text);
    }
  }

  private void AssistLevelCadence7_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence7.TextColor != Colors.Red && AssistLevelCadence7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence7", AssistLevelCadence7.Text);
    }

    //dismiss keyboard
    AssistLevelCadence7.IsEnabled = false;
    AssistLevelCadence7.IsEnabled = true;
  }


  //-------Assist Level Cadence 8------------------------------------------------
  private void AssistLevelCadence8_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence8.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence8.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence8.TextColor != Colors.Red && int.Parse(AssistLevelCadence8.Text) > 254)
    {
      AssistLevelCadence8.TextColor = Colors.Red;
    }

    if (AssistLevelCadence8.TextColor != Colors.Red && AssistLevelCadence8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence8", AssistLevelCadence8.Text);
    }
  }

  private void AssistLevelCadence8_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence8.TextColor != Colors.Red && AssistLevelCadence8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence8", AssistLevelCadence8.Text);
    }

    //dismiss keyboard
    AssistLevelCadence8.IsEnabled = false;
    AssistLevelCadence8.IsEnabled = true;
  }



  //-------Assist Level Cadence 9------------------------------------------------
  private void AssistLevelCadence9_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelCadence9.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelCadence9.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelCadence9.TextColor != Colors.Red && int.Parse(AssistLevelCadence9.Text) > 254)
    {
      AssistLevelCadence9.TextColor = Colors.Red;
    }

    if (AssistLevelCadence9.TextColor != Colors.Red && AssistLevelCadence9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence9", AssistLevelCadence9.Text);
    }
  }

  private void AssistLevelCadence9_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelCadence9.TextColor != Colors.Red && AssistLevelCadence9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelCadence9", AssistLevelCadence9.Text);
    }

    //dismiss keyboard
    AssistLevelCadence9.IsEnabled = false;
    AssistLevelCadence9.IsEnabled = true;
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