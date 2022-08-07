namespace TSDZ2Monitor.Pages.Parameters.AssistLevels;

public partial class AssistLevelWalkPage : ContentPage
{
  public bool checkValues = false;
  public AssistLevelWalkPage()
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

    if (Preferences.Get("AssistLevelWalkFeature", "false") == "true")
    {
      AssistLevelWalkFeature.IsToggled = true;
      AssistLevelWalkFeature.ThumbColor = Colors.Green;
    }
    else
    {
      AssistLevelWalkFeature.IsToggled = false;
      AssistLevelWalkFeature.ThumbColor = Colors.Red;
    }

    if (Preferences.Get("AssistLevelWalkCruiseControl", "false") == "true")
    {
      AssistLevelWalkCruiseControl.IsToggled = true;
      AssistLevelWalkCruiseControl.ThumbColor = Colors.Green;
    }
    else
    {
      AssistLevelWalkCruiseControl.IsToggled = false;
      AssistLevelWalkCruiseControl.ThumbColor = Colors.Red;
    }


    //display however many levels need to be displayed, Level 1 always displayed
    AssistLevelWalk1.Text = Preferences.Get("AssistLevelWalk1", "0");
    for (int i=2; i<10; i++)
    {
      if (i <= numberLevels)
      {
        if (i == 2)
        {
          AssistLevelWalkLabel2.IsVisible = true;
          AssistLevelWalkBorder2.IsVisible = true;
          AssistLevelWalk2.IsVisible = true;
          AssistLevelWalk2.Text = Preferences.Get("AssistLevelWalk2", "0");
        }
        if (i == 3)
        {
          AssistLevelWalkLabel3.IsVisible = true;
          AssistLevelWalkBorder3.IsVisible = true;
          AssistLevelWalk3.IsVisible = true;
          AssistLevelWalk3.Text = Preferences.Get("AssistLevelWalk3", "0");
        }
        if (i == 4)
        {
          AssistLevelWalkLabel4.IsVisible = true;
          AssistLevelWalkBorder4.IsVisible = true;
          AssistLevelWalk4.IsVisible = true;
          AssistLevelWalk4.Text = Preferences.Get("AssistLevelWalk4", "0");
        }
        if (i == 5)
        {
          AssistLevelWalkLabel5.IsVisible = true;
          AssistLevelWalkBorder5.IsVisible = true;
          AssistLevelWalk5.IsVisible = true;
          AssistLevelWalk5.Text = Preferences.Get("AssistLevelWalk5", "0");
        }
        if (i == 6)
        {
          AssistLevelWalkLabel6.IsVisible = true;
          AssistLevelWalkBorder6.IsVisible = true;
          AssistLevelWalk6.IsVisible = true;
          AssistLevelWalk6.Text = Preferences.Get("AssistLevelWalk6", "0");
        }
        if (i == 7)
        {
          AssistLevelWalkLabel7.IsVisible = true;
          AssistLevelWalkBorder7.IsVisible = true;
          AssistLevelWalk7.IsVisible = true;
          AssistLevelWalk7.Text = Preferences.Get("AssistLevelWalk7", "0");
        }
        if (i == 8)
        {
          AssistLevelWalkLabel8.IsVisible = true;
          AssistLevelWalkBorder8.IsVisible = true;
          AssistLevelWalk8.IsVisible = true;
          AssistLevelWalk8.Text = Preferences.Get("AssistLevelWalk8", "0");
        }
        if (i == 9)
        {
          AssistLevelWalkLabel9.IsVisible = true;
          AssistLevelWalkBorder9.IsVisible = true;
          AssistLevelWalk9.IsVisible = true;
          AssistLevelWalk9.Text = Preferences.Get("AssistLevelWalk9", "0");
        }

      }
      else
      {
        if (i == 2)
        {
          AssistLevelWalkLabel2.IsVisible = false;
          AssistLevelWalkBorder2.IsVisible = false;
          AssistLevelWalk2.IsVisible = false;
        }
        if (i == 3)
        {
          AssistLevelWalkLabel3.IsVisible = false;
          AssistLevelWalkBorder3.IsVisible = false;
          AssistLevelWalk3.IsVisible = false;
        }
        if (i == 4)
        {
          AssistLevelWalkLabel4.IsVisible = false;
          AssistLevelWalkBorder4.IsVisible = false;
          AssistLevelWalk4.IsVisible = false;
        }
        if (i == 5)
        {
          AssistLevelWalkLabel5.IsVisible = false;
          AssistLevelWalkBorder5.IsVisible = false;
          AssistLevelWalk5.IsVisible = false;
        }
        if (i == 6)
        {
          AssistLevelWalkLabel6.IsVisible = false;
          AssistLevelWalkBorder6.IsVisible = false;
          AssistLevelWalk6.IsVisible = false;
        }
        if (i == 7)
        {
          AssistLevelWalkLabel7.IsVisible = false;
          AssistLevelWalkBorder7.IsVisible = false;
          AssistLevelWalk7.IsVisible = false;
        }
        if (i == 8)
        {
          AssistLevelWalkLabel8.IsVisible = false;
          AssistLevelWalkBorder8.IsVisible = false;
          AssistLevelWalk8.IsVisible = false;
        }
        if (i == 9)
        {
          AssistLevelWalkLabel9.IsVisible = false;
          AssistLevelWalkBorder9.IsVisible = false;
          AssistLevelWalk9.IsVisible = false;
        }

      }

    }



