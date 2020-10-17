using System;
using System.Collections.Generic;
using AnimalSpawn.Domain.Entities;
using System.Text;
using System.Linq;
using AnimalSpawn.Domain.Interfaces;
using System.Threading.Tasks;
using AnimalSpawn.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimalSpawn.Infraestructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalSpawnDBContext _context;
        private readonly IAnimalRepository _repository;
        public AnimalRepository(AnimalSpawnDBContext context)
        {
            this._context = context;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _context.Animal.SingleOrDefaultAsync(animal=>animal.Id==id) ?? new Animal();
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animal.ToListAsync();
        }
        public async Task AddAnimal(Animal animal)
        {
            var animals = await _repository.GetAnimals();
            var older = DateTime.Now - (animal?.CaptureDate ?? DateTime.Now);
            if (older.TotalDays > 45)
                throw new Exception("The animal's capture date is older than 45 days");
            if (animal?.EstimatedAge > 0 && (animal?.Weight <= 0 || animal?.Height <= 0))
                throw new Exception("The height and weight should be greater than zero.");
            if (animals.Any(item => item.Name == animal.Name))
                throw new Exception("This animal name already exist.");
            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAnimal(int id)
        {
            var current = await GetAnimal(id);
            _context.Animal.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }
        public async Task<bool> UpdateAnimal(Animal animal)
        {
            var current = await GetAnimal(animal.Id);
            current.GenusId = animal.GenusId;
            current.FamilyId = animal.FamilyId;
            current.Description = animal.Description;
            current.EstimatedAge = animal.EstimatedAge;
            current.Gender = animal.Gender;
            current.Height = animal.Height;
            current.Name = animal.Name;
            current.Photo = animal.Photo;
            current.SpeciesId = animal.SpeciesId;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }

    }
}
