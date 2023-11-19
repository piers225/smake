using Demo.Interface;

namespace Demo.Tokens
{
    /// <summary>
    /// Next Item replacer inserts the next argument passed in place of the token.
    /// </summary>
    public class NextItemReplacerToken : IToken
    {
        /// <summary>
        /// Constructor for the NextItemReplacerToken
        /// </summary>
        /// <param name="token">The token this should represent in the string</param>
        public NextItemReplacerToken(string token)
        {
            Token = token;
        }

        /// <summary>
        /// The token to replace
        /// </summary>
        public string Token { get; }
        /// <summary>
        /// This returns the next item to insert to the string.
        /// </summary>
        /// <param name="sBuildContext">The sbuild context provides properties about the built string and parameters passed to build the string.</param>
        /// <returns>The parsed string part to insert in place of this token.</returns>
        public string Parse(ISBuildContext sBuildContext)
        {
            return sBuildContext.GetNextArgument();
        }
    }
}
