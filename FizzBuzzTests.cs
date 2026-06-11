namespace CodingTask.Tests
{
    public class FizzBuzzTests
    {
        private readonly FizzBuzzDetector _detector;

        public FizzBuzzTests()
        {
            _detector = new FizzBuzzDetector();
        }

        [Fact] // main test form task
        public void GetOverlappings_ShouldReturnCorrectStringAndCount_ForExampleInput1()
        {
            string input = "Mary had a little lamb \r\nLittle lamb, little lamb \r\nIt's fleece was white as snow";

            string expectedOutput = "Mary had Fizz little Buzz \r\nFizz lamb, little Fizz \r\nBuzz's Fizz was white FizzBuzz snow";

            int expectedCount = 7;

            FizzBuzzResult result = _detector.getOverlappings(input);

            string normalizedExpected = expectedOutput.Replace("\r\n", "\n");
            string normalizedResult = result.OutputString.Replace("\r\n", "\n");

            Assert.Equal(normalizedExpected, normalizedResult);
            Assert.Equal(expectedCount, result.Count);
        }

        [Fact] // test if it too short input
        public void GetOverlappings_ShouldThrowArgumentException_WhenInputIsTooShort()
        {
            string input = "har";
            
            Assert.Throws<ArgumentException>(() => _detector.getOverlappings(input));
        }

        [Fact] // test if it too long input
        public void GetOverlappings_ShouldThrowArgumentException_WhenInputIsTooLong()
        {
            string input = new string('a', 101); // this will create string with 101 'a'

            Assert.Throws <ArgumentException>(() => _detector.getOverlappings(input));
        }

        [Fact] // test if input is a null
        public void GetOverlappings_ShouldThrowArgumentNullException_WhenInputIsNull()
        {
            string input = null;

            Assert.Throws<ArgumentNullException>(() => _detector.getOverlappings(input));
        }

        [Fact] // test if punctuation marks are preserved correctly
        public void GetOverlappings_ShouldKeepPunctuationIntact_ProcessWords()
        {
            string input = "word, words, word. words, word.";
            string expectedOutput = "word, words, Fizz. words, Buzz.";
            int expectedCount = 2;

            FizzBuzzResult result = _detector.getOverlappings(input);

            Assert.Equal(expectedOutput, result.OutputString);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}