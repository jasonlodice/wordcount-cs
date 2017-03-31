using System;
using System.IO;

namespace WordCountApp
{
    /// <summary>
    /// Read a stream and identify special words.
    /// </summary>
    public class WordStreamReader : IDisposable
    {
        /// <summary>
        /// Stream to read from
        /// </summary>
        private readonly StreamReader _streamReader;

        /// <summary>
        /// End of file token
        /// </summary>
        private const int EndOfFile = -1;

        /// <summary>
        /// Word Builder
        /// </summary>
        private readonly WordBuilder _wordBuilder = new WordBuilder();

        public WordStreamReader(Stream stream)
        {
            _streamReader = new StreamReader(stream);
        }

        /// <summary>
        /// Read the stream and find special words
        /// </summary>
        public void Read()
        {
            while (true)
            {
                //   read one character at a time
                var c = _streamReader.Read();
                if (c == EndOfFile)
                {
                    break;
                }

                var word = _wordBuilder.PushChar((char)c);

                //  see if we have completed a word
                if (word != null)
                {
                    EvaluateMaxCharFrequencyWord(word);

                    //  NOTE: not required, showing how this program could be extended
                    //  with additional functionality
                    EvaluateMaxLengthWord(word);
                }
            }
        }

        /// <summary>
        /// Conditionally update the current MaxCharFrequencyWord
        /// </summary>
        /// <param name="word"></param>
        private void EvaluateMaxCharFrequencyWord(Word word)
        {
            //  see if we should replace current MaxLetter word
            if (MaxCharFrequencyWord == null
                || word.MaxCharFrequency > MaxCharFrequencyWord.MaxCharFrequency)
            {
                MaxCharFrequencyWord = word;
            }
        }

        private void EvaluateMaxLengthWord(Word word)
        {
            //  see if we should replace current MaxLength word
            if (MaxLengthWord == null
                || word.Length > MaxLengthWord.Length)
            {
                MaxLengthWord = word;
            }
        }

        /// <summary>
        /// Word with the highest frequency character in it
        /// </summary>
        public Word MaxCharFrequencyWord { get; private set; }

        /// <summary>
        /// Word with the most characters
        /// </summary>
        public Word MaxLengthWord { get; set; }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}