using System;

namespace WordCountApp
{
    /// <summary>
    /// Class which can process characters into <see cref="Word"/> instance
    /// </summary>
    public class WordBuilder
    {
        /// <summary>
        /// The current word we are building.
        /// </summary>
        private Word _currentWord;

        /// <summary>
        /// Add a character to the word builder.  
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Returns a new word instance if this character marked the end of a word, otherwise null.</returns>
        public Word PushChar(char c)
        {
            if (IsWordStarted() && IsWordSeparator(c))
            {
                //  terminate the word
                var word = _currentWord;
                EndWord();
                return word;
            }
            else if (IsAllowedWordCharacter(c))
            {
                //  make sure we have a word to build
                if (!IsWordStarted())
                {
                    StartWord();
                }

                //  add new character to the word
                _currentWord.Append(c);
            }

            //  we have not encountered the end of the word
            return null;
        }

        /// <summary>
        /// Are we currently building a word
        /// </summary>
        /// <returns></returns>
        private bool IsWordStarted()
        {
            return _currentWord != null;
        }

        /// <summary>
        /// Start building a new word
        /// </summary>
        private void StartWord()
        {
            _currentWord = new Word();
        }

        /// <summary>
        /// Stop building current word
        /// </summary>
        private void EndWord()
        {
            _currentWord = null;
        }

        /// <summary>
        /// Is this character allowed to be part of a word?
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool IsAllowedWordCharacter(char c)
        {
            return c == '\'' || c == '-' || Char.IsLetter(c);
        }

        /// <summary>
        /// Is this a character which signals end of a word?
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool IsWordSeparator(char c)
        {
            return Char.IsWhiteSpace(c) || Char.IsPunctuation(c);
        }
    }
}