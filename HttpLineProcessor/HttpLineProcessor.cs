using System;
using System.Linq;
using System.Net.Http;
using ScriptCs.Contracts;

namespace HttpLineProcessor
{
    public class HttpLineProcessor : DirectiveLineProcessor
    {
        protected override BehaviorAfterCode BehaviorAfterCode
        {
            get { return BehaviorAfterCode.Allow; }
        }

        protected override bool ProcessLine(IFileParser parser, FileParserContext context, string line)
        {
            var url = GetDirectiveArgument(line);
            var client = new HttpClient();

            var response = client.GetStringAsync(url).Result;

            parser.ParseScript(response.Split(Environment.NewLine.ToCharArray()).ToList(), context);

            return true;
        }

        protected override string DirectiveName
        {
            get { return "http"; }
        }
    }
}