using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    class ReplaceString : Expression
    {
        private string from, to;

        internal ReplaceString() { }

        internal ReplaceString(string[] parameters)
        {
            if (parameters.Length < 2)
                throw new ArgumentException("Недостаточное число параметров");

            from = parameters[0];

            to = parameters[1];
        }

        public override ExpressionType Type => ExpressionType.replaceString;

        public override string ParametersHint => "Что и на что заменять";

        public override string Name => $"Замена '{from}' на '{to}'";

        public override string Calculate(string inputValue) => inputValue.Replace(from, to);

        protected override JObject Serialize()
        {
            return new JObject(
                new JProperty(nameof(from), from),
                new JProperty(nameof(to), to)
                );
        }

        protected override void Deserialize(JObject serialize)
        {
            from = serialize.SelectToken(nameof(from)).ToString();
            to = serialize.SelectToken(nameof(to)).ToString();
        }
    }
}
