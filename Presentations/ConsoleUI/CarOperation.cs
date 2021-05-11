using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class CarOperation
    {
        CarManager carManager = new CarManager(new EfCarDal());
        public void ListToCarsByColorId()
        {
            Console.Write("Listelemek istediğiniz Renk ID : ");
            int listColorId = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", "CAR ID", "BRAND NAME", "MODEL NAME", "COLOR NAME", "MODEL YEAR", "BODY TYPE", "FEUL", "GEAR", "DAILY PRICE", "DESCRIPTION"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
            //foreach (var car in carManager.GetCarDetailsByColorId(listColorId).Data)
            //{
            //    Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", car.CarId, car.BrandName, car.ModelName, car.ColorName, car.ModelYear, car.BodyTypeName, car.FuelTypeName, car.GearTypeName, car.DailyPrice, car.Description));
            //}
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void ListToCarsByBrandId()
        {
            Console.Write("Listelemek istediğiniz Marka ID : ");
            int listBrandId = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", "CAR ID", "BRAND NAME", "MODEL NAME", "COLOR NAME", "MODEL YEAR", "BODY TYPE", "FEUL", "GEAR", "DAILY PRICE", "DESCRIPTION"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
            //foreach (var car in carManager.GetCarDetailsByBrandId(listBrandId).Data)
            //{
            //    Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", car.CarId, car.BrandName, car.ModelName, car.ColorName, car.ModelYear, car.BodyTypeName, car.FuelTypeName, car.GearTypeName, car.DailyPrice, car.Description));
            //}
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void DeleteToCar()
        {
            ListToCars();

            int _deleteId;
            Console.WriteLine();

            Console.Write("Silmek istediğiniz Kayıt ID : ");
            _deleteId = Convert.ToInt32(Console.ReadLine());

            Car deleteCar = new Car { Id = _deleteId };

            carManager.Delete(deleteCar);
            Console.WriteLine();

            Console.WriteLine("<<< Listenin Son Hali >>>");
            ListToCars();
        }

        public void AddToCar(int modelId)
        {
            int _modelId;
            decimal _dailyPrice;
            string _description;

            _modelId = modelId;
            Console.Write("Günlük Fiyat : ");
            _dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Açıklama : ");
            _description = Console.ReadLine();
            Console.WriteLine();


            Car car = new Car()
            {
                //edit
                ModelYear  = _modelId,
                DailyPrice = _dailyPrice,
                Description = _description
            };

            var result = carManager.Add(car);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(result.Message);
            Console.ResetColor();
            Console.WriteLine();
            //ListToCars(carManager);
        }

        public void ListToCars()
        {
            //var result = carManager.GetDetails();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", "CAR ID", "BRAND NAME", "MODEL NAME", "COLOR NAME", "MODEL YEAR", "BODY TYPE", "FEUL", "GEAR", "DAILY PRICE", "DESCRIPTION"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            //foreach (var car in result.Data)
            //{
            //   // Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", car.CarId, car.BrandName, "Model_Name Gelecek", car.ColorName, "Model_Year_Gelecek", "Body_TypeName_Gelecek", car.FuelTypeName, car.GearTypeName, car.DailyPrice, car.Description));
            //}
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void UpdateToCar()
        {
            int _updateCarId, _modelId;
            decimal _dailyPrice;
            string _description;

            ListToCars();
            Console.WriteLine();

            Console.Write("Güncellemek istediğiniz Kayıt ID : ");
            _updateCarId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Model ID : ");
            _modelId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Günlük Fiyat : ");
            _dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Açıklama : ");
            _description = Console.ReadLine();

            Console.WriteLine();

            Car updateCar = new Car
            {
                Id = _updateCarId,
                //edit
                ModelYear = _modelId,
                DailyPrice = _dailyPrice,
                Description = _description
            };

            carManager.Update(updateCar);

            //Console.WriteLine("\n<<< Listenin Son Hali >>>");
            //ListToCars();
        }
    }
}
