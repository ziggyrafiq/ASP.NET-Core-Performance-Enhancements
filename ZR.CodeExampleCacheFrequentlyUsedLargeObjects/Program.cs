using Microsoft.Extensions.Caching.Memory;
using System.Buffers;

            // Create an instance of MemoryCache
            var memoryCache = new MemoryCache(new MemoryCacheOptions());

            // Create a large object (for demonstration purposes)
            var largeObject = new byte[1000000]; // A large byte array

            // Caching large objects
            memoryCache.Set("largeObject", largeObject, TimeSpan.FromMinutes(10));

            // Using ArrayPool<T> to rent and return arrays
            var largeArray = ArrayPool<byte>.Shared.Rent(10000); // Rent an array of 10,000 bytes
            try
            {
                // Use the rented array
                for (int i = 0; i < largeArray.Length; i++)
                {
                    largeArray[i] = (byte)(i % 256); // Fill the array with sample data
                }

                // Process the array or perform your operations here
                // ...

                // When done, return the rented array to the pool
                ArrayPool<byte>.Shared.Return(largeArray);
            }
            finally
            {
                // Ensure that the array is returned to the pool even in case of exceptions
                ArrayPool<byte>.Shared.Return(largeArray);
            }
