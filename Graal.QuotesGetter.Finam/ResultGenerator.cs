using Graal.QuotesGetter.Common;
using Graal.QuotesGetter.Finam.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.Finam
{
    class ResultGenerator
    {
        public static Result GetInfo(Command cmd)
        {
            return new Result()
            {
                Success = true,
                Data = new string[]
                {
                    "aaa",
                    "bbb"
                }
            };
        }

        public static Result GetMarkets(Command cmd)
        {
            return new Result()
            {
                Success = true,
                Data = Resources.markets.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        public static Result GetTickers(Command cmd)
        {
            var res = new Result() { Success = true };

            if (Cache.TryGetCashe(cmd.MarketName, out string cache))
            {
                try
                {
                    res.Data = JArray.Parse(cache)
                        .Select(ti => FinamTickerInfo.Parse(ti.ToString()))
                        .Select(ti => ti.GetStandartTickerInfo().ToJson())
                        .ToArray();

                    return res;
                }
                catch { }
            }



            throw new NotImplementedException();
        }

        public static Result GetQuotes(Command cmd)
        {
            if (!Cache.TryGetCashe(cmd.MarketName, out string cache))
                throw new Exception($"В кэше нет данных по рынку {cmd.MarketName}");

            var fti = JArray.Parse(cache)
                        .Select(ti => FinamTickerInfo.Parse(ti.ToString()))
                        .FirstOrDefault(ti => ti.Title == cmd.TickerName)
                        ?? throw new Exception($"В кэше для рынка {cmd.MarketName} нет данных по тикеру {cmd.TickerName}");



            throw new NotImplementedException();
        }
    }
}
