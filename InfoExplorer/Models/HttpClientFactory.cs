namespace InfoExplorer.Models
{
    //https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-7.0

    /// <summary>
    /// provides static instance HttpClient with 10 minutes connection life
    /// </summary>
    public static class HttpClientFactory
    {
        private static readonly TimeSpan connectionLifetime = TimeSpan.FromMinutes(10);

        public static HttpClient CreateClient()
        {
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = connectionLifetime
            };

            return new HttpClient(handler);
        }
    }
}
