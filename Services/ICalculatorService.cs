namespace CalcAPI.Services;

public interface ICalculatorService
{
    public int CalculateTimeAngle(DateTime time);
    public int CalculateTimeAngle(int hour, int minute);
}
