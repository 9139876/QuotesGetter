using Graal.QuotesGetter.DataParser.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public class ExpressionsSequence<T> : IExpressionsSequence where T : struct
    {
        readonly List<Expression> sequence = new List<Expression>();

        public void AppendExpression(Expression expression) => sequence.Add(expression);

        public void RemoveExpression(int position) => sequence.RemoveAt(position);

        public void Clear() => sequence.Clear();

        public Expression[] GetAllExpressions() => sequence.ToArray();

        public ExpressionsSequence() { }

        public ExpressionsSequence(JObject jObj)
        {
            Deserialize((JObject)jObj.SelectToken(nameof(sequence)));
        }

        protected string Calculate(string row)
        {
            foreach (var expr in sequence)
                row = expr.Calculate(row);

            return row;
        }

        public T GetValue(string row) => (T)Convert.ChangeType(row, typeof(T));

        public JObject Serialize()
        {
            JArray jArray = new JArray();

            sequence.ForEach(p => jArray.Add(Expression.SerializeExpression(p)));

            return new JObject(
                new JProperty(nameof(sequence), jArray)
                );
        }

        void Deserialize(JObject serialize)
        {
            sequence.Clear();

            sequence.AddRange(
               ((JArray)serialize.SelectToken(nameof(sequence)))
               .Select(ex => Expression.GetExpression((JObject)ex))
               );
        }
    }
}
