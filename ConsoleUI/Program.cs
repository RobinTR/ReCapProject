using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarDal carDal = new InMemoryCarDal();
            carDal.Add(new Car
                { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 19000, Description = "Örnek 4", ModelYear = 2011 });
            carDal.Add(new Car
                { Id = 5, BrandId = 9, ColorId = 5, DailyPrice = 12121, Description = "Örnek 5", ModelYear = 1999 });
            carDal.Add(new Car
                { Id = 6, BrandId = 2, ColorId = 13, DailyPrice = 9999, Description = "Örnek 6", ModelYear = 2017 });
            Console.WriteLine("GetById: " + carDal.GetById(5).Description);

            CarManager carManager = new CarManager(carDal);
            carDal.Delete(new Car {Id = 3});
            carDal.Update(new Car{Id = 1, ColorId = 13, DailyPrice = 23333, Description = "Örnek 1 updated", ModelYear = 2022, BrandId = 1});
            
            Console.WriteLine("Araba listesi: ");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("Markaya göre liste: ");
            foreach (var car in carDal.GetAllByBrand(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}