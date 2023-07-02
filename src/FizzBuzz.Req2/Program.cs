using TwistedFizzBuzz;

namespace FizzBuzz.Req2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SolvePrintReq2(1, 100);
        }

        public static void SolvePrintReq2(int start, int end)
        {
            TwistedFB fizzBuzzL = new TwistedFB();
            List<string> result = fizzBuzzL.RangeFizzBuzz(start, end);
            result.ForEach(x => Console.WriteLine(x));
        }
    }
}