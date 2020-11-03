using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    class GetSubstring : Expression
    {
        private int startIndex, length;

        internal GetSubstring() { }

        internal GetSubstring(string[] parameters)
        {
            if (parameters.Length < 2)
                throw new ArgumentException("Недостаточное число параметров");

            if (!int.TryParse(parameters[0], out startIndex))
                throw new InvalidOperationException($"Не удалось преобразовать значение '{parameters[0]}' в число");

            startIndex--;

            if (!int.TryParse(parameters[1], out length))
                throw new InvalidOperationException($"Не удалось преобразовать значение '{parameters[1]}' в число");
        }

        public override ExpressionType Type => ExpressionType.getSubstring;

        public override string ParametersHint => "Номер первого символа (от 1)\r\nи количество символов";

        public override string Name => $"Получение {length} символов, начиная с {startIndex + 1}";

        public override string Calculate(string inputValue) => inputValue.Substring(startIndex, length);

        protected override JObject Serialize()
        {
            return new JObject(
                new JProperty(nameof(startIndex), startIndex),
                new JProperty(nameof(length), length)
                );
        }

        protected override void Deserialize(JObject serialize)
        {
            startIndex = int.Parse(serialize.SelectToken(nameof(startIndex)).ToString());
            length = int.Parse(serialize.SelectToken(nameof(length)).ToString());
        }
    }
}
