using Graal.QuotesGetter.DataParser.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    class GetRow : Expression
    {
        private int index;

        public override ExpressionType Type => ExpressionType.getRow;

        public override string Name => $"Получение {index + 1} столбца";

        protected override string[] GetExpressionResult(string[] source) => source.Length > index ? new string[] { source[index] } : null;

        internal GetRow(object[] parameters)
        {
            if (parameters.Length != 1 || !int.TryParse(parameters[0].ToString(), out index))
                throw new InvalidOperationException("Не удалось получить значение номера столбца");

            //В принимаемых параметрах индеекс отсчитывается от 1
            index--;
        }

        internal GetRow() { }

        protected override JObject Serialize() => new JObject(new JProperty(nameof(index), index));

        protected override void Deserialize(JObject serialize) => index = int.Parse(serialize.SelectToken(nameof(index)).ToString());
    }
}
