using System.ComponentModel.DataAnnotations;

public class Actor{

    [Key]
    public int ActorID { get; set; }
    public string Nombres { get; set; }
    public decimal Salario { get; set; }
}