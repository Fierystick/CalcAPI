using Xunit;
using CalcAPI.SL.Services;

namespace CalcAPI.Tests;

public class CalculatorServiceTests
{
    private readonly CalculatorService _calculatorService;

    public CalculatorServiceTests()
    {
        _calculatorService = new CalculatorService();
    }

    [Theory]
    [InlineData(3, 0, 90)]
    [InlineData(6, 0, 180)]
    [InlineData(9, 0, 90)]
    [InlineData(12, 0, 0)]
    public void CalculateTimeAngle_HourMinute_ReturnsAngle(int hour, int minute, int expectedAngle)
    {
        var angle = _calculatorService.CalculateTimeAngle(hour, minute);
        Assert.Equal(expectedAngle, angle);
    }
    [Theory]
    [InlineData("12/01/26 12:00:00", 0)]
    [InlineData("12/01/26 06:00:00", 180)]
    [InlineData("12/01/26 03:00:00", 90)]
    [InlineData("12/01/26 09:00:00", 90)]
    [InlineData("12/01/26 12:07:00", 42)]
    public void CalculateTimeAngle_DateTime_ReturnsAngle(string dateTimeString, double expectedAngle)
    {
        var dateTime = DateTime.Parse(dateTimeString);
        var angle = _calculatorService.CalculateTimeAngle(dateTime);
        Assert.Equal(expectedAngle, angle);
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(13, 0)]
    [InlineData(0, -1)]
    [InlineData(0, 60)]
    public void CalculateTimeAngle_InvalidHourMinute_ThrowsArgumentOutOfRangeException(int hour, int minute)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculatorService.CalculateTimeAngle(hour, minute));
    }

    [Theory]
    [InlineData("-12/01/26 12:00:00")]
    [InlineData("13/01/2026 13:00:00")]
    [InlineData("12/01/26 24:59:59")]
    [InlineData("12/32/26 14:10:10")]
    public void CalculateTimeAngle_InvalidDateTime_ThrowsSystemFormatException(string dateTimeString)
    {
        Assert.Throws<FormatException>(() => DateTime.Parse(dateTimeString));
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(13, 0)]
    [InlineData(0, -1)]
    [InlineData(0, 60)]
    public void CalculateTimeAngle_InvalidDateTime_ThrowsArgumentOutOfRangeException(int hour, int minute)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculatorService.CalculateTimeAngle(hour, minute));
    }
}
