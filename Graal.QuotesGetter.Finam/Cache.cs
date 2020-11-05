using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.Finam
{
    static class Cache
    {
        static string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;

        static string GetFileName(string market) => Path.Combine(CurrentDirectory, "cache", market.Replace('/', '_') + ".cache");

        public static bool TryGetCashe(string market, out string cache)
        {
            if (File.Exists(GetFileName(market)))
            {
                using (FileStream fs = new FileStream(GetFileName(market), FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                    cache = sr.ReadToEnd();

                return true;
            }
            else
            {
                cache = string.Empty;
                return false;
            }
        }

        public static void SetCashe(string market, string cache)
        {
            using (FileStream fs = new FileStream(GetFileName(market), FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
                sw.Write(cache);
        }
    }
}
