using System.ComponentModel.DataAnnotations;

namespace GQL.Models;

public class CarModel
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    
    public IList<Car> Cars { get; set; }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }
}