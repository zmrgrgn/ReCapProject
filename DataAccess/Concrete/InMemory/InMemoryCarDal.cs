using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=250,Description="Motor Hacmi 1,6 Lt",ModelYear=2015},
                new Car{CarId=2,BrandId=5,ColorId=3,DailyPrice=300,Description="Motor Hacmi 1,8 Lt",ModelYear=2005 },
                new Car{CarId=3,BrandId=4,ColorId=3,DailyPrice=270,Description="Motor Hacmi 1,2 Lt",ModelYear=2019 },
                new Car{CarId=4,BrandId=2,ColorId=1,DailyPrice=290,Description="Motor Hacmi 1,4 Lt",ModelYear=2012 },
                new Car{CarId=5,BrandId=3,ColorId=2,DailyPrice=350,Description="Motor Hacmi 2,0 Lt",ModelYear=2021}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c=>c.CarId==CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.ModelYear = car.ModelYear;
        }
    }
}
