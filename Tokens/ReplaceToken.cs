using Demo.Interface;

namespace Demo.Tokens
{
    /// <summary>
    /// Simple replace token class for wrapping the token to replace and the string to replace it with
    /// </summary>
    public class ReplaceToken : IToken
    {
        /// <summary>
        /// Constructor for the ReplaceToken
        /// </summary>
        /// <param name="token">The token this should represent in the string</param>
        /// <param name="replace">The string the token should be replaced by</param>
        public ReplaceToken(string token, string replace)
        {
            Token = token;
            Replace = replace;
        }
        /// <summary>
        /// This returns the replace string.
        /// </summary>
        /// <param name="sBuildContext">The sbuild context provides properties about the built string and parameters passed to build the string.</param>
        /// <returns>The parsed string part to insert in place of this token.</returns>
        public virtual string Parse(ISBuildContext sBuildContext)
        {
            return Replace;
        }

        /// <summary>
        /// The token to replace
        /// </summary>
        public string Token { get; }
        /// <summary>
        /// The string to replace the token with
        /// </summary>
        protected string Replace { get; }
    }
}
