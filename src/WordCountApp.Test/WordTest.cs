using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCountApp.Test
{
    [TestClass]
    public class WordTest
    {
        [TestMethod]
        public void MaxLetterCount_AllSingleChars_ReturnsOne()
        {
            var word = new Word();
            word.Append('h');
            word.Append('i');

            Assert.AreEqual(1, word.MaxCharFrequency);
        }

        [TestMethod]
        public void MaxLetterCount_DoubleChars_ReturnsTwo()
        {
            var word = new Word();
            word.Append('h');
            word.Append('e');
            word.Append('l');
            word.Append('l');
            word.Append('o');

            Assert.AreEqual(2, word.MaxCharFrequency);
        }

        [TestMethod]
        public void MaxLetterCount_IgnoresNonLetters_ReturnsTwo()
        {

            var word = new Word();
            word.Append('-');
            word.Append('-');
            word.Append('\'');

            Assert.AreEqual(0, word.MaxCharFrequency);
        }
    }
}