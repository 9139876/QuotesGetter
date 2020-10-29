using Graal.QuotesGetter.DataParser.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.ExpressionsSequences
{
    abstract class ExpressionsSequence
    {
        List<Expression> sequence = new List<Expression>();

        public void AddExpression(Expression expression, int position)
        {

        }

        public void RemoveExpression(int position)
        {

        }

        public void Clear() => sequence.Clear();

        public List<Expression> GetAllExpressions => sequence.ToList();

        protected string Calculate(string row)
        {
            foreach (var expr in sequence)
                row = expr.Calculate(row);

            return row;
        }

        public abstract ExpressionsSequenceType Type { get; }

        public abstract DateTime GetData(string row);

        public abstract decimal GetDecimal(string row);

        public JObject Serialize()
        {
            JArray jArray = new JArray();

            sequence.ForEach(p => jArray.Add(Expression.SerializeExpression(p)));

            return new JObject(
                new JProperty(nameof(Type), (int)Type),
                new JProperty(nameof(sequence), jArray)
                );
        }

        void Deserialize(JObject serialize)
        {
            sequence.AddRange(
               ((JArray)serialize.SelectToken(nameof(sequence)))
               .Select(ex => Expression.GetExpression((JObject)ex))
               );
        }

        public static ExpressionsSequence GetExpressionSequence(string serialize)
        {
            var jObj = JObject.Parse(serialize);

            ExpressionsSequenceType type = (ExpressionsSequenceType)int.Parse(jObj.SelectToken(nameof(Type)).ToString());

            ExpressionsSequence expressionsSequence;

            switch (type)
            {
                case ExpressionsSequenceType.Date:
                    expressionsSequence = new ExpressionsSequenceDate();
                    break;
                case ExpressionsSequenceType.Decimal:
                    expressionsSequence = new ExpressionsSequenceDecimal();
                    break;
                default:
                    throw new ArgumentException($"Неизвестный тип цепочки выражений - '{type}'");
            }

            expressionsSequence.Deserialize((JObject)jObj.SelectToken(nameof(sequence)));

            return expressionsSequence;
        }
    }
}
