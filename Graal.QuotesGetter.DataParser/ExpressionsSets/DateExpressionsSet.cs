using Graal.Library.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public class DateExpressionsSet : AbstractExpressionsSet<int>
    {
        public DateExpressionsSet() { }

        public DateExpressionsSet(string serailize)
        {
            Deserialize(serailize);
        }

        protected override Dictionary<string, ExpressionsSequence<int>> Set { get; } = new Dictionary<string, ExpressionsSequence<int>>()
        {
            {"Year", new ExpressionsSequence<int>() },
            {"Month", new ExpressionsSequence<int>() },
            {"Day", new ExpressionsSequence<int>() },
            {"Hour", new ExpressionsSequence<int>() },
            {"Minute", new ExpressionsSequence<int>() }
        };

        public bool TryParse(string row, out DateTime date, out string error)
        {
            error = string.Empty;
            date = DateTime.MinValue;

            try
            {
                date = new DateTime(
                    Set["Year"].GetValue(row),
                    Set["Month"].GetValue(row),
                    Set["Day"].GetValue(row),
                    Set["Hour"].GetValue(row),
                    Set["Minute"].GetValue(row),
                    0
                    );

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public override string Serialize()
        {
            JObject res = new JObject();

            foreach (var key in Set.Keys)
                res.Add(key, Set[key].Serialize());

            return res.ToString();
        }

        protected override void Deserialize(string serailize)
        {
            JObject jobj = JObject.Parse(serailize);

            foreach (var key in Set.Keys.ToList())
                Set[key] = new ExpressionsSequence<int>((JObject)jobj.SelectToken(key));
        }

        public override AbstractExpressionsSet<int> Clone()
        {
            var clone = new DateExpressionsSet();

            foreach (var key in Set.Keys)
                clone.Set[key] = (ExpressionsSequence<int>)Set[key].Clone();

            return clone;
        }
    }
}
