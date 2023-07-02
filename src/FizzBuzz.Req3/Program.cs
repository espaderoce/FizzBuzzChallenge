using TwistedFizzBuzz;

namespace FizzBuzz.Req3
{
    public class Program
    {
        static void Main(string[] args)
        {
            TwistedFB fizzBuzzL = new TwistedFB();
            fizzBuzzL.SetTokens(new Dictionary<int, string>() { { 5, "Fizz" }, { 9, "Buzz" }, { 27, "Bar" } });
            List<string>  result = fizzBuzzL.RangeFizzBuzz(-20, 127);
            result.ForEach(x => Console.WriteLine(x));
        }

    }
}