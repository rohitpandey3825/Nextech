namespace ProxyBackend.Common.Model
{
    public class NewsItem
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
        public ItemType Type { get; set; }
        public string? By { get; set; }
        public DateTime Time { get; set; }
        public string? Text { get; set; }
        public bool Dead { get; set; }
        public int Parent { get; set; }
        public int Poll { get; set; }
        public List<int>? Kids { get; set; }
        public string? Url { get; set; }
        public int Score { get; set; }
        public string? Title { get; set; }
        public List<int>? Parts { get; set; }
        public int Descendants { get; set; }
    }

}