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
        private char separator;

        private int index;

        internal GetRowValue() { }

        internal GetRowValue(string[] parameters)
        {
            if (parameters.Length < 2)
                throw new ArgumentException("Недостаточное число параметров");

            if (!char.TryParse(parameters[0], out separator))
                throw new InvalidOperationException($"Не удалось преобразовать значение '{parameters[0]}' в символ");

            if (!int.TryParse(parameters[1], out index))
                throw new InvalidOperationException($"Не удалось преобразовать значение '{parameters[1]}' в число");

            index--;
        }

        public override ExpressionType Type => ExpressionType.getRowValue;

        public override string ParametersHint => "Разделитель и номер столбца (с 1)";

        public override string Name => $"Получение значения {index + 1} столбца (разделитль '{separator}')";

        public override string Calculate(string inputValue) => inputValue.Split(separator)[index];

        protected override JObject Serialize()
        {
            return new JObject(
                new JProperty(nameof(index), index),
                new JProperty(nameof(separator), separator.ToString())
                );
        }

        protected override void Deserialize(JObject serialize)
        {
            index = int.Parse(serialize.SelectToken(nameof(index)).ToString());
            separator = char.Parse(serialize.SelectToken(nameof(separator)).ToString());
        }
    }
}
