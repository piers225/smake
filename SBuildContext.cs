using System.Collections;
using System.Text;
using Demo.Interface;

namespace Demo
{
    /// <summary>
    /// Manages information about the built string and arguments passed to build it with.
    /// </summary>
    public class SBuildContext : ISBuildContext
    {
        private readonly StringBuilder _parsedString;
        private readonly IEnumerator _argumentList;

        /// <summary>
        /// Constructor for the SBuildContext class
        /// </summary>
        /// <param name="argList">List of arguments to parse into the source string in place of the replace next item token.</param>
        public SBuildContext(params object[] argList)
        {
            _parsedString = new StringBuilder();
            _argumentList = argList.GetEnumerator();
        }
        /// <summary>
        /// Is the parsed string built so far is empty.
        /// </summary>
        /// <returns><c>true</c> if the string built so far is empty, otherwise <c>false</c></returns>
        public bool IsParsedStringEmpty()
        {
            return string.IsNullOrEmpty(_parsedString.ToString());
        }
        /// <summary>
        /// Returns the next argument passed to build the completed string with.
        /// </summary>
        /// <returns>The next <c>string</c> argument passed to build with</returns>
        public string GetNextArgument()
        {
            _argumentList.MoveNext();
            return _argumentList.Current?.ToString();
        }
        /// <summary>
        /// Appends a the next string part to the completed string
        /// </summary>
        /// <param name="newPart">The string to append</param>
        public void AppendString(string newPart)
        {
            _parsedString.Append(newPart);
        }
        /// <summary>
        /// Returns the string built up so far
        /// </summary>
        /// <returns><c>string</c> of the completed string</returns>
        public string ParsedString()
        {
            return _parsedString.ToString();
        }
    }
}
