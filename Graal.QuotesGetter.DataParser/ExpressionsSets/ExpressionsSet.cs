using Graal.Library.Common;
using Graal.Library.Common.Quotes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public class ExpressionsSet : AbstractExpressionsSet<decimal>
    {
        protected override Dictionary<string, ExpressionsSequence<decimal>> Set { get; } = new Dictionary<string, ExpressionsSequence<decimal>>()
        {
            { "Open", new ExpressionsSequence<decimal>() },
            { "Hi", new ExpressionsSequence<decimal>() },
            { "Low", new ExpressionsSequence<decimal>() },
            { "Close", new ExpressionsSequence<decimal>() },
            { "Volume", new ExpressionsSequence<decimal>() }
        };

        public int RowSkipCount { get; set; } = 0;

        public DateExpressionsSet DateExpressionsSet { get; set; } = new DateExpressionsSet();

        public ExpressionsSet() { }

        public ExpressionsSet(string serailize)
        {
            Deserialize(serailize);
        }

        public bool TryParse(string row, out Quote quote, out string error)
        {
            quote = null;
            error = string.Empty;

            var tq = new TestingQuote();

            if (!DateExpressionsSet.TryParse(row, out DateTime dt, out error))
            {
                error = $"Ошибка получения даты: {error}";
                return false;
            }

            tq.Values["Date"] = dt;

            foreach (var key in Set.Keys)
            {
                try
                {
                    tq.Values[key] = Set[key].GetValue(row);
                }
                catch (Exception ex)
                {
                    error += $"Ошибка {ex.Message}, выражение для {key}";
                }
            }

            quote = tq.GetQuote();

            return quote != null;
        }

        public override string Serialize()
        {
            JObject res = new JObject();

            foreach (var key in Set.Keys)
                res.Add(key, Set[key].Serialize());

            res.Add(nameof(RowSkipCount), RowSkipCount);

            res.Add(nameof(DateExpressionsSet), DateExpressionsSet.Serialize());

            return res.ToString();
        }

        protected override void Deserialize(string serailize)
        {
            JObject jobj = JObject.Parse(serailize);

            foreach (var key in Set.Keys.ToList())
                Set[key] = new ExpressionsSequence<decimal>((JObject)jobj.SelectToken(key));

            RowSkipCount = int.Parse(jobj.SelectToken(nameof(RowSkipCount)).ToString());

            DateExpressionsSet = new DateExpressionsSet(jobj.SelectToken(nameof(DateExpressionsSet)).ToString());
        }

        public override AbstractExpressionsSet<decimal> Clone()
        {
            var clone = new ExpressionsSet();

            foreach (var key in Set.Keys)
                clone.Set[key] = (ExpressionsSequence<decimal>)Set[key].Clone();

            clone.RowSkipCount = RowSkipCount;
            clone.DateExpressionsSet = (DateExpressionsSet)DateExpressionsSet.Clone();

            return clone;
        }
    }
}
