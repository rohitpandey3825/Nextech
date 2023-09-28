using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using ProxyBackend.Common.Interfaces;
using ProxyBackend.Common.Model;

namespace ProxyBackend.Services.Redis
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IDistributedCache RedisCacheDb;

        public RedisRepository(IDistributedCache redisCacheDb)
        {
            this.RedisCacheDb = redisCacheDb;
        }

        public async Task<NewsItem> GetItem(string Id)
        {
            string ItemJson = await this.RedisCacheDb.GetStringAsync(Id);
            if (string.IsNullOrEmpty(ItemJson)) return null;

            var Item = JsonConvert.DeserializeObject<NewsItem>(ItemJson);
            return Item;
        }

        public async Task<NewsItem> UpdateItem(NewsItem Item)
        {
            string jsonValue = JsonConvert.SerializeObject(Item);
            await this.RedisCacheDb.SetStringAsync(Item.Id, jsonValue);
            return await GetItem(Item.Id);
        }

        public async Task DeleteItem(string userName)
        {
            await this.RedisCacheDb.RemoveAsync(userName);
        }

    }
}
