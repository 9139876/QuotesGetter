using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.Library.Common.Quotes
{
    class TestingQuote
    {
        public Dictionary<string, object> Values { get; } = new Dictionary<string, object>()
        {
            { "Date", null },
            { "Open", null },
            { "Hi", null },
            { "Low", null },
            { "Close", null },
            { "Volume", null },
        };

        public Quote GetQuote()
        {
            foreach (var key in Values.Keys)
                if (Values[key] == null)
                    throw new InvalidOperationException($"Попытка создать котировку с неопределенным значением {key}");

            return new Quote(
                null,
                (DateTime)Values["Date"],
                (decimal)Values["Open"],
                (decimal)Values["Hi"],
                (decimal)Values["Low"],
                (decimal)Values["Close"],
                (decimal)Values["Volume"]
                );
        }
    }
}
