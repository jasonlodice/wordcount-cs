using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCountApp.Test
{
    [TestClass]
    public class WordBuilderTest
    {
        private WordBuilder _wordBuilder;

        [TestInitialize]
        public void TestInitialize()
        {
            _wordBuilder = new WordBuilder();
        }

        [TestMethod]
        public void PushChar_NonWhitespace_DoesNotReturnWord()
        {           
            //  push a non whitespace character
            var word = _wordBuilder.PushChar('a');

            Assert.IsNull(word);
        }

        [TestMethod]
        public void PushChar_TerminatingWhitespace_ReturnsWord()
        {
            //  push a non whitespace characters
            _wordBuilder.PushChar('h');
            _wordBuilder.PushChar('e');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('o');

            //  whitespace should then produce a word
            var word = _wordBuilder.PushChar(' ');

            Assert.IsNotNull(word);
            Assert.AreEqual("hello", word.ToString());
        }

        [TestMethod]
        public void PushChar_AdditionalWhitespace_DoesNotReturnWord()
        {
            //  push a non whitespace characters
            _wordBuilder.PushChar('h');
            _wordBuilder.PushChar('e');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('o');
            _wordBuilder.PushChar(' ');

            //  additional whitespace should not return a new word
            var word = _wordBuilder.PushChar('\r');

            Assert.IsNull(word);
        }

        [TestMethod]
        public void PushChar_Hyphen_AppendedToWord()
        {
            //  push characters
            _wordBuilder.PushChar('B');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('u');
            _wordBuilder.PushChar('e');
            _wordBuilder.PushChar('-');
            _wordBuilder.PushChar('c');
            _wordBuilder.PushChar('o');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('l');
            _wordBuilder.PushChar('a');
            _wordBuilder.PushChar('r');

            //  whitespace should then produce a word
            var word = _wordBuilder.PushChar(' ');

            Assert.IsNotNull(word);
            Assert.AreEqual("Blue-collar", word.ToString());
        }

        [TestMethod]
        public void PushChar_Apostrophe_AppendedToWord()
        {
            //  push characters
            _wordBuilder.PushChar('w');
            _wordBuilder.PushChar('o');
            _wordBuilder.PushChar('n');
            _wordBuilder.PushChar('\'');
            _wordBuilder.PushChar('t');

            //  whitespace should then produce a word
            var word = _wordBuilder.PushChar(' ');

            Assert.IsNotNull(word);
            Assert.AreEqual("won't", word.ToString());
        }
    }
}
