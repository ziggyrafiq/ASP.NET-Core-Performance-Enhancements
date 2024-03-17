namespace ZR.CodeExampleEmbarkingAsynchronousOdyssey.Helpers
{
    public class AsyncExample
    {
        private readonly HttpClient _httpClient;

        public AsyncExample()
        {
            // Initialize HttpClient in the constructor to reuse it efficiently.
            _httpClient = new HttpClient();
        }

        public async Task<int> FetchDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://exampleUrlAddress.com/data");

                if (response.IsSuccessStatusCode)
                {
                    // Perform processing on response asynchronously
                    var data = await response.Content.ReadAsStringAsync();
                    return data.Length;
                }
                else
                {
                    // Handle unsuccessful response (e.g., log an error, return a specific value)
                    return -1;
                }
            }
            catch (HttpRequestException)
            {
                // Handle exceptions related to the HTTP request (e.g., network issues)
                return -1;
            }
        }
    }
}
