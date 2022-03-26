using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public static class TestContext
    {
        static List<Car> _cars = new List<Car>();
      
       public static List<Car> GetAll()
        {
            return _cars;
        }

        public static Car GetById(int carId)
        {
            return _cars.FirstOrDefault(c=>c.Id==carId);
        }

        public static void Add(Car car)
        {
            _cars.Add(car);
        }
        public static void Update(Car car)
        {
            Car updatedCar = _cars.FirstOrDefault(c => c.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
            updatedCar.ModelYear = car.ModelYear;
        }
        public static void Delete(Car car)
        {
            _cars.Remove(car);
        }
    }
}
