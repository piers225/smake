
namespace Demo.Interface
{
    /// <summary>
    /// Interface for the token
    /// </summary>
    internal interface IToken
    {
        /// <summary>
        /// The token to replace
        /// </summary>
        string Token { get; }
        /// <summary>
        /// This returns the the parsed string to insert in place of the token.
        /// </summary>
        /// <param name="sBuildContext">The sbuild context provides properties about the built string and parameters passed to build the string.</param>
        /// <returns>The parsed string part to insert in place of this token.</returns>
        string Parse(ISBuildContext sBuildContext);
    }
}
