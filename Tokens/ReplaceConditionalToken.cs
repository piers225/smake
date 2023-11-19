using Demo.Interface;

namespace Demo.Tokens
{
    /// <summary>
    /// Replace conditionally token wraps the token and the replace string. 
    /// This only inserts the the replace string when the complete string is not empty.
    /// </summary>
    public class ReplaceConditionalToken : ReplaceToken
    {
        /// <summary>
        /// Constructor for the ReplaceConditionalToken
        /// </summary>
        /// <param name="token">The token this should represent in the string</param>
        /// <param name="replace">The string the token should be replaced by</param>
        public ReplaceConditionalToken(string token, string replace) :
            base(token, replace)
        {
        }

        /// <summary>
        /// This returns the replace string when the string built so far is not empty.
        /// </summary>
        /// <param name="sBuildContext">The sbuild context provides properties about the built string and parameters passed to build the string</param>
        /// <returns>The parsed string part to insert in place of this token.</returns>
        public override string Parse(ISBuildContext sBuildContext)
        {
            if (sBuildContext.IsParsedStringEmpty())
            {
                return string.Empty;
            }
            return this.Replace;
        }
    }
}
