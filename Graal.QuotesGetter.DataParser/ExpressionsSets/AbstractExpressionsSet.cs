using System;
using System.Collections.Generic;
using System.Linq;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public abstract class AbstractExpressionsSet<T> where T : struct
    {
        protected abstract Dictionary<string, ExpressionsSequence<T>> Set { get; }

        public AbstractExpressionsSet() { }

        public AbstractExpressionsSet(string serailize)
        {
            Deserialize(serailize);
        }

        public string[] GetAllPropertiesNames() => Set.Keys.ToArray();

        public ExpressionsSequence<T> GetSequence(string name)
        {
            return Set.ContainsKey(name) ? Set[name] : null;
        }

        public abstract string Serialize();

        protected abstract void Deserialize(string serailize);
    }
}
