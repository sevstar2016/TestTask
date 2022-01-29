using System.ComponentModel.DataAnnotations;

namespace GQL.Models;

public class Car
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string YearOfIssue { get; set; }
    public string Url { get; set; }
    
    public long CarModelId { get; set; }
    public CarModel CarModel { get; set; }
}

public class CarList
{
    public List<Car> cars { get; set; }
}