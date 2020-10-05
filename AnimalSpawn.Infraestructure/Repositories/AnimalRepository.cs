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
            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();
        }

    }
}
