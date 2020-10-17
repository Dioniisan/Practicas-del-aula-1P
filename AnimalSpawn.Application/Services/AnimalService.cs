using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalSpawn.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        public AnimalService(IAnimalRepository repository)
        {
            this._repository = repository;
        }

        public async Task AddAnimal(Animal animal)
        {
            await _repository.AddAnimal(animal);
        }
        public async Task<bool> DeleteAnimal(int id)
        {
            return await _repository.DeleteAnimal(id);
        }
        public async Task<Animal> GetAnimal(int id)
        {
            return await _repository.GetAnimal(id);
        }
        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _repository.GetAnimals();
        }
        public async Task<bool> UpdateAnimal(Animal animal)
        {
            return await _repository.UpdateAnimal(animal);
        }
    }
}
