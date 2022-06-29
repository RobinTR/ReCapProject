using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.Description);
            }

            InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            foreach (var car in inMemoryCarDal.GetById(1))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}