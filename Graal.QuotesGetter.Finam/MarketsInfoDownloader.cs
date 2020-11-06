using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Security.Policy;
using Newtonsoft.Json.Linq;

namespace Graal.QuotesGetter.Finam
{
    public static class MarketsInfoDownloader
    {
        static List<string> GetUrlsTickerInfoPage(string pageData)
        {
            string pref = "https://finam.ru";
            string post = "export";

            pageData = pageData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(s => s.Contains("data-json"));

            List<string> urls = new List<string>();

            int instrumentIndex, start, end = 0;

            while (true)
            {
                instrumentIndex = pageData.IndexOf("instrument", end);

                if (instrumentIndex < 0)
                    break;

                start = pageData.IndexOf('{', instrumentIndex - 5);
                end = Index(pageData, start, '{', '}');

                if (end == -1)
                    break;

                var jobj = JObject.Parse(pageData.Substring(start, end - start).Replace("&quot;", "\""));

                urls.Add(pref + jobj.SelectToken("url").ToString() + post);
            }

            return urls;
        }

        static int Index(string s, int start, char open, char close)
        {
            if (start == -1)
                return -1;

            int openCount = 0, closeCount = 0;

            for (int i = start; i < s.Length; i++)
            {
                if (s[i] == open)
                    openCount++;
                else if (s[i] == close)
                    closeCount++;

                if (openCount == closeCount)
                    return i + 1;
            }

            return -1;
        }

        static FinamTickerInfo GetTickerInfoFromPage(string pageData)
        {
            string data = pageData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(s => s.Contains("Finam.IssuerProfile.Main.issue = "));

            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Не удалось получить данные по тикеру - полученная страница не содержит необходимых данных о тикере");

            data = data.Replace("Finam.IssuerProfile.Main.issue = ", "").Replace(";", "");

            var jobj = JObject.Parse(data);

            var quote = jobj.SelectToken("quote");
            var market = quote.SelectToken("market");
            var info = quote.SelectToken("info");

            var finamTI = new FinamTickerInfo()
            {
                TickerId = quote.SelectToken("id").ToString(),
                Code = quote.SelectToken("code").ToString(),
                Title = quote.SelectToken("title").ToString(),
                MarketId = market.SelectToken("id").ToString(),
                MarketTitle = market.SelectToken("title").ToString(),
                Currency = info.SelectToken("currency").ToString(),
                VolumeCode = info.SelectToken("volumeCode").ToString(),
                Url = quote.SelectToken("fullUrl").ToString(),
            };

            return finamTI;
        }

        /// <summary>
        /// Возвращает список адресов инструментов, по которым можно получить их уникальные коды
        /// </summary>
        /// <param name="markets">Массив названий рынков</param>
        /// <returns></returns>
        public static List<FinamTickerInfo> GetTickersInfos(string market)
        {
            List<FinamTickerInfo> result = new List<FinamTickerInfo>();

            int pageNumber = 1;

            while (WebClient.TryGetURLData($"https://www.finam.ru/quotes/{market}/?pageNumber={pageNumber}", out string urlData))
            {
                foreach (var url in GetUrlsTickerInfoPage(urlData))
                {
                    if (WebClient.TryGetURLData(url, out string tiPage))
                        result.Add(GetTickerInfoFromPage(tiPage));
                }

                pageNumber += 1;
                //Thread.Sleep(200);
            }

            return result;
        }

        ///// <summary>
        ///// Формирует адреса инструментов для GetTickersFromMarkets
        ///// </summary>
        ///// <param name="text">Текст страницы</param>
        ///// <param name="targ">Целевая строка</param>
        ///// <param name="pref">Префикс</param>
        ///// <param name="post">Постфикс</param>
        ///// <returns></returns>
        //static List<string> ParseCode(string text, string targ = "/profile/", string pref = "https://finam.ru", string post = "/export")
        //{
        //    List<string> res = new List<string>();

        //    int n = text.IndexOf(targ, 0);

        //    while (n > 0)
        //    {
        //        res.Add(pref + text.Substring(n, text.IndexOf('"', n) - n) + post);

        //        n = text.IndexOf(targ, n + 1);
        //    }

        //    return res.Where(r => !r.Contains("analytics")).ToList();
        //}

        /// <summary>
        /// Возвращает данные по тикеру, необходимые для получения котировок
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        //static FinamTickerInfo GetTickerInfo(string url)
        //{
        //    if (!WebClient.TryGetURLData(url, out string urlData))
        //        throw new Exception("Не удалось получить данные по тикеру - ошибка Web-клиента");

        //    int n = urlData.IndexOf(@"""quote"": {""id"":");

        //    if (n <= 0)
        //        throw new Exception("Не удалось получить данные по тикеру - Веб-клиент вернул некорректные данные");

        //    string[] tickerInfo = urlData.Substring(n, 800).Split(',');

        //    //var data = new string[7];

        //    var fti = new FinamTickerInfo() { Url = url };

        //    foreach (string ti in urlData.Substring(n, 800).Split(','))
        //    {
        //        if (ti.Contains(@"""quote"": {""id"":") && string.IsNullOrEmpty(fti.TickerId))
        //            fti.TickerId = ti.Substring(16).Replace("'", "");
        //        else if (ti.Contains(@"""code""") && string.IsNullOrEmpty(fti.Code))
        //            fti.Code = ti.Substring(10, ti.Length - 11).Replace("'", "");
        //        else if (ti.Contains(@"""title""") & data[2] == null)
        //            data[2] = ti.Substring(11, ti.Length - 12).Replace("'", "");
        //        else if (ti.Contains(@"""market"": {""id""") & data[3] == null)
        //            data[3] = ti.Substring(18).Replace("'", "");
        //        else if (ti.Contains(@"""title""") & data[4] == null)
        //            data[4] = ti.Substring(11, ti.Length - 12).Replace("'", "");
        //        else if (ti.Contains(@"""currency""") & data[5] == null)
        //            data[5] = ti.Substring(13, ti.Length - 15).Replace("'", "");
        //        else if (ti.Contains(@"""volumeCode""") & data[6] == null)
        //            data[6] = ti.Substring(15, ti.Length - 17).Replace("'", "");
        //    }
        //}

        /// <summary>
        /// Возращает служебную информацию по всем тикерам
        /// </summary>
        /// <returns></returns>
        //internal static void GetTickersInfo(ref int max, ref int cur, ref string text)
        //{
        //    var tiURLs = GetTickersFromMarkets().Except(Application.StorageManager.TickerInfo_GetAll().Select(ti=>ti.GetUrl));

        //    max = tiURLs.Count();
        //    cur = 0;

        //    foreach (string url in tiURLs)
        //    {
        //        Application.StorageManager.TickerInfo_AddToStorage(GetTickerInfo(url));
        //        cur++;
        //    }
        //}
    }
}
