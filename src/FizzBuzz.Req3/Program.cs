using TwistedFizzBuzz;

namespace FizzBuzz.Req3
{
    public class Program
    {
        static void Main(string[] args)
        {
            SolvePrintReq2(-20, 127, new Dictionary<int, string>() { { 5, "Fizz" }, { 9, "Buzz" }, { 27, "Bar" } });
        }

        public static void SolvePrintReq2(int start,int end, Dictionary<int,string> tokens)
        {
            TwistedFB fizzBuzzL = new TwistedFB(tokens);
            IEnumerable<string> result = fizzBuzzL.RangeFizzBuzz(start, end);
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }

    }
}