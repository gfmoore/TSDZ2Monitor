namespace TSDZ2Monitor.Classes;

public class Speedometer : IDrawable
{
  public Random random = new();

 
  public float speed { get; set; }

  public Speedometer()
  {

  }

  public void SpeedData(float spd)
  {
    speed = spd;
  }

  public void Draw(ICanvas canvas, RectF dirtyRect)
  {
    // Drawing code goes here
    //draw hub
    canvas.StrokeColor = Colors.Red;
    canvas.FillColor = Colors.Red;
    canvas.StrokeSize = 2;
    canvas.FillCircle(200, 200, 10);

    //draw speedometer outline
    canvas.StrokeColor = Colors.Blue;
    canvas.DrawArc(60, 60, 280, 280, -140, -400, true, false);

    //get system units - speed is always stored as kph
    //draw speedometer ticks and speeds
    if (Preferences.Get("VariousUnits", "Metric") == "Metric")
    {
      DrawTicksKPH(canvas, 0);
      DrawTicksKPH(canvas, 10);
      DrawTicksKPH(canvas, 20);
      DrawTicksKPH(canvas, 30);
      DrawTicksKPH(canvas, 40);
      DrawTicksKPH(canvas, 50);
      DrawTicksKPH(canvas, 60);
      DrawTicksKPH(canvas, 70);
      DrawTicksKPH(canvas, 80);
      DrawScaleKPH(canvas);

      DrawSpeedoKPH(canvas, speed);
      DrawSpeedArmKPH(canvas, speed);
    }
    else
    {
      DrawTicksMPH(canvas, 0);
      DrawTicksMPH(canvas, 10);
      DrawTicksMPH(canvas, 20);
      DrawTicksMPH(canvas, 30);
      DrawTicksMPH(canvas, 40);
      DrawTicksMPH(canvas, 50);
      DrawScaleMPH(canvas);

      speed = speed * 0.6214f; //kph to mph
      DrawSpeedoMPH(canvas, speed);
      DrawSpeedArmMPH(canvas, speed);
    }

  }

  //-----------KPH------------------------------------
  public void DrawSpeedoKPH(Microsoft.Maui.Graphics.ICanvas canvas, float speed)
  {
    float speedLimit = float.Parse(Preferences.Get("StreetModeSpeedLimit", "25"));

    float preSpeedLimit = speedLimit - 8.0f;
    float postSpeedLimit = 65.0f;
    float maxSpeedLimit = 80.0f;

    //green to speedlimit-5,
    //yellow from speedlimit-5 to speedlimit
    //orange from speedlimit to 65
    //red from 65 to 80

    float speedOriginal = speed;
    if (speed > maxSpeedLimit) speed = maxSpeedLimit;  //just to limit speedo

    //angle goes from -140 to -400 degrees (left to right) which is 0 to 50mph
    float angle0 = SpeedAngleKPH(0.0f);
    float angleA = SpeedAngleKPH(preSpeedLimit);  //green
    float angleB = SpeedAngleKPH(speedLimit);      //yellow
    float angleC = SpeedAngleKPH(postSpeedLimit);  //orange
    float angleD = SpeedAngleKPH(maxSpeedLimit);  //red

    //clear speedo indicator
    canvas.StrokeColor = Colors.Black;
    canvas.StrokeSize = 9;
    canvas.DrawArc(60, 60, 280, 280, angle0, angleD, true, false);

    canvas.StrokeColor = Colors.Blue;
    canvas.StrokeSize = 2;
    canvas.DrawArc(60, 60, 280, 280, angle0, angleD, true, false);

    canvas.StrokeSize = 8;
    float angle = SpeedAngleKPH(speed);

    if (speed >= 0.0f && speed < preSpeedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angle, true, false);
    }

    if (speed >= preSpeedLimit && speed < speedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angleA, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(60, 60, 280, 280, angleA, angle, true, false);
    }

    if (speed >= speedLimit && speed < postSpeedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angleA, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(60, 60, 280, 280, angleA, angleB, true, false);

      canvas.StrokeColor = Colors.Orange;
      canvas.DrawArc(60, 60, 280, 280, angleB, angle, true, false);
    }

