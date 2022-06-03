
public class Client
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }

    public IEnumerable<Order> orders { get; set; }
}

