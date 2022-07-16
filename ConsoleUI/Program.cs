using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test();
            //ColorTest();
            //GetCarDetailsTest();
            //TestMultiple();
        }

        private static void TestMultiple()
        {
            User user = new User
                { Email = "Test@gmail.com", FirstName = "Test", LastName = "Test", Password = "Test" };
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(user);
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer
            {
                CompanyName = "Test", UserId = 1
            };
            customerManager.Add(customer);

            Rental testRental = new Rental
                { CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 07, 16), ReturnDate = default };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(testRental);
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        //private static void Test()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.Description);
        //    }

        //    Console.WriteLine("***************************");

        //    foreach (var car in carManager.GetByBrandId(3))
        //    {
        //        Console.WriteLine(car.Description);
        //    }

        //    Console.WriteLine("***************************");

        //    foreach (var car in carManager.GetByColorId(1))
        //    {
        //        Console.WriteLine(car.Description);
        //    }

        //    //Kontrolü geçemeyecek carManager ile eklerken description 2 karakter kısa olduğu için.
        //    Car carNew = new Car()
        //    {
        //        Description = "Ö",
        //        BrandId = 2,
        //        ColorId = 3,
        //        DailyPrice = 555,
        //        ModelYear = 1999
        //    };

        //    //Kontrolü geçemeyecek carManager ile eklerken DailyPrice 0 olduğu için.
        //    Car carNew2 = new Car()
        //    {
        //        Description = "Ö",
        //        BrandId = 2,
        //        ColorId = 3,
        //        DailyPrice = 0,
        //        ModelYear = 1999
        //    };

        //    carManager.Add(carNew);
        //    carManager.Add(carNew2);
        //}
    }
}