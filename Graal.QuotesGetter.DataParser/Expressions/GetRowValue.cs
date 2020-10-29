using Graal.QuotesGetter.DataParser.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    class GetRowValue : Expression
    {
        private int index;

        private char separator;

        internal GetRowValue() { }

        internal GetRowValue(string[] parameters)
        {
            separator = char.Parse(parameters[0]);

            index = int.Parse(parameters[1]);
        }

        public override ExpressionType Type => ExpressionType.getRowValue;

        public override string Name => $"Получение значения {index + 1} столбца";

        public override string Calculate(string inputValue) => inputValue.Split(separator)[index];

        protected override JObject Serialize()
        {
            return new JObject(
                new JProperty(nameof(index), index),
                new JProperty(nameof(separator), separator)
                );
        }

        protected override void Deserialize(JObject serialize)
        {
            index = int.Parse(serialize.SelectToken(nameof(index)).ToString());
            separator = char.Parse(serialize.SelectToken(nameof(separator)).ToString());
        }
    }
}
