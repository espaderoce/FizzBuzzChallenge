
using Xunit;

namespace TwistedFizzBuzz.Test
{
    public class TwistedFizzBuzzTEST
    {
        private readonly TwistedFB fizzBuzz = new();

        [Fact]
        public void Range_FizzBuzz_Test_ShouldPass()
        {
            List<string> expectedResult = new List<string>()
            {"1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"};
            List<string> result = fizzBuzz.RangeFizzBuzz(1, 15);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NoSequencial_FizzBuzz_Test_ShouldPass()
        {
            List<string> expectedResult = new List<string>()
            {"Buzz","Fizz","FizzBuzz","Fizz","FizzBuzz"};
            int[] inputs = new int[] { -5, 6, 300, 12, 15 };
            List<string>  result = fizzBuzz.RangeFizzBuzz(inputs);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5, "Unit",25,"Unit")]
        [InlineData(3, "Test", 6, "Test")]
        [InlineData(5, "XUnit", 15, "XUnit")]
        public void CustomTokens_FizzBuzz_Test_ShouldPass(int inlineKey, string inlineValue ,int inlineInput, string InlineExpectedResult)
        {
            var result = fizzBuzz.RangeFizzBuzz(inlineInput, new Dictionary<int, string> { { inlineKey, inlineValue } });
            Assert.Equal(InlineExpectedResult, result);
        }

        [Theory]
        [InlineData(5, "Test", "Test")]
        [InlineData(3, "Panic", "Panic")]
        [InlineData(6, "Unit", "Unit")]
        public void InputGeneratedToken_FizzBuzz_Test_ShouldPass(int inlineMultiple,string inlineWord,string inlineExpected)
        {
            FizzBuzzToken generatedToken = new FizzBuzzToken() {Multiple = inlineMultiple, Word = inlineWord };
            List<string> expectedResult = new List<string>() {inlineExpected};
            List<string> result = fizzBuzz.RangeFizzBuzz(generatedToken, generatedToken.Multiple, generatedToken.Multiple);
            Assert.Equal(expectedResult,result);
        }

        [Fact]
        public async Task GenerateToken_FizzBuzz_Test_ShouldPass()
        {
            FizzBuzzToken? result = await fizzBuzz.GenerateToken();
            Assert.NotNull(result);
        }
    }
}