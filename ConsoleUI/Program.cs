using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Car car1 = new Car
            {
                Id=1,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 100,
                Description = "Mercedes Benz",
                ModelYear = 2000
            };

            Car car2 = new Car
            {
                Id = 2,
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 200,
                Description = "BMW",
                ModelYear = 2005
            };

            Car car3 = new Car
            {
                Id = 3,
                BrandId = 3,
                ColorId = 3,
                DailyPrice = 300,
                Description = "BMW",
                ModelYear = 2010
            };
            TestContext.Add(car1);
            TestContext.Add(car2);
            TestContext.Add(car3);
            TestContext.Delete(car3);
            car1.ModelYear = 2021;
            //TestContext.Update(car1);
            Console.WriteLine(TestContext.GetById(1).ModelYear);
            Console.WriteLine(TestContext.GetById(2).Description);
            foreach (var car in TestContext.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(TestContext.GetAll().Count);

           
        }
    }
}