    checkValues = true;
  }

  //-------Assist level Walk Feature------------------------------------------------
  private void AssistLevelWalkFeature_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (AssistLevelWalkFeature.IsToggled)
    {
      Preferences.Set("AssistLevelWalkFeature", "true");
      AssistLevelWalkFeature.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("AssistLevelWalkFeature", "false");
      AssistLevelWalkFeature.ThumbColor = Colors.Red;
    }
  }
  private async void OnAssistLevelWalkFeatureLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enable or disable the walk assist function.", "OK");
  }


  //-------Assist level Walk Cruise Control------------------------------------------------
  private void AssistLevelWalkCruiseControl_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (AssistLevelWalkCruiseControl.IsToggled)
    {
      Preferences.Set("AssistLevelWalkCruiseControl", "true");
      AssistLevelWalkCruiseControl.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("AssistLevelWalkCruiseControl", "false");
      AssistLevelWalkCruiseControl.ThumbColor = Colors.Red;
    }
  }
  private async void OnAssistLevelWalkCruiseControlLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enable/Disable the cruise function. It can only be enabled with Walk assist enabled.\r\nBy pressing the DOWN button for a long time at speeds above 9 km/h and with the function enabled, the current speed is stored and maintained for as long as the button is pressed. \r\nSpeed may not be achieved due to limited motor power.\r\nThe speed limit has priority.  Find out about the legal restrictions in your country.\r\nIt is recommended to use cruise mode with brake sensors installed.\r\n", "OK");
  }





  //-------Assist Level Walk 1------------------------------------------------
  private void AssistLevelWalk1_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk1.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk1.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk1.TextColor != Colors.Red && int.Parse(AssistLevelWalk1.Text) > 254)
    {
      AssistLevelWalk1.TextColor = Colors.Red;
    }

    if (AssistLevelWalk1.TextColor != Colors.Red && AssistLevelWalk1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk1", AssistLevelWalk1.Text);
    }
  }

  private void AssistLevelWalk1_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk1.TextColor != Colors.Red && AssistLevelWalk1.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk1", AssistLevelWalk1.Text);
    }

    //dismiss keyboard
    AssistLevelWalk1.IsEnabled = false;
    AssistLevelWalk1.IsEnabled = true;
  }


  //-------Assist Level Walk 2------------------------------------------------
  private void AssistLevelWalk2_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk2.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk2.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk2.TextColor != Colors.Red && int.Parse(AssistLevelWalk2.Text) > 254)
    {
      AssistLevelWalk2.TextColor = Colors.Red;
    }

    if (AssistLevelWalk2.TextColor != Colors.Red && AssistLevelWalk2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk2", AssistLevelWalk2.Text);
    }
  }

  private void AssistLevelWalk2_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk2.TextColor != Colors.Red && AssistLevelWalk2.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk2", AssistLevelWalk2.Text);
    }

    //dismiss keyboard
    AssistLevelWalk2.IsEnabled = false;
    AssistLevelWalk2.IsEnabled = true;
  }



  //-------Assist Level Walk 3------------------------------------------------
  private void AssistLevelWalk3_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk3.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk3.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk3.TextColor != Colors.Red && int.Parse(AssistLevelWalk3.Text) > 254)
    {
      AssistLevelWalk3.TextColor = Colors.Red;
    }

    if (AssistLevelWalk3.TextColor != Colors.Red && AssistLevelWalk3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk3", AssistLevelWalk3.Text);
    }
  }

  private void AssistLevelWalk3_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk3.TextColor != Colors.Red && AssistLevelWalk3.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk3", AssistLevelWalk3.Text);
    }

    //dismiss keyboard
    AssistLevelWalk3.IsEnabled = false;
    AssistLevelWalk3.IsEnabled = true;
  }


  //-------Assist Level Walk 4------------------------------------------------
  private void AssistLevelWalk4_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk4.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk4.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk4.TextColor != Colors.Red && int.Parse(AssistLevelWalk4.Text) > 254)
    {
      AssistLevelWalk4.TextColor = Colors.Red;
    }

    if (AssistLevelWalk4.TextColor != Colors.Red && AssistLevelWalk4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk4", AssistLevelWalk4.Text);
    }
  }

  private void AssistLevelWalk4_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk4.TextColor != Colors.Red && AssistLevelWalk4.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk4", AssistLevelWalk4.Text);
    }

    //dismiss keyboard
    AssistLevelWalk4.IsEnabled = false;
    AssistLevelWalk4.IsEnabled = true;
  }



  //-------Assist Level Walk 5------------------------------------------------
  private void AssistLevelWalk5_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk5.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk5.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk5.TextColor != Colors.Red && int.Parse(AssistLevelWalk5.Text) > 254)
    {
      AssistLevelWalk5.TextColor = Colors.Red;
    }

    if (AssistLevelWalk5.TextColor != Colors.Red && AssistLevelWalk5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk5", AssistLevelWalk5.Text);
    }
  }

  private void AssistLevelWalk5_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk5.TextColor != Colors.Red && AssistLevelWalk5.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk5", AssistLevelWalk5.Text);
    }

    //dismiss keyboard
    AssistLevelWalk5.IsEnabled = false;
    AssistLevelWalk5.IsEnabled = true;
  }



  //-------Assist Level Walk 6------------------------------------------------
  private void AssistLevelWalk6_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk6.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk6.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk6.TextColor != Colors.Red && int.Parse(AssistLevelWalk6.Text) > 254)
    {
      AssistLevelWalk6.TextColor = Colors.Red;
    }

    if (AssistLevelWalk6.TextColor != Colors.Red && AssistLevelWalk6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk6", AssistLevelWalk6.Text);
    }
  }

  private void AssistLevelWalk6_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk6.TextColor != Colors.Red && AssistLevelWalk6.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk6", AssistLevelWalk6.Text);
    }

    //dismiss keyboard
    AssistLevelWalk6.IsEnabled = false;
    AssistLevelWalk6.IsEnabled = true;
  }



  //-------Assist Level Walk 7------------------------------------------------
  private void AssistLevelWalk7_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk7.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk7.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk7.TextColor != Colors.Red && int.Parse(AssistLevelWalk7.Text) > 254)
    {
      AssistLevelWalk7.TextColor = Colors.Red;
    }

    if (AssistLevelWalk7.TextColor != Colors.Red && AssistLevelWalk7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk7", AssistLevelWalk7.Text);
    }
  }

  private void AssistLevelWalk7_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk7.TextColor != Colors.Red && AssistLevelWalk7.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk7", AssistLevelWalk7.Text);
    }

    //dismiss keyboard
    AssistLevelWalk7.IsEnabled = false;
    AssistLevelWalk7.IsEnabled = true;
  }


  //-------Assist Level Walk 8------------------------------------------------
  private void AssistLevelWalk8_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk8.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk8.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk8.TextColor != Colors.Red && int.Parse(AssistLevelWalk8.Text) > 254)
    {
      AssistLevelWalk8.TextColor = Colors.Red;
    }

    if (AssistLevelWalk8.TextColor != Colors.Red && AssistLevelWalk8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk8", AssistLevelWalk8.Text);
    }
  }

  private void AssistLevelWalk8_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk8.TextColor != Colors.Red && AssistLevelWalk8.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk8", AssistLevelWalk8.Text);
    }

    //dismiss keyboard
    AssistLevelWalk8.IsEnabled = false;
    AssistLevelWalk8.IsEnabled = true;
  }



  //-------Assist Level Walk 9------------------------------------------------
  private void AssistLevelWalk9_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkValues) return;

    AssistLevelWalk9.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) AssistLevelWalk9.TextColor = Colors.LightGreen;

    //not > 254
    if (AssistLevelWalk9.TextColor != Colors.Red && int.Parse(AssistLevelWalk9.Text) > 254)
    {
      AssistLevelWalk9.TextColor = Colors.Red;
    }

    if (AssistLevelWalk9.TextColor != Colors.Red && AssistLevelWalk9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk9", AssistLevelWalk9.Text);
    }
  }

  private void AssistLevelWalk9_Completed(object sender, EventArgs e)
  {
    if (!checkValues) return;

    if (AssistLevelWalk9.TextColor != Colors.Red && AssistLevelWalk9.Text.Length != 0)
    {
      Preferences.Set("AssistLevelWalk9", AssistLevelWalk9.Text);
    }

    //dismiss keyboard
    AssistLevelWalk9.IsEnabled = false;
    AssistLevelWalk9.IsEnabled = true;
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