using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace Graal.QuotesGetter.Finam
{
    static class MarketsInfoDownloader
    {
        /// <summary>
        /// Возвращает список адресов инструментов, по которым можно получить их уникальные коды
        /// </summary>
        /// <param name="markets">Массив названий рынков</param>
        /// <returns></returns>
        //static List<string> GetTickersFromMarkets()
        //{
        //    List<string> result = new List<string>();

        //    foreach (string market in GetActualMarketsList())
        //    {
        //        int pageNumber = 1;

        //        while (WebClient.TryGetURLData($"https://www.finam.ru/quotes/{market}/?pageNumber={pageNumber}", out string urlData))
        //        {
        //            result.AddRange(ParseCode(urlData));

        //            pageNumber += 1;
        //            Thread.Sleep(200);
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// Формирует адреса инструментов для GetTickersFromMarkets
        /// </summary>
        /// <param name="text">Текст страницы</param>
        /// <param name="targ">Целевая строка</param>
        /// <param name="pref">Префикс</param>
        /// <param name="post">Постфикс</param>
        /// <returns></returns>
        static List<string> ParseCode(string text, string targ = "/profile/", string pref = "https://finam.ru", string post = "/export")
        {
            List<string> res = new List<string>();

            int n = text.IndexOf(targ, 0);

            while (n > 0)
            {
                res.Add(pref + text.Substring(n, text.IndexOf('"', n) - n) + post);

                n = text.IndexOf(targ, n + 1);
            }

            return res.Where(r => !r.Contains("analytics")).ToList();
        }

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
