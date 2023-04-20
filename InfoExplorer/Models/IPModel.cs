using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Web;

namespace InfoExplorer.Models
{
    /// <summary>
    /// UNUSED CLASS - GET NOT user IP but IP server, only for local testing
    /// </summary>
	public class IPModel
	{
        // instance of HttpClient use across this model
        HttpClient client;

        // url where i get  ip
        private readonly Uri urlIP = new("http://checkip.dyndns.org/");

        // IP in string format
        public string IP { get; private set; } = "Not Found";






        /// <summary>
        /// get my IP adress from checkip.dyndns.org // update - get IP adress of server
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetIP()
        {
            using HttpClient client = new();
            string stringIP = await client.GetStringAsync(urlIP);
            stringIP = stringIP.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "")
                               .Replace("</body></html>", "").Trim();
            IP = stringIP;
            return stringIP;
        }




    }
}
