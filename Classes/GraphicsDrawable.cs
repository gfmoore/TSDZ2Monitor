namespace TSDZ2Monitor.Classes;

public class GraphicsDrawable : IDrawable
{
  public Random random = new();
  public float speed;

  public void GetData(float spd)
  {
    speed = spd;
  }

  public void Draw(ICanvas canvas, RectF dirtyRect)
  {
    // Drawing code goes here
    canvas.StrokeColor = Colors.Red;
    canvas.FillColor = Colors.Red;
    canvas.StrokeSize = 3;
    canvas.FillCircle(200, 200, 10);
    
    canvas.DrawLine(200, 200, 100, 100);

    canvas.StrokeColor = Colors.CornflowerBlue;
    canvas.DrawArc(50, 50, 300, 300, -140, -400, true, false);

    //float speed = (float)random.NextDouble();
    //speed = speed * 100.0f;
    drawSpeedoKPH(canvas, speed);

  }

  public void drawSpeedoKPH(Microsoft.Maui.Graphics.ICanvas canvas, float speed)
  {

    //angle goes from -140 to -400 degrees (left to right) which is 0 to 80kph
    float angle0 = SpeedAngle(0.0f);
    float angle20 = SpeedAngle(20.0f);
    float angle30 = SpeedAngle(30.0f);
    float angle60 = SpeedAngle(60.0f);
    float angle80 = SpeedAngle(80.0f);

    //clear speedo indicator
    canvas.StrokeColor = Colors.Black;
    canvas.StrokeSize = 6;
    canvas.DrawArc(50, 50, 300, 300, angle0, angle80, true, false);

    canvas.StrokeColor = Colors.CornflowerBlue;
    canvas.StrokeSize = 3;
    canvas.DrawArc(50, 50, 300, 300, angle0, angle80, true, false);

    canvas.StrokeSize = 6;
    float angle = SpeedAngle(speed);

    if (speed >= 0 && speed < 20)
    {
      canvas.StrokeColor = Colors.LightGreen;
      canvas.DrawArc(50, 50, 300, 300, angle0, angle, true, false);
    }
    if (speed >= 20 && speed < 30)
    {
      canvas.StrokeColor = Colors.LightGreen;
      canvas.DrawArc(50, 50, 300, 300, angle0, angle20, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(50, 50, 300, 300, angle20, angle, true, false);
    }
    if (speed >= 30 && speed < 60)
    {
      canvas.StrokeColor = Colors.LightGreen;
      canvas.DrawArc(50, 50, 300, 300, angle0, angle20, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(50, 50, 300, 300, angle20, angle30, true, false);

      canvas.StrokeColor = Colors.Orange;
      canvas.DrawArc(50, 50, 300, 300, angle30, angle, true, false);
    }
    if (speed >= 60)
    {
      canvas.StrokeColor = Colors.LightGreen;
      canvas.DrawArc(50, 50, 300, 300, angle0, angle20, true, false);

      canvas.StrokeColor = Colors.Yellow;
      canvas.DrawArc(50, 50, 300, 300, angle20, angle30, true, false);

      canvas.StrokeColor = Colors.Orange;
      canvas.DrawArc(50, 50, 300, 300, angle30, angle60, true, false);
      
      canvas.StrokeColor = Colors.Red;
      canvas.DrawArc(50, 50, 300, 300, angle60, angle, true, false);
    }

  }

  public float SpeedAngle(float speed)
  {
    float angle = -140.0f - (220.0f/80.0f * speed);
    return angle;
  }

}


//https://stackoverflow.com/questions/71001039/net-maui-how-to-draw-on-canvas
//https://docs.microsoft.com/en-us/dotnet/maui/user-interface/graphics/