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
        public abstract ExpressionType Type { get; }

        public abstract string ParametersHint { get; }

        public abstract string Name { get; }

        public abstract string Calculate(string inputValue);

        abstract protected JObject Serialize();

        abstract protected void Deserialize(JObject serialize);

        #region static

        public static string GetExpressionHint(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.getRowValue:
                    return new GetRowValue().ParametersHint;
                case ExpressionType.constValue:
                    return new ConstValue().ParametersHint;
                case ExpressionType.getSubstring:
                    return new GetSubstring().ParametersHint;
                case ExpressionType.replaceString:
                    return new ReplaceString().ParametersHint;
                default:
                    throw new ArgumentException($"Неизвестный тип выражения - '{type}'");
            }
        }

        public static Expression GetExpression(JObject serialize)
        {
            ExpressionType type = (ExpressionType)int.Parse(serialize.SelectToken(nameof(Type)).ToString());

            Expression expression;

            switch (type)
            {
                case ExpressionType.getRowValue:
                    expression = new GetRowValue();
                    break;
                case ExpressionType.constValue:
                    expression = new ConstValue();
                    break;
                case ExpressionType.getSubstring:
                    expression = new GetSubstring();
                    break;
                case ExpressionType.replaceString:
                    expression = new GetSubstring();
                    break;
                default:
                    throw new ArgumentException($"Неизвестный тип выражения - '{type}'");
            }

            expression.Deserialize((JObject)serialize.SelectToken("Specification"));

            return expression;
        }

        public static Expression GetExpression(ExpressionType type, string[] parameters)
        {
            switch (type)
            {
                case ExpressionType.getRowValue:
                    return new GetRowValue(parameters);
                case ExpressionType.constValue:
                    return new ConstValue(parameters);
                case ExpressionType.getSubstring:
                    return new GetSubstring(parameters);
                case ExpressionType.replaceString:
                    return new ReplaceString(parameters);
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
