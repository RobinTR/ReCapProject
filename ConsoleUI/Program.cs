using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("***************************");

            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("***************************");

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }

            //Kontrolü geçemeyecek carManager ile eklerken description 2 karakter kısa olduğu için.
            Car carNew = new Car()
            {
                Description = "Ö",
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 555,
                ModelYear = 1999
            };

            //Kontrolü geçemeyecek carManager ile eklerken DailyPrice 0 olduğu için.
            Car carNew2 = new Car()
            {
                Description = "Ö",
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 0,
                ModelYear = 1999
            };

            carManager.Add(carNew);
            carManager.Add(carNew2);
        }
    }
}