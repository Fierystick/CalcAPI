namespace CalcAPI.Services;

public class CalculatorService : ICalculatorService
{
    public int CalculateTimeAngle(DateTime dateTime)
    {
        if(dateTime.GetType() != typeof(DateTime))
        {
            throw new FormatException("Invalid DateTime format.");
        }

        int hour = dateTime.Hour % 12;
        int minute = dateTime.Minute;
        
        if (hour < 0 || hour > 12 || minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException("Hour constraint: 0-12 ; minute constraint: 0-59.");
        }
        //double second = dateTime.Second;
        //double minuteWithSeconds = minute + (second / 60.0);
        //Test questions did not ask me to consider seconds, so not implementing this. 
        return CalculateTimeAngle(hour, minute);
    }

    public int CalculateTimeAngle(int hour, int minute)
    {
        if (hour < 0 || hour > 12 || minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException("Hour constraint: 0-12 ; minute constraint: 0-59.");
        }

        double hourAngle = hour * 30; 
        double minuteAngle = minute * 6; 

        double angle = Math.Abs(hourAngle - minuteAngle);

        angle = Math.Min(360 - angle, angle);

        return (int)angle;
    }
}
