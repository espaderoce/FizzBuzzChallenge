using Newtonsoft.Json;

namespace TwistedFizzBuzz
{
    public class TwistedFB
    {
        protected Dictionary<int, string> Tokens { get; set; }


        public TwistedFB()
        {
            Tokens = new Dictionary<int, string>() { { 3, "Fizz" }, { 5, "Buzz" } };
        }
        public TwistedFB(Dictionary<int, string> tokens)
        {
            Tokens = tokens;
        }
        public void SetTokens(Dictionary<int, string> tokens)
        {
            Tokens = tokens;
        }
        /// <summary>
        /// Generate FizzBuzz taking a range of values as arguments
        /// </summary>
        /// <param name="start">from this value</param>
        /// <param name="end">to this value</param>
        public IEnumerable<string> RangeFizzBuzz(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return RangeFizzBuzz(i, Tokens);
            }
        }
        /// <summary>
        /// Generate FizzBuzz, This works with a non-sequential values, example: [-5, 6, 300, 12, 15]
        /// </summary>
        /// <param name="numbers"> Array of number </param>
        public IEnumerable<string> RangeFizzBuzz(int[] numbers)
        {
            foreach (int i in numbers)
            {
                yield return RangeFizzBuzz(i, Tokens);

            }
        }

        /// <summary>
        /// Generate FizzBuzz for alternative tokens, we can define our custom tokens using a dictionary.
        /// </summary>
        /// <param name="number">The value forfor the verification</param>
        /// <param name="tokens">The custom tokens  to be used</param>
        public string RangeFizzBuzz(int number, Dictionary<int, string> tokens)
        {
            string result = "";
            string value = "";
            foreach (var i in tokens)
            {
                if (number % i.Key == 0)
                    result += i.Value;
                else
                {
                    value = number.ToString();
                }
            }
            if (result != "")
                return result;
            else
                return value;
        }

        /// <summary>
        /// Receive a generated token from an API.
        /// </summary>
        /// <param name="data"> The generated Token</param>
        /// <param name="start">The number to start the iteration</param>
        /// <param name="end">The number to end the iteration</param>
        /// <returns></returns>
        public IEnumerable<string> RangeFizzBuzz(FizzBuzzToken data, int start = 1, int end = 100)
        {
            for (int i = start; i <= end; i++)
            {
                yield return RangeFizzBuzz(i, new Dictionary<int, string> { { data.Multiple, data.Word } });
            }
        }

        /// <summary>
        /// It helps us to generate Tokens using the API
        /// </summary>
        /// <returns>FizzBuzzToken: Generated Token from the API </returns>
        public async Task<FizzBuzzToken?> GenerateToken()
        {
            FizzBuzzToken? fizzBuzzToken = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync("https://rich-red-cocoon-veil.cyclic.app/random");
                    fizzBuzzToken = JsonConvert.DeserializeObject<FizzBuzzToken>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something go wrong:", ex.Message);
            }
            return fizzBuzzToken;
        }
    }

    /// <summary>
    /// Model For Generated Tokens 
    /// </summary>
    public class FizzBuzzToken
    {
        public int Multiple { get; set; }
        public string Word { get; set; }
    }
}