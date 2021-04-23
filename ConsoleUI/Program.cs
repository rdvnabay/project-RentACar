using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            //Test();

            //Add Car
            //CarManager carManager = AddCarMethod();


            //Add Brand
            //AddBrandMethod();

            //Add Color
            //AddColorMethod();

            //Car Detail Dto list
            //Console.WriteLine("-----------------------------");
            //var carDetails = carManager.GetCarDetails();
            //foreach (var carDetail in carDetails.Data)
            //{
            //    Console.WriteLine("{0} - {1} - {2} \n", carDetail.CarName, carDetail.BrandName, carDetail.ColorName);
            //}

            //10.gün - ders 4
            Brand brand1 = new Brand
            {
                Name = "Mercedes"
            };
            Brand brand2 = new Brand
            {
                Name = "BMW"
            };
            Brand brand3 = new Brand
            {
                Name = "Audi"
            };
            Color color1 = new Color();
            color1.Name = "Red";
            Color color2 = new Color();
            color1.Name = "Black";
            Color color3 = new Color();
            color1.Name = "Blue";
            Car car1 = new Car
            {
                Name = "Coupe",
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 100,
                Description = "Mercedes Benz Coupe Description",
                ModelYear = 2000
            };

            Car car2 = new Car
            {
                BrandId = 2,
                Name = "Sedan",
                ColorId = 2,
                DailyPrice = 200,
                Description = "BMW Sedan Description",
                ModelYear = 2005
            };

            Car car3 = new Car
            {
                BrandId = 3,
                Name = "Audi A4",
                ColorId = 3,
                DailyPrice = 300,
                Description = "Audi A4 Description",
                ModelYear = 2010
            };

            UserManager userManager = new UserManager(new EfUserDal());
            User user1 = new User
            {
                FirstName = "Rıdvan",
                LastName = "Abay",
                Email = "ridvanabay@gmail.com",
                Password = "123"
            };

            User user2 = new User
            {
                FirstName = "Ramazan",
                LastName = "Bayazit",
                Email = "ramazanbayazit@gmail.com",
                Password = "456"
            };

            User user3 = new User
            {
                FirstName = "Mert",
                LastName = "Artan",
                Email = "mertartan@gmail.com",
                Password = "789"
            };
            userManager.Add(user1);
            userManager.Add(user2);
            userManager.Add(user3);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1)
            };
            rentalManager.Add(rental1);
        }

        private static void AddColorMethod()
        {
            Color color1 = new Color();
            color1.Name = "Red";
            Color color2 = new Color();
            color1.Name = "Black";
            Color color3 = new Color();
            color1.Name = "Blue";
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);
        }

        private static void AddBrandMethod()
        {
            Brand brand1 = new Brand
            {
                Name = "Mercedes"
            };
            Brand brand2 = new Brand
            {
                Name = "BMW"
            };
            Brand brand3 = new Brand
            {
                Name = "Audi"
            };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);
        }

        private static CarManager AddCarMethod()
        {
            Car car1 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 100,
                Description = "Mercedes Benz",
                ModelYear = 2000
            };

            Car car2 = new Car
            {
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 200,
                Description = "BMW",
                ModelYear = 2005
            };

            Car car3 = new Car
            {
                BrandId = 3,
                ColorId = 3,
                DailyPrice = 300,
                Description = "Audi",
                ModelYear = 2010
            };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            var cars = carManager.GetAll();
            foreach (var car in cars.Data)
            {
                Console.WriteLine(car.Description);
            }

            return carManager;
        }

        private static void Test()
        {
            Car car1 = new Car
            {
                Id = 1,
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
