
namespace Demo.Interface
{
    /// <summary>
    /// Interface for the build context
    /// </summary>
    public interface ISBuildContext
    {
        /// <summary>
        /// Is the parsed string built so far is empty.
        /// </summary>
        /// <returns><c>true</c> if the string built so far is empty, otherwise <c>false</c></returns>
        bool IsParsedStringEmpty();
        /// <summary>
        /// Returns the next argument passed to build the completed string with.
        /// </summary>
        /// <returns>The next <c>string</c> argument passed to build with</returns>
        string GetNextArgument();
    }
}
