using System.Text.RegularExpressions;
using System.Security.Cryptography; // Randomクラスよりも厳密な乱数を生成するRandomNumberGeneratorクラスの利用（https://learn.microsoft.com/ja-jp/dotnet/api/system.security.cryptography.randomnumbergenerator?view=net-8.0）

double r = 1.0;

Console.WriteLine($"Radius of circle is {r}.");
Console.Write("Please enter the number of dots to be dotted as an integer. >> ");
string? inputText = Console.ReadLine() ?? throw new NullReferenceException("Please enter any number...");
ulong dotsNum = InputTextRegex().IsMatch(inputText) ? ulong.Parse(inputText) : throw new ArgumentException("Please enter only integer values...");

string result = calcPi(dotsNum, r).ToString("f10");
Console.WriteLine($"Result: {result}");

///
/// Function to calc Pi. Must give two argiments.
/// allDotsNum: The number of dots.
/// r: The radius of square (r * r) that be doted.
///
static double calcPi(ulong allDotsNum, double r)
{
    int maxValueOfInt32 = 2147483647;
    ulong dotsNumInCircle = 0;
    double x;
    double y;

    for (ulong i = 0; i < allDotsNum; i++)
    {
        x = (double)RandomNumberGenerator.GetInt32(maxValueOfInt32) / maxValueOfInt32 * r;
        y = (double)RandomNumberGenerator.GetInt32(maxValueOfInt32) / maxValueOfInt32 * r;
        if ((x * x + y * y) <= r * r)
        {
            dotsNumInCircle++;
        }
    }

    return (double)dotsNumInCircle / allDotsNum * 4;
}

partial class Program
{
    [GeneratedRegex(@"^[0-9]*$")]
    private static partial Regex InputTextRegex();
}