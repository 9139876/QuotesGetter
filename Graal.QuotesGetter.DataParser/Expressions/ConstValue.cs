using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    class ConstValue : Expression
    {
        string value;

        internal ConstValue() { }

        internal ConstValue(string[] parameters)
        {
            if (parameters.Length < 1)
                throw new ArgumentException("Недостаточное число параметров");

            value = parameters[0];
        }

        public override ExpressionType Type => ExpressionType.constValue;

        public override string ParametersHint => "Значение";

        public override string Name => $"Константное значение '{value}'";

        public override string Calculate(string inputValue) => value;

        protected override JObject Serialize() => new JObject(new JProperty(nameof(value), value));

        protected override void Deserialize(JObject serialize) => value = serialize.SelectToken(nameof(value)).ToString();
    }
}
