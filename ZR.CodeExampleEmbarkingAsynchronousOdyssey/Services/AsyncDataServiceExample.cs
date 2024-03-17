using Microsoft.EntityFrameworkCore;
using ZR.CodeExampleEmbarkingAsynchronousOdyssey.Models;
using ZR.CodeExampleOptimiseDataAccess;

namespace ZR.CodeExampleEmbarkingAsynchronousOdyssey.Services
{
    public class AsyncDataServiceExample
    {
        private readonly ExampleDatabaseContext dbContext;
        public AsyncDataServiceExample(ExampleDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Person>> GetPaginatedDataAsync(int page, int pageSize)
        {
            // Implement your data retrieval logic here
            // For example, fetch data from a database or other data source
            // Return a paginated subset of the data
            // Replace Person with your actual data model class
            return await AsyncDatabaseServiceExample.GetPaginatedDataFromDatabaseAsync(page, pageSize);
        }

        public async IAsyncEnumerable<Person> GetItemsAsync()
        {
            // Fetch items asynchronously from a data source (e.g., database)
            var items = await this.dbContext.Person.ToListAsync(); // Use .Persons instead of .Person

            foreach (var item in items)
            {
                yield return item;
            }
        }


    }
}
