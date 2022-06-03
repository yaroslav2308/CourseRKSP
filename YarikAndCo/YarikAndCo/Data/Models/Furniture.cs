using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Furniture
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]

    public int id { get; set; }
    public string furnitureName { get; set; }
    public string type { get; set; }
    public string roomType { get; set; }
    public int price { get; set; }
    public int oldPrice { get; set; }
    public string imageLink1 { get; set; }
    public string imageLink2 { get; set; }
    public string imageLink3 { get; set; }
    public string imageLink4 { get; set; }
    public string aboutText { get; set; }

    public IEnumerable<Order> orders { get; set; }

}
