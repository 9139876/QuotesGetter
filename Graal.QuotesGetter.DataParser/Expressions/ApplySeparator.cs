using Graal.QuotesGetter.DataParser.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    class ApplySeparator : Expression
    {
        private char separator;

        public override ExpressionType Type => ExpressionType.applySeparator;

        public override string Name => $"Применение разделителя '{separator}'";

        internal ApplySeparator(object[] parameters)
        {
            if (parameters.Length != 1 || !char.TryParse(parameters[0].ToString(), out separator))
                throw new InvalidOperationException("Не удалось получить значение разделителя");
        }

        internal ApplySeparator() { }

        protected override string[] GetExpressionResult(string[] source) => source?.First()?.Split(separator); 

        protected override JObject Serialize() => new JObject(new JProperty(nameof(separator), separator));

        protected override void Deserialize(JObject serialize) => separator = char.Parse(serialize.SelectToken(nameof(separator)).ToString());

        
    }
}
