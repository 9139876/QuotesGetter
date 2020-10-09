using Graal.QuotesGetter.DataParser.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    public abstract class Expression
    {
        private string[] prevInput;

        private string[] result;

        public abstract ExpressionType Type { get; }

        public abstract string Name { get; }

        public string[] Calculate(string[] inputValue, Queue<Expression> expressions)
        {
            if (inputValue != prevInput)
            {
                prevInput = inputValue;
                if (expressions.Count > 0)
                    inputValue = expressions.Dequeue().Calculate(inputValue, expressions);

                result = GetExpressionResult(inputValue) ?? throw new ArgumentException(string.Format(Resources.ExpressionNullArgumentError, Name));
            }

            return result;
        }

        protected abstract string[] GetExpressionResult(string[] source);

        abstract protected JObject Serialize();

        abstract protected void Deserialize(JObject serialize);

        #region static

        public static Expression GetExpression(string serialize)
        {
            var jObj = JObject.Parse(serialize);

            ExpressionType type = (ExpressionType)int.Parse(jObj.SelectToken(nameof(Type)).ToString());

            Expression expression;

            switch (type)
            {
                case ExpressionType.applySeparator:
                    expression = new ApplySeparator();
                    break;
                case ExpressionType.getRow:
                    expression = new GetRow();
                    break;
                default:
                    throw new ArgumentException($"Неизвестный тип выражения - '{type}'");
            }

            expression.Deserialize((JObject)jObj.SelectToken("Specification"));

            return expression;
        }

        public static Expression GetExpression(ExpressionType type, object[] parameters)
        {
            switch (type)
            {
                case ExpressionType.applySeparator:
                    return new ApplySeparator(parameters);
                case ExpressionType.getRow:
                    return new GetRow(parameters);
                default:
                    throw new ArgumentException($"Неизвестный тип выражения - '{type}'");
            }
        }

        public static string SerializeExpression(Expression expression)
        {
            return new JObject(
                new JProperty(nameof(Type), (int)expression.Type),
                new JProperty("Specification", expression.Serialize())
                ).ToString();
        }

        #endregion
    }
}
