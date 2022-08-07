namespace TSDZ2Monitor.Pages.Parameters.AssistLevels;

public partial class AssistLevelEMTBPage : ContentPage
{
  public bool checkValues = false;
  public AssistLevelEMTBPage()
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
    AssistLevelEMTB1.Text = Preferences.Get("AssistLevelEMTB1", "0");
    for (int i = 2; i < 10; i++)
    {
      if (i <= numberLevels)
      {
        if (i == 2)
        {
          AssistLevelEMTBLabel2.IsVisible = true;
          AssistLevelEMTBBorder2.IsVisible = true;
          AssistLevelEMTB2.IsVisible = true;
          AssistLevelEMTB2.Text = Preferences.Get("AssistLevelEMTB2", "0");
        }
        if (i == 3)
        {
          AssistLevelEMTBLabel3.IsVisible = true;
          AssistLevelEMTBBorder3.IsVisible = true;
          AssistLevelEMTB3.IsVisible = true;
          AssistLevelEMTB3.Text = Preferences.Get("AssistLevelEMTB3", "0");
        }
        if (i == 4)
        {
          AssistLevelEMTBLabel4.IsVisible = true;
          AssistLevelEMTBBorder4.IsVisible = true;
          AssistLevelEMTB4.IsVisible = true;
          AssistLevelEMTB4.Text = Preferences.Get("AssistLevelEMTB4", "0");
        }
        if (i == 5)
        {
          AssistLevelEMTBLabel5.IsVisible = true;
          AssistLevelEMTBBorder5.IsVisible = true;
          AssistLevelEMTB5.IsVisible = true;
          AssistLevelEMTB5.Text = Preferences.Get("AssistLevelEMTB5", "0");
        }
        if (i == 6)
        {
          AssistLevelEMTBLabel6.IsVisible = true;
          AssistLevelEMTBBorder6.IsVisible = true;
          AssistLevelEMTB6.IsVisible = true;
          AssistLevelEMTB6.Text = Preferences.Get("AssistLevelEMTB6", "0");
        }
        if (i == 7)
        {
          AssistLevelEMTBLabel7.IsVisible = true;
          AssistLevelEMTBBorder7.IsVisible = true;
          AssistLevelEMTB7.IsVisible = true;
          AssistLevelEMTB7.Text = Preferences.Get("AssistLevelEMTB7", "0");
        }
        if (i == 8)
        {
          AssistLevelEMTBLabel8.IsVisible = true;
          AssistLevelEMTBBorder8.IsVisible = true;
          AssistLevelEMTB8.IsVisible = true;
          AssistLevelEMTB8.Text = Preferences.Get("AssistLevelEMTB8", "0");
        }
        if (i == 9)
        {
          AssistLevelEMTBLabel9.IsVisible = true;
          AssistLevelEMTBBorder9.IsVisible = true;
          AssistLevelEMTB9.IsVisible = true;
          AssistLevelEMTB9.Text = Preferences.Get("AssistLevelEMTB9", "0");
        }

      }
      else
      {
        if (i == 2)
        {
          AssistLevelEMTBLabel2.IsVisible = false;
          AssistLevelEMTBBorder2.IsVisible = false;
          AssistLevelEMTB2.IsVisible = false;
        }
        if (i == 3)
        {
          AssistLevelEMTBLabel3.IsVisible = false;
          AssistLevelEMTBBorder3.IsVisible = false;
          AssistLevelEMTB3.IsVisible = false;
        }
        if (i == 4)
        {
          AssistLevelEMTBLabel4.IsVisible = false;
          AssistLevelEMTBBorder4.IsVisible = false;
          AssistLevelEMTB4.IsVisible = false;
        }
        if (i == 5)
        {
          AssistLevelEMTBLabel5.IsVisible = false;
          AssistLevelEMTBBorder5.IsVisible = false;
          AssistLevelEMTB5.IsVisible = false;
        }
        if (i == 6)
        {
          AssistLevelEMTBLabel6.IsVisible = false;
          AssistLevelEMTBBorder6.IsVisible = false;
          AssistLevelEMTB6.IsVisible = false;
        }
        if (i == 7)
        {
          AssistLevelEMTBLabel7.IsVisible = false;
          AssistLevelEMTBBorder7.IsVisible = false;
          AssistLevelEMTB7.IsVisible = false;
        }
        if (i == 8)
        {
          AssistLevelEMTBLabel8.IsVisible = false;
          AssistLevelEMTBBorder8.IsVisible = false;
          AssistLevelEMTB8.IsVisible = false;
        }
        if (i == 9)
        {
          AssistLevelEMTBLabel9.IsVisible = false;
          AssistLevelEMTBBorder9.IsVisible = false;
          AssistLevelEMTB9.IsVisible = false;
        }

      }

    }

