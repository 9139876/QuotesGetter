using System;
using System.Collections.Generic;

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

        public abstract string Serialize();

        protected abstract void Deserialize(string serailize);
    }
}
