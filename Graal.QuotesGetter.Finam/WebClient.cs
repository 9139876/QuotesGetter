using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Graal.QuotesGetter.Finam
{
    static class WebClient
    {
        /// <summary>
        /// Получает данные по ссылке Url
        /// </summary>
        /// <param name="url">Url ссылка</param>
        /// <returns></returns>
        public static bool TryGetURLData(string url, out string data)
        {
            try
            {
                using (var webcl = new System.Net.WebClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    webcl.Credentials = CredentialCache.DefaultNetworkCredentials;
                    data = webcl.DownloadString(url);
                }

                return true;
            }
            catch
            {
                data = string.Empty;
                return false;
            }


        }
    }
}
