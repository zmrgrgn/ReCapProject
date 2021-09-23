using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 DailyPrice = ca.DailyPrice,
                                 ColorName = co.ColorName,
                                 BrandName=b.BrandName
                             };
                return result.ToList();
            }
        }
       
    }
}
