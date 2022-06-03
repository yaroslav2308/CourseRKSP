using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]

    public int id { get; set; }
    public string destination { get; set; }

    public Client client { get; set; }
    public Carpenter carpenter { get; set; }
    public Driver driver { get; set; }
    public IEnumerable<Furniture> furnitures { get; set; }

}

