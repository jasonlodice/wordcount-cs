using System.Linq;
using System.Text;

namespace WordCountApp
{
    /// <summary>
    /// A string word which can calculate character frequency.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Hold the characters we are accumulating
        /// </summary>
        private readonly StringBuilder _string = new StringBuilder();

        /// <summary>
        /// cached value of max frequency character
        /// </summary>
        private int? _maxCharFrequency;

        /// <summary>
        /// cached value of string length
        /// </summary>
        private int? _length;

        public void Append(char c)
        {
            _string.Append(c);

            //  invalidate cached values
            _maxCharFrequency = null;
            _length = null;
        }

        /// <summary>
        /// Maximum frequency of any letter in the word
        /// </summary>
        /// <returns></returns>
        public int MaxCharFrequency
        {
            get
            {
                //  value is cached for performance
                if (!_maxCharFrequency.HasValue)
                {
                    //  update cached value
                    var filtered = _string.ToString()
                        .Where(char.IsLetter)
                        .ToArray();

                    //  if string empty, return 0
                    //  otherwise group by character, return count of most frequent
                    _maxCharFrequency = filtered.Length == 0
                        ? 0
                        : filtered.GroupBy(char.ToLower).Max(g => g.Count());
                }

                return _maxCharFrequency.Value;
            }
        }

        /// <summary>
        /// Length of this word.
        /// </summary>
        public int Length
        {
            get
            {
                //  value cached for performance
                if (!_length.HasValue)
                {
                    _length = ToString().Length;
                }

                return _length.Value;
            }
        }

        public override string ToString()
        {
            return _string.ToString();
        }
    }
}