    checkValues = true;
  }


  //-------Assist Level EMTB 1------------------------------------------------
  private void AssistLevelEMTB1_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB1.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB1.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB1.TextColor != Colors.Red && int.Parse(AssistLevelEMTB1.Text) > 20)
    {
      AssistLevelEMTB1.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB1.TextColor != Colors.Red && int.Parse(AssistLevelEMTB1.Text) == 0)
    {
      AssistLevelEMTB1.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB1.TextColor != Colors.Red && AssistLevelEMTB1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB1", AssistLevelEMTB1.Text);
    }
  }

  private void AssistLevelEMTB1_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB1.TextColor != Colors.Red && AssistLevelEMTB1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB1", AssistLevelEMTB1.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB1.IsEnabled = false;
    AssistLevelEMTB1.IsEnabled = true;
  }


  //-------Assist Level EMTB 2------------------------------------------------
  private void AssistLevelEMTB2_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB2.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB2.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB2.TextColor != Colors.Red && int.Parse(AssistLevelEMTB2.Text) > 20)
    {
      AssistLevelEMTB2.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB2.TextColor != Colors.Red && int.Parse(AssistLevelEMTB2.Text) == 0)
    {
      AssistLevelEMTB2.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB2.TextColor != Colors.Red && AssistLevelEMTB2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB2", AssistLevelEMTB2.Text);
    }
  }

  private void AssistLevelEMTB2_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB2.TextColor != Colors.Red && AssistLevelEMTB2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB2", AssistLevelEMTB2.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB2.IsEnabled = false;
    AssistLevelEMTB2.IsEnabled = true;
  }



  //-------Assist Level EMTB 3------------------------------------------------
  private void AssistLevelEMTB3_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB3.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB3.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB3.TextColor != Colors.Red && int.Parse(AssistLevelEMTB3.Text) > 20)
    {
      AssistLevelEMTB3.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB3.TextColor != Colors.Red && int.Parse(AssistLevelEMTB3.Text) == 0)
    {
      AssistLevelEMTB3.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB3.TextColor != Colors.Red && AssistLevelEMTB3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB3", AssistLevelEMTB3.Text);
    }
  }

  private void AssistLevelEMTB3_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB3.TextColor != Colors.Red && AssistLevelEMTB3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB3", AssistLevelEMTB3.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB3.IsEnabled = false;
    AssistLevelEMTB3.IsEnabled = true;
  }


  //-------Assist Level EMTB 4------------------------------------------------
  private void AssistLevelEMTB4_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB4.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB4.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB4.TextColor != Colors.Red && int.Parse(AssistLevelEMTB4.Text) > 20)
    {
      AssistLevelEMTB4.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB4.TextColor != Colors.Red && int.Parse(AssistLevelEMTB4.Text) == 0)
    {
      AssistLevelEMTB4.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB4.TextColor != Colors.Red && AssistLevelEMTB4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB4", AssistLevelEMTB4.Text);
    }
  }

  private void AssistLevelEMTB4_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB4.TextColor != Colors.Red && AssistLevelEMTB4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB4", AssistLevelEMTB4.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB4.IsEnabled = false;
    AssistLevelEMTB4.IsEnabled = true;
  }



  //-------Assist Level EMTB 5------------------------------------------------
  private void AssistLevelEMTB5_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB5.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB5.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB5.TextColor != Colors.Red && int.Parse(AssistLevelEMTB5.Text) > 20)
    {
      AssistLevelEMTB5.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB5.TextColor != Colors.Red && int.Parse(AssistLevelEMTB5.Text) == 0)
    {
      AssistLevelEMTB5.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB5.TextColor != Colors.Red && AssistLevelEMTB5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB5", AssistLevelEMTB5.Text);
    }
  }

  private void AssistLevelEMTB5_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB5.TextColor != Colors.Red && AssistLevelEMTB5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB5", AssistLevelEMTB5.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB5.IsEnabled = false;
    AssistLevelEMTB5.IsEnabled = true;
  }



  //-------Assist Level EMTB 6------------------------------------------------
  private void AssistLevelEMTB6_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB6.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB6.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB6.TextColor != Colors.Red && int.Parse(AssistLevelEMTB6.Text) > 20)
    {
      AssistLevelEMTB6.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB6.TextColor != Colors.Red && int.Parse(AssistLevelEMTB6.Text) == 0)
    {
      AssistLevelEMTB6.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB6.TextColor != Colors.Red && AssistLevelEMTB6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB6", AssistLevelEMTB6.Text);
    }
  }

  private void AssistLevelEMTB6_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB6.TextColor != Colors.Red && AssistLevelEMTB6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB6", AssistLevelEMTB6.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB6.IsEnabled = false;
    AssistLevelEMTB6.IsEnabled = true;
  }



  //-------Assist Level EMTB 7------------------------------------------------
  private void AssistLevelEMTB7_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB7.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB7.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB7.TextColor != Colors.Red && int.Parse(AssistLevelEMTB7.Text) > 20)
    {
      AssistLevelEMTB7.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB7.TextColor != Colors.Red && int.Parse(AssistLevelEMTB7.Text) == 0)
    {
      AssistLevelEMTB7.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB7.TextColor != Colors.Red && AssistLevelEMTB7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB7", AssistLevelEMTB7.Text);
    }
  }

  private void AssistLevelEMTB7_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB7.TextColor != Colors.Red && AssistLevelEMTB7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB7", AssistLevelEMTB7.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB7.IsEnabled = false;
    AssistLevelEMTB7.IsEnabled = true;
  }


  //-------Assist Level EMTB 8------------------------------------------------
  private void AssistLevelEMTB8_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB8.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB8.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB8.TextColor != Colors.Red && int.Parse(AssistLevelEMTB8.Text) > 20)
    {
      AssistLevelEMTB8.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB8.TextColor != Colors.Red && int.Parse(AssistLevelEMTB8.Text) == 0)
    {
      AssistLevelEMTB8.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB8.TextColor != Colors.Red && AssistLevelEMTB8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB8", AssistLevelEMTB8.Text);
    }
  }

  private void AssistLevelEMTB8_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB8.TextColor != Colors.Red && AssistLevelEMTB8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB8", AssistLevelEMTB8.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB8.IsEnabled = false;
    AssistLevelEMTB8.IsEnabled = true;
  }



  //-------Assist Level EMTB 9------------------------------------------------
  private void AssistLevelEMTB9_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelEMTB9.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelEMTB9.TextColor = Colors.LightGreen;

    //not > 20
    if (AssistLevelEMTB9.TextColor != Colors.Red && int.Parse(AssistLevelEMTB9.Text) > 20)
    {
      AssistLevelEMTB9.TextColor = Colors.Red;
    }

    //Not == 0
    if (AssistLevelEMTB9.TextColor != Colors.Red && int.Parse(AssistLevelEMTB9.Text) == 0)
    {
      AssistLevelEMTB9.TextColor = Colors.Red;
    }

    if (AssistLevelEMTB9.TextColor != Colors.Red && AssistLevelEMTB9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB9", AssistLevelEMTB9.Text);
    }
  }

  private void AssistLevelEMTB9_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelEMTB9.TextColor != Colors.Red && AssistLevelEMTB9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelEMTB9", AssistLevelEMTB9.Text);
    }

    //dismiss keyboard
    AssistLevelEMTB9.IsEnabled = false;
    AssistLevelEMTB9.IsEnabled = true;
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