using TwistedFizzBuzz;

namespace FizzBuzz.Req2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TwistedFB fizzBuzzL = new TwistedFB();
            List<string> result = fizzBuzzL.RangeFizzBuzz(1, 100);
            result.ForEach(x => Console.WriteLine(x));
        }
    }
}