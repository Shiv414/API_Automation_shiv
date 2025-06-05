public class CacheTestResponse
{
    public ValueData Value { get; set; }

    public class ValueData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}

