public class CacheTestRequest
{
    public string Key { get; set; }
    public ValueData Value { get; set; }
    public int Ttl { get; set; }

    public class ValueData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
