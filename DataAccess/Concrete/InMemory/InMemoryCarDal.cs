using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 10000, Description = "adsadas", ModelYear = 2022
                },
                new Car
                {
                    Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 9999, Description = "dfsgfdsgs", ModelYear = 2019
                },
                new Car
                {
                    Id = 3, BrandId = 1, ColorId = 4, DailyPrice = 5000, Description = "afgdhfgdhfdg", ModelYear = 2021
                }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
    }
}