    if (speed >= postSpeedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angleA, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(60, 60, 280, 280, angleA, angleB, true, false);

      canvas.StrokeColor = Colors.Orange;
      canvas.DrawArc(60, 60, 280, 280, angleB, angleC, true, false);
      
      canvas.StrokeColor = Colors.Firebrick;
      canvas.DrawArc(60, 60, 280, 280, angleC, angle, true, false);
    }

    //Draw speed in units
    canvas.FontColor = Colors.White;
    canvas.FontSize = 30;
    canvas.Font = Font.Default;
    //canvas.Font = Font.DefaultBold;

    canvas.DrawString(speedOriginal.ToString("F0"), 168, 250, 70, 40, HorizontalAlignment.Center, VerticalAlignment.Top);
  }

  public void DrawSpeedArmKPH(ICanvas canvas, float speed)
  {
    if (speed > 80.0f) speed = 80.0f;
    int r = 120;
    //angle goes from -140 to -400 degrees (left to right) which is 0 to 80kph
    canvas.StrokeSize = 3;
    canvas.StrokeColor = Colors.Red;

    float angle = SpeedAngleKPH(speed);
    int x = 200 + (int)(r * Math.Cos(angle*Math.PI/180.0f));
    int y = 200 - (int)(r * Math.Sin(angle*Math.PI/180.0f));
    canvas.DrawLine(200, 200, x, y);
  }

  public void DrawTicksKPH(ICanvas canvas, float speed)
  {
    float angle = SpeedAngleKPH(speed);

    float startR = 145;
    float endR = 160;


    canvas.StrokeSize = 3;
    canvas.StrokeColor = Colors.White;

    int xs = 200 + (int)(startR * Math.Cos(angle * Math.PI / 180.0f));
    int ys = 200 - (int)(startR * Math.Sin(angle * Math.PI / 180.0f));

    int xe = 200 + (int)(endR * Math.Cos(angle * Math.PI / 180.0f));
    int ye = 200 - (int)(endR * Math.Sin(angle * Math.PI / 180.0f));
    
    canvas.DrawLine(xs, ys, xe, ye);


    float startT = 180;
    int xt = 200 + (int)(startT * Math.Cos(angle * Math.PI / 180.0f));
    int yt = 200 - (int)(startT * Math.Sin(angle * Math.PI / 180.0f));

  }

  public void DrawScaleKPH(ICanvas canvas)
  {
    //easier to fudge manually
    canvas.FontColor = Colors.White;
    canvas.FontSize = 20;
    canvas.Font = Font.Default;
    //canvas.Font = Font.DefaultBold;

    canvas.DrawString("0",  60, 300, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("10", 10, 208, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("20", 23, 115, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("30", 90, 37, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("40", 185, 13, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("50", 283, 37, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("60", 352, 116, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("70", 361, 209, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("80", 328, 300, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);

  }

  public float SpeedAngleKPH(float speed)
  {
    float angle = -140.0f - (260.0f / 80.0f * speed);
    return angle;
  }


  //-----------MPH------------------------------------
  public void DrawSpeedoMPH(Microsoft.Maui.Graphics.ICanvas canvas, float speed)
  {
    float speedLimit = float.Parse(Preferences.Get("StreetModeSpeedLimit", "16"));
    //should be in kph so convert to mph
    speedLimit = speedLimit * 0.6214f;

    float preSpeedLimit = speedLimit - 5.0f;
    float postSpeedLimit = 40.0f;
    float maxSpeedLimit = 50.0f;

    //green to speedlimit-5,
    //yellow from speedlimit-5 to speedlimit
    //orange from speedlimit to 40
    //red from 40 to 50

    float speedOriginal = speed;
    if (speed > 50.0f) speed = 50.0f;

    //angle goes from -140 to -400 degrees (left to right) which is 0 to 50mph
    float angle0  = SpeedAngleMPH(0.0f);
    float angleA = SpeedAngleMPH(preSpeedLimit);  //green
    float angleB = SpeedAngleMPH(speedLimit);  //yellow
    float angleC = SpeedAngleMPH(postSpeedLimit);  //orange
    float angleD = SpeedAngleMPH(maxSpeedLimit);  //red

    //clear speedo indicator
    canvas.StrokeColor = Colors.Black;
    canvas.StrokeSize = 9;
    canvas.DrawArc(60, 60, 280, 280, angle0, angleD, true, false);

    canvas.StrokeColor = Colors.Blue;
    canvas.StrokeSize = 2;
    canvas.DrawArc(60, 60, 280, 280, angle0, angleD, true, false);

    canvas.StrokeSize = 8;
    float angle = SpeedAngleMPH(speed);

    if (speed >= 0.0f && speed < preSpeedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angle, true, false);
    }

    if (speed >= preSpeedLimit && speed < speedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angleA, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(60, 60, 280, 280, angleA, angle, true, false);
    }

    if (speed >= speedLimit && speed < postSpeedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angleA, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(60, 60, 280, 280, angleA, angleB, true, false);

      canvas.StrokeColor = Colors.Orange;
      canvas.DrawArc(60, 60, 280, 280, angleB, angle, true, false);
    }
    if (speed >= postSpeedLimit)
    {
      canvas.StrokeColor = Colors.Green;
      canvas.DrawArc(60, 60, 280, 280, angle0, angleA, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(60, 60, 280, 280, angleA, angleB, true, false);

      canvas.StrokeColor = Colors.Orange;
      canvas.DrawArc(60, 60, 280, 280, angleB, angleC, true, false);

      canvas.StrokeColor = Colors.Firebrick;
      canvas.DrawArc(60, 60, 280, 280, angleC, angle, true, false);
    }

    //Draw speed in units
    canvas.FontColor = Colors.White;
    canvas.FontSize = 30;
    canvas.Font = Font.Default;
    //canvas.Font = Font.DefaultBold;

    canvas.DrawString(speedOriginal.ToString("F0"), 168, 250, 70, 40, HorizontalAlignment.Center, VerticalAlignment.Top);


  }

  public void DrawSpeedArmMPH(ICanvas canvas, float speed)
  {
    if (speed > 50.0f) speed = 50.0f;
    int r = 120;
    //angle goes from -140 to -400 degrees (left to right) which is 0 to 80kph
    canvas.StrokeSize = 3;
    canvas.StrokeColor = Colors.Red;

    float angle = SpeedAngleMPH(speed);
    int x = 200 + (int)(r * Math.Cos(angle * Math.PI / 180.0f));
    int y = 200 - (int)(r * Math.Sin(angle * Math.PI / 180.0f));
    canvas.DrawLine(200, 200, x, y);
  }

  public void DrawTicksMPH(ICanvas canvas, float speed)
  {
    float angle = SpeedAngleMPH(speed);

    float startR = 145;
    float endR = 160;


    canvas.StrokeSize = 3;
    canvas.StrokeColor = Colors.White;

    int xs = 200 + (int)(startR * Math.Cos(angle * Math.PI / 180.0f));
    int ys = 200 - (int)(startR * Math.Sin(angle * Math.PI / 180.0f));

    int xe = 200 + (int)(endR * Math.Cos(angle * Math.PI / 180.0f));
    int ye = 200 - (int)(endR * Math.Sin(angle * Math.PI / 180.0f));

    canvas.DrawLine(xs, ys, xe, ye);


    float startT = 180;
    int xt = 200 + (int)(startT * Math.Cos(angle * Math.PI / 180.0f));
    int yt = 200 - (int)(startT * Math.Sin(angle * Math.PI / 180.0f));

  }

  public void DrawScaleMPH(ICanvas canvas)
  {
    //easier to fudge manually
    canvas.FontColor = Colors.White;
    canvas.FontSize = 20;
    canvas.Font = Font.Default;
    //canvas.Font = Font.DefaultBold;

    canvas.DrawString("0", 60, 300, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("10", 15, 152, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("20", 110, 32, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("30", 260, 32, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("40", 363, 153, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    canvas.DrawString("50", 328, 300, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);

  }

  public float SpeedAngleMPH(float speed)
  {
    float angle = -140.0f - (260.0f / 50.0f * speed);
    return angle;
  }
}


//https://stackoverflow.com/questions/71001039/net-maui-how-to-draw-on-canvas
//https://docs.microsoft.com/en-us/dotnet/maui/user-interface/graphics/
//https://github.com/pierre01/UCSD-MAUI-Samples/blob/development/MauiGraphics/Views/BasicGraphicsPage.xaml