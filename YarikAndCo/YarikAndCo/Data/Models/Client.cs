using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]


    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }

    public IEnumerable<Order> orders { get; set; }

}
