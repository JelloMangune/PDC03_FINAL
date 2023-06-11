using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.EntityFrameworkCore;
using System.IO;
using FinalExam.Model;

using System.Threading.Tasks;

namespace FinalExam.ViewModel
    {
        public class AnimalViewModel
        {
            //Call Database

            private Services.DatabaseContext getContext()
            {
                return new Services.DatabaseContext();
            }

            //Insert Records function

            public int InsertAnimal(Animal obj)
            {
            try
            {
                var _dbContext = getContext();
                _dbContext.Animal.Add(obj);
                int c = _dbContext.SaveChanges();
                return c;
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception here
                Console.WriteLine(ex.InnerException.Message);
                // You can also log the exception or perform any other necessary actions
                // Return an appropriate value or throw a custom exception if needed
                throw;
            }
        }

            //Retrieve Records function

            public async Task<List<Animal>> GetAllAnimal()
            {
            try
            {
                var _dbContext = getContext();
                var res = await _dbContext.Animal.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                // Handle the exception or return an empty list
                Console.WriteLine("Error retrieving animals: " + ex.Message);
                return new List<Animal>();
            }
        }

            //Delete Records function

            public int DeleteAnimal(Animal obj)
            {
                var _dbContext = getContext();
                _dbContext.Animal.Remove(obj);
                int c = _dbContext.SaveChanges();
                return c;
            }

            //Update Records
            public async Task<int> UpdateAnimal(Animal obj)
            {
                var _dbContext = getContext();
                _dbContext.Animal.Update(obj);
                int c = await _dbContext.SaveChangesAsync();
                return c;
            }
            public async Task<Animal> GetAnimal(Animal obj)
            {
                var _dbContext = getContext();
                var animal = await _dbContext.Animal.FirstOrDefaultAsync(a =>
                    a.Id == obj.Id && a.AnimalCode == obj.AnimalCode);  // Replace with appropriate properties for comparison

                return animal;
            }
    }
    }

