using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarManagementEntity
{
    internal class CarsDB
    {
        private readonly CarDbContext db;

        public CarsDB()
        {
            db = new CarDbContext();
            db.Database.EnsureCreated();
        }

        #region DataBaseActions
        public void AddCar(Car car)
        {
            var lastCar = db.Cars.OrderByDescending(c => c.Id).FirstOrDefault();
            int lastId = (lastCar != null) ? lastCar.Id : 0;
            car.Id = lastId + 1;
            db.Cars.Add(car);
            db.SaveChanges();
        }
        public void EditCar (int carId, EnumCarsBrands brand, string model)
        {
            var car = db.Cars.Find(carId);
            if(car != null)
            {
                car.Brand = brand;
                car.Model = model;
                db.SaveChanges();
            }
        }
        public void RemoveCar(int carId)
        {
            var car = db.Cars.Find(carId);
            if(car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }
        public List<Car> GetCars() => db.Cars.ToList();
        #endregion
    }
}
