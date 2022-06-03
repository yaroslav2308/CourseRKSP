
public class Order
{
    public int id { get; set; }
    public string destination { get; set; }

    public Client client { get; set; }
    public Carpenter carpenter { get; set; }
    public Driver driver { get; set; }
    public IEnumerable<Furniture> furnitures { get; set; }
}

