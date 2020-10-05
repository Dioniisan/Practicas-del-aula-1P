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

    public async Task<IEnumerable<Animal>> GetAnimals()
    {
            return await _context.Animal.ToListAsync();
    }
}
}
