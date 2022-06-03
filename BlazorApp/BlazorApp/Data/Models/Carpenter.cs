
public class Carpenter
{
    public int id { get; set; }
    public string name { get; set; }
    public string phone { get; set; }
    public int seniority { get; set; }

    public IEnumerable<Order> orders { get; set; }
}

