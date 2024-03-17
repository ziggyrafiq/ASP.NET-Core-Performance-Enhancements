using Microsoft.EntityFrameworkCore;
        static async Task Main(string[] args)
        {
            // Initialize your DbContext (replace MyDbContext with your actual DbContext)
            using var dbContext = new MyDbContext();

            // Check if the data is cached
            var cachedUser = await GetCachedUserAsync();
            if (cachedUser != null)
            {
                Console.WriteLine("User data retrieved from cache:");
                Console.WriteLine($"Id: {cachedUser.Id}, Name: {cachedUser.Name}");
            }
            else
            {
                // Fetch the user data from the database
                var user = await dbContext.Users
                    .Select(u => new UserData { Id = u.Id, Name = u.Name })
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    Console.WriteLine("User data retrieved from the database:");
                    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");

                    // Cache the retrieved user data
                    await CacheUserDataAsync(user);
                }
                else
                {
                    Console.WriteLine("User not found in the database.");
                }
            }
        }

        // Simulate caching - replace with your caching logic
        static async Task<UserData> GetCachedUserAsync()
        {
            // Implement your caching logic here
            // Return the cached user data or null if not found in cache
            return null;
        }

        // Simulate caching - replace with your caching logic
        static async Task CacheUserDataAsync(UserData user)
        {
            // Implement your caching logic here
            // Cache the user data
        }
  

    // Define your DbContext class (replace MyDbContext with your actual DbContext)
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // Add your DbContext configuration here
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 
