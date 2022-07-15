using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetByBrandId(int id);
        List<Car> GetByColorId(int id);
        Car GetById(int id);
        List<CarDetailDto> GetCarDetails();
    }
}
