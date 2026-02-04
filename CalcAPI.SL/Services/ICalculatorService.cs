namespace CalcAPI.SL.Services;

public interface ICalculatorService
{
    public int CalculateTimeAngle(DateTime time);
    public int CalculateTimeAngle(int hour, int minute);
}
