using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class ColorOperation
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        public void AddToColor()
        {
            string _colorName;
            Console.Write("\nEklemek istediğiniz yeni Renk Adı : ");
            _colorName = Console.ReadLine();

            Color color = new Color
            {
                Name = _colorName
            };

            var result = colorManager.Add(color);
            Console.WriteLine(result.Message);

        }
        public void ListToColors()
        {
            var result = colorManager.GetAll();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-------------------------");
            Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", "ID", "RENK"));
            Console.WriteLine("-------------------------");

            Console.ResetColor();
            foreach (var colors in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", colors.Id, colors.Name));
            }
            Console.WriteLine("-------------------------");
        }
    }
}
