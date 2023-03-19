namespace InfoExplorer.Models
{
	public class IPModel
	{
        // instance of HttpClient use across this model
        HttpClient client;

        // url where i get my ip
        private readonly Uri urlIP = new("http://checkip.dyndns.org/");

        // my IP in string format
        public string IP { get; private set; } = "Not Found";


        public IPModel()  => client = new HttpClient();
        



        /// <summary>
        /// get my IP adress from checkip.dyndns.org
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetIP()
        {
            string stringIP = await client.GetStringAsync(urlIP);
            stringIP = stringIP.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "")
                               .Replace("</body></html>", "").Trim();
            IP = stringIP;
            return stringIP;
        }

    }
}
