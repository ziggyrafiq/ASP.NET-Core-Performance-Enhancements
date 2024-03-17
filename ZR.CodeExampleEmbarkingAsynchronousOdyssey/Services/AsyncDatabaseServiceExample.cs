using ZR.CodeExampleEmbarkingAsynchronousOdyssey.Models;

namespace ZR.CodeExampleEmbarkingAsynchronousOdyssey.Services
{
    public class AsyncDatabaseServiceExample
    {
        public static async Task<IEnumerable<Person>> GetPaginatedDataFromDatabaseAsync(int page, int pageSize)
        {
            // Implement database query logic here
            // Return a paginated result
            // This is just a placeholder; replace it with actual database access code
            var data = new List<Person>
            {
                new Person { Id = 1, Name = "Item 1" },
                new Person { Id = 2, Name = "Item 2" },
                // Add more data as needed
            };

            // Calculate the start index and take a subset of data for pagination
            int startIndex = (page - 1) * pageSize;
            var paginatedData = data.Skip(startIndex).Take(pageSize);

            await Task.Delay(TimeSpan.FromSeconds(1)); // Simulate asynchronous delay

            return paginatedData;
        }
    }
}

