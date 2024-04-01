using StackExchange.Redis;

namespace azure_redis_cache_devcontainer
{
    class Program{
        // connection string to your Redis Cache    
        private const string connectionString = "REDIS_CONNECTION_STRING";

         public static async Task Main(string[] args){
            using (var cache = ConnectionMultiplexer.Connect(connectionString))
            {
                IDatabase db = cache.GetDatabase();

                // Snippet below executes a PING to test the server connection
                var result = await db.ExecuteAsync("ping");
                Console.WriteLine($"PING = {result.Type} : {result}");

                // Call StringSetAsync on the IDatabase object to set the key "test:key" to the value "100"
                bool setValue = await db.StringSetAsync("test:key", "100");
                Console.WriteLine($"SET: {setValue}");

                // StringGetAsync retrieves the value for the "test" key
                string getValue = await db.StringGetAsync("test:key");
                Console.WriteLine($"GET: {getValue}");
            }
         }
    }

}
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");