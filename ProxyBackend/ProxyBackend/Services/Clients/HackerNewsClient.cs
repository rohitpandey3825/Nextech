using ProxyBackend.Common.Interfaces;

namespace ProxyBackend.Services.Clients
{
    public class HackerNewsClient : IHackerNewsClient
    {
        private const string BaseUrl = "https://hacker-news.firebaseio.com/v0/";

        private readonly IRedisRepository redisRepository;

        public HackerNewsClient(IRedisRepository redisRepository)
        {
            this.redisRepository = redisRepository;
        }




    }
}
