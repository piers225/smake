using System.Text.RegularExpressions;
using Demo.Interface;
using Demo.Tokens;

namespace Demo
{
    /// <summary>
    /// SBuilder handles the tokens and methods around replacing and building new string.
    /// </summary>
    public static class SBuilder
    {
        /// <summary>
        /// Collection of tokens to replace
        /// </summary>
        private static readonly IEnumerable<IToken> Tokens;

        static SBuilder()
        {
            Tokens = new IToken[] {
                new NextItemReplacerToken("%S"),
                new ReplaceToken("%N", Environment.NewLine),
                new ReplaceToken("%%","%"),
                new ReplaceConditionalToken("%,","," )
            };
        }
        
        /// <summary>
        /// SMake manages replacing the following tokens in a string passed in,
        ///  - %N is replaced with a new line
        ///  - %% is replaced with a %
        ///  - %, only replaced by a , if there is contents in the string
        ///  - %S is replaced by the matching argument passed to this method
        /// </summary>
        /// <param name="source">The string containing tokens to be parsed.</param>
        /// <param name="argList">List of arguments to parse into the source string in place of the %S token.</param>
        /// <returns>Correctly parsed <c>string</c></returns>
        public static string SMake(string source, params object[] argList)
        {
            var sBuildContext = new SBuildContext(argList);

            var parts = Regex.Split(source, "(" + string.Join("|", Tokens.Select(s => s.Token)) + ")"); 

            foreach(var part in parts)
            {
                var token = Tokens.FirstOrDefault(t => t.Token == part);

                if (token == null)
                {
                    sBuildContext.AppendString(part);
                }
                else
                {
                    sBuildContext.AppendString(token.Parse(sBuildContext));
                }
            }

            return sBuildContext.ParsedString();
        }
    }

}
