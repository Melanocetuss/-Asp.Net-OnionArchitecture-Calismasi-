using AspNetOnionArc.Application.Interfaces.CarInterfaces;
using AspNetOnionArc.Domain.Entities;
using AspNetOnionArc.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AspNetOnionArcContext _context;
        public CarRepository(AspNetOnionArcContext context)
        {
            _context = context;
        }

        public List<Car> GetCarListWithBrands()
        {
            var values = _context.Cars.Include(x=> x.Brand).ToList();
            return values;
        }
    }
}